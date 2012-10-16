using System;
using System.Collections.Generic;
using System.Linq;
using WebGarten2;
using System.Net.Http;
using System.Net;
using TrelloApp.Views;
using WebGarten2.Html;
using TrelloApp.Models;
using System.Collections.Specialized;

namespace TrelloApp.Controllers
{
    class Controller
    {
        private readonly IElementRepository _repo;
        public Controller()
        {
            _repo = ElementRepositoryLocator.Get();
        }


        //ALL BOARDS
        [HttpMethod("GET", "/boards")]
        public HttpResponseMessage GetAllBoards()
        {
            return SetResponse(new AllBoardsView(_repo.GetAll()).AsHtmlContent());
        }

        //ONE BOARD
        [HttpMethod("GET", "/boards/{bid}")]
        public HttpResponseMessage GetSingleBoard(string bid)
        {
            var td = _repo.GetBoardById(bid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new NotFoundView().AsHtmlContent()) : SetResponse(new SingleBoardView(td).AsHtmlContent());
        }

        //ONE LIST
        [HttpMethod("GET", "/boards/{bid}/lists/{lid}")]
        public HttpResponseMessage GetSingleList(string bid,string lid)
        {
            var td = _repo.GetListById(bid,lid);
            return td == null ? SetResponse(HttpStatusCode.NotFound,new NotFoundView().AsHtmlContent()) : SetResponse(new SingleListView(td,bid).AsHtmlContent());
        }

        //ONE CARD
        [HttpMethod("GET", "/boards/{bid}/cards/{cid}")]
        public HttpResponseMessage GetSingleCard(string bid, string cid)
        {
            var td = _repo.GetCardById(bid, cid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new NotFoundView().AsHtmlContent()) : SetResponse(new SingleCardView(td, bid).AsHtmlContent());
        }

        //ARCHIVE
        [HttpMethod("GET", "/archive/boards/{bid}/cards/{cid}")]
        public HttpResponseMessage ArchiveCard(int bid,int cid)
        {
            return new HttpResponseMessage
            {
                //Content = new TestView().AsHtmlContent()
            };
        }

        //ROOT PAGE
        [HttpMethod("GET", "/")]
        public HttpResponseMessage GetRoot()
        {
            return SetResponse(new RootView().AsHtmlContent());
        }

        //CREATE BOARD PAGE
        [HttpMethod("GET", "/create/boards")]
        public HttpResponseMessage CreateBoard()
        {
            return SetResponse(new CreateBoardView().AsHtmlContent());
        }

        //CREATE LIST PAGE
        [HttpMethod("GET", "/create/boards/{bid}/lists")]
        public HttpResponseMessage CreateList(string bid)
        {
            if(_repo.ContainsBoard(bid))
                return SetResponse(new  CreateListView(bid).AsHtmlContent());
            return SetResponse(HttpStatusCode.NotFound,new NotFoundView().AsHtmlContent());
        }

        //CREATE CARD PAGE
        [HttpMethod("GET", "/create/boards/{bid}/lists/{lid}/cards")]
        public HttpResponseMessage CreateCard(string bid, string lid)
        {
            if (_repo.ContainsBoard(bid) && _repo.ContainsList(bid,lid))
                return SetResponse( new CreateCardView(bid,lid).AsHtmlContent());
            return SetResponse(HttpStatusCode.NotFound, new NotFoundView().AsHtmlContent());
        }

        //EDIT BOARD
        [HttpMethod("GET", "/edit/boards/{bid}")]
        public HttpResponseMessage EditBoard(string bid)
        {
            var td = _repo.GetBoardById(bid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new NotFoundView().AsHtmlContent()) : SetResponse(new EditBoardView(td).AsHtmlContent());
        }

        //POST EDIT BOARD
        [HttpMethod("POST", "/edit/boards/{bid}")]
        public HttpResponseMessage PostEditBoard(NameValueCollection content,string bid)
        {
            var desc = content["desc"];

            if (!validParams(desc)){
                return SetResponse(HttpStatusCode.BadRequest, new MissingInfoView().AsHtmlContent());
            }

            var td = _repo.GetBoardById(bid);
            td.Description = desc;

            return SetResponse(HttpStatusCode.SeeOther, ResolveUri.SingleBoardUri(td));
        }

        //EDIT LIST
        [HttpMethod("GET", "/edit/boards/{bid}/lists/{lid}")]
        public HttpResponseMessage EditBoard(string bid, string lid)
        {
            var td = _repo.GetListById(bid, lid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new NotFoundView().AsHtmlContent()) : SetResponse(new EditListView(td, bid).AsHtmlContent());
        }

        //POST EDIT LIST
        [HttpMethod("POST", "/edit/boards/{bid}/lists/{lid}")]
        public HttpResponseMessage PostEditBoard(NameValueCollection content, string bid, string lid)
        {
            var desc = content["desc"];

            if (!validParams(desc)){
                return SetResponse(HttpStatusCode.BadRequest, new MissingInfoView().AsHtmlContent());
            }

            _repo.GetListById(bid, lid).Description = desc;

            return SetResponse(HttpStatusCode.SeeOther, ResolveUri.SingleListUri(bid, lid));
        }

