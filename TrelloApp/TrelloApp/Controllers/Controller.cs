using System;
using System.Collections.Generic;
using System.Linq;
using WebGarten2;
using System.Net.Http;
using System.Net.Http.Headers;
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
            return SetResponse(HttpStatusCode.OK,new AllBoardsView(_repo.GetAll()).AsHtmlContent());
        }

        //ONE BOARD
        [HttpMethod("GET", "/boards/{bid}")]
        public HttpResponseMessage GetSingleBoard(string bid)
        {
            var td = _repo.GetBoardById(bid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new ErrorView("Oups, that resource doesnt exist.").AsHtmlContent())
                                : SetResponse(HttpStatusCode.OK, new SingleBoardView(td).AsHtmlContent());
        }

        //ONE LIST
        [HttpMethod("GET", "/boards/{bid}/lists/{lid}")]
        public HttpResponseMessage GetSingleList(string bid,string lid)
        {
            var td = _repo.GetListById(bid,lid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new ErrorView("Oups, that resource doesnt exist.").AsHtmlContent())
                                : SetResponse(HttpStatusCode.OK, new SingleListView(td, bid).AsHtmlContent());
        }

        //ONE CARD
        [HttpMethod("GET", "/boards/{bid}/cards/{cid}")]
        public HttpResponseMessage GetSingleCard(string bid, string cid)
        {
            var td = _repo.GetCardById(bid, cid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new ErrorView("Oups, that resource doesnt exist.").AsHtmlContent())
                                : SetResponse(HttpStatusCode.OK, new SingleCardView(td).AsHtmlContent());
        }

        //ARCHIVE
        [HttpMethod("GET", "/archive")]
        public HttpResponseMessage Archive()
        {
            return SetResponse(HttpStatusCode.OK, new ArchiveView(_repo.GetArchivedCards()).AsHtmlContent());
        }

        //ARCHIVED CARD PAGE
        [HttpMethod("GET", "/archive/boards/{bid}/cards/{cid}")]
        public HttpResponseMessage ArchiveCard(string bid, string cid)
        {
            if(!_repo.ArchiveCard(bid,cid))
            {
                return SetResponse(HttpStatusCode.OK, new ErrorView("Error archiving card. Board and/or card not existant.").AsHtmlContent());
            }

            return SetResponse(HttpStatusCode.OK, new SingleCardView(_repo.GetArchivedCardById(bid + "_" + cid)).AsHtmlContent());
        }

        //ROOT PAGE
        [HttpMethod("GET", "/")]
        public HttpResponseMessage GetRoot()
        {
            return SetResponse(HttpStatusCode.OK, new RootView().AsHtmlContent());
        }

        //CREATE BOARD PAGE
        [HttpMethod("GET", "/create/boards")]
        public HttpResponseMessage CreateBoard()
        {
            return SetResponse(HttpStatusCode.OK, new CreateBoardView().AsHtmlContent());
        }

        //CREATE LIST PAGE
        [HttpMethod("GET", "/create/boards/{bid}/lists")]
        public HttpResponseMessage CreateList(string bid)
        {
            if(_repo.ContainsBoard(bid))
                return SetResponse(HttpStatusCode.OK, new CreateListView(bid).AsHtmlContent());
            return SetResponse(HttpStatusCode.NotFound, new ErrorView("Oups, that resource doesnt exist.").AsHtmlContent());
        }

        //CREATE CARD PAGE
        [HttpMethod("GET", "/create/boards/{bid}/lists/{lid}/cards")]
        public HttpResponseMessage CreateCard(string bid, string lid)
        {
            if (_repo.ContainsBoard(bid) && _repo.ContainsList(bid,lid))
                return SetResponse(HttpStatusCode.OK, new CreateCardView(bid, lid).AsHtmlContent());
            return SetResponse(HttpStatusCode.NotFound, new ErrorView("Oups, that resource doesnt exist.").AsHtmlContent());
        }

        //EDIT BOARD
        [HttpMethod("GET", "/edit/boards/{bid}")]
        public HttpResponseMessage EditBoard(string bid)
        {
            var td = _repo.GetBoardById(bid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new ErrorView("Oups, that resource doesnt exist.").AsHtmlContent())
                            : SetResponse(HttpStatusCode.OK, new EditBoardView(td).AsHtmlContent());
        }

        //POST EDIT BOARD
        [HttpMethod("POST", "/edit/boards/{bid}")]
        public HttpResponseMessage PostEditBoard(NameValueCollection content,string bid)
        {
            var desc = content["desc"];

            if (!validParams(desc)){
                return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, some information is missing").AsHtmlContent());
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
            return td == null ? SetResponse(HttpStatusCode.NotFound, new ErrorView("Oups, that resource doesnt exist.").AsHtmlContent())
                            : SetResponse(HttpStatusCode.OK, new EditListView(td, bid).AsHtmlContent());
        }

        //POST EDIT LIST
        [HttpMethod("POST", "/edit/boards/{bid}/lists/{lid}")]
        public HttpResponseMessage PostEditBoard(NameValueCollection content, string bid, string lid)
        {
            var desc = content["desc"];

            if (!validParams(desc)){
                return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, some information is missing").AsHtmlContent());
            }

            _repo.GetListById(bid, lid).Description = desc;

            return SetResponse(HttpStatusCode.SeeOther, ResolveUri.SingleListUri(bid, lid));
        }

        //EDIT CARD
        [HttpMethod("GET", "/edit/boards/{bid}/lists/{lid}/cards/{cid}")]
        public HttpResponseMessage EditCard(string bid, string lid, string cid)
        {
            var td = _repo.GetCardById(bid, cid);
            return td == null ? SetResponse(HttpStatusCode.NotFound, new ErrorView("Oups, that resource doesnt exist.").AsHtmlContent())
                                : SetResponse(HttpStatusCode.OK, new EditCardView(td, bid, lid).AsHtmlContent());
        }

        //POST EDIT CARD
        [HttpMethod("POST", "edit/boards/{bid}/lists/{lid}/cards/{cid}")]
        public HttpResponseMessage PostEditCard(NameValueCollection content, string bid, string lid, string cid)
        {
            var desc = content["desc"];
            var date = content["date"];

            if (!validParams(desc,date)){
                return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, some information is missing").AsHtmlContent());
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
            return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, sorry but you cant remove that list. Try to archive all cards firt.").AsHtmlContent());
        }

        //POST BOARD
        [HttpMethod("POST", "/create/boards")]
        public HttpResponseMessage PostBoard(NameValueCollection content)
        {
            var desc = content["desc"];
            var id = content["id"];

            if (!validParams(id,desc)){
                return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, some information is missing").AsHtmlContent());
            }
            if(!(_repo.AddBoard(id,desc))){
                return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, that board already exists.").AsHtmlContent());
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
                return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, some information is missing").AsHtmlContent());
            }
            if(!(_repo.GetBoardById(bid).AddList(id, desc)))
            {
                return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, that list already exists.").AsHtmlContent());
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
                return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, some information is missing").AsHtmlContent());
            }
            if(_repo.GetBoardById(bid).AddCard(id, desc, date, lid)){
                return SetResponse(HttpStatusCode.BadRequest, new ErrorView("Oups, that card already exists.").AsHtmlContent());
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

        private HttpResponseMessage SetResponse(HttpStatusCode status, HttpContent view)
        {
            HttpResponseMessage resp = new HttpResponseMessage(status) { Content = view };
           // AddResponseHeaders(resp.Content);
            return resp;
        }

   /*     private void AddResponseHeaders(HttpContent respContent)
        {
            respContent.Headers.Add("Last-Modified", DateTime.Today.ToString());
        }*/
    }
}