        //EDIT CARD
        [HttpMethod("GET", "/edit/boards/{bid}/lists/{lid}/cards/{cid}")]
        public HttpResponseMessage EditCard(string bid, string lid, string cid)
        {
            var td = _repo.GetCardById(bid, cid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new NotFoundView().AsHtmlContent()) : SetResponse(new EditCardView(td, bid, lid).AsHtmlContent());
        }

        //POST EDIT CARD
        [HttpMethod("POST", "edit/boards/{bid}/lists/{lid}/cards/{cid}")]
        public HttpResponseMessage PostEditCard(NameValueCollection content, string bid, string lid, string cid)
        {
            var desc = content["desc"];
            var date = content["date"];

            if (!validParams(desc,date)){
                return SetResponse(HttpStatusCode.BadRequest, new MissingInfoView().AsHtmlContent());
            }

            _repo.UpdateCard(bid,lid,cid,desc,date);

            return SetResponse(HttpStatusCode.SeeOther, ResolveUri.SingleCardUri(bid, cid));
        }

        //MOVE PAGE
        [HttpMethod("GET", "/move")]
        public HttpResponseMessage Move()
        {
            return new HttpResponseMessage
            {
              //  Content = new TestView().AsHtmlContent()
            };
        }

        //REMOVE EMPTY LIST
        [HttpMethod("GET", "/remove/boards/{bid}/lists/{lid}")]
        public HttpResponseMessage Remove(string bid, string lid)
        {
            if(_repo.ContainsBoard(bid) && _repo.ContainsList(bid,lid) && !(_repo.GetListById(bid,lid).GetAllCards().Any()))
                return SetResponse(HttpStatusCode.SeeOther,ResolveUri.SingleBoardUri(bid));
            return SetResponse(HttpStatusCode.BadRequest, new InvalidOperationView("remove a list").AsHtmlContent());
        }

        //POST BOARD
        [HttpMethod("POST", "/create/boards")]
        public HttpResponseMessage PostBoard(NameValueCollection content)
        {
            var desc = content["desc"];
            var id = content["id"];

            if (!validParams(id,desc)){
                return SetResponse(HttpStatusCode.BadRequest, new MissingInfoView().AsHtmlContent());
            }
            if(!(_repo.AddBoard(id,desc))){
                return SetResponse(HttpStatusCode.BadRequest, new AlreadyExistsView("Board").AsHtmlContent());
            }

            return SetResponse(HttpStatusCode.SeeOther, ResolveUri.SingleBoardUri(id));
        }

        //POST LIST
        [HttpMethod("POST", "/create/boards/{bid}/lists")]
        public HttpResponseMessage PostBoard(NameValueCollection content,string bid)
        {
            var desc = content["desc"];
            var id = content["id"];

            if (!validParams(id,desc)){
                return SetResponse(HttpStatusCode.BadRequest, new MissingInfoView().AsHtmlContent());
            }
            if(!(_repo.GetBoardById(bid).AddList(id, desc)))
            {
                return SetResponse(HttpStatusCode.BadRequest, new AlreadyExistsView("List").AsHtmlContent());
            }

            return SetResponse(HttpStatusCode.SeeOther, ResolveUri.SingleListUri(bid, id));
        }

        //POST CARD
        [HttpMethod("POST", "/create/boards/{bid}/lists/{lid}/cards")]
        public HttpResponseMessage PostBoard(NameValueCollection content, string bid, string lid)
        {
            var desc = content["desc"];
            var id = content["id"];
            var date = content["date"];

            if (!validParams(desc,id,date))
            {
                return SetResponse(HttpStatusCode.BadRequest, new MissingInfoView().AsHtmlContent());
            }
            if(_repo.GetBoardById(bid).AddCard(id, desc, date, lid)){
                return SetResponse(HttpStatusCode.BadRequest, new AlreadyExistsView("Card").AsHtmlContent());
            }

            return SetResponse(HttpStatusCode.SeeOther, ResolveUri.SingleCardUri(bid, id));
        }

        private bool validParams(params string[] sp)
        {
            foreach (string s in sp)
            {
                if (s == null || s == "")
                    return false;
            }
            return true;
        }

        private HttpResponseMessage SetResponse(HttpStatusCode status, string uri)
        {
            var resp = new HttpResponseMessage(status);
            resp.Headers.Location = new Uri(uri);
            return resp;
        }

        private HttpResponseMessage SetResponse(HttpContent view)
        {
            return new HttpResponseMessage { Content = view };
        }

        private HttpResponseMessage SetResponse(HttpStatusCode status, HttpContent view)
        {
            return new HttpResponseMessage(status) { Content = view };
        }

    }
}
