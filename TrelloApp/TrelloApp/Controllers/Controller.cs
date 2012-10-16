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
            return new HttpResponseMessage
            {
                Content = new AllBoardsView(_repo.GetAll()).AsHtmlContent()
            };
        }

        //ONE BOARD
        [HttpMethod("GET", "/boards/{bid}")]
        public HttpResponseMessage GetSingleBoard(string bid)
        {
            var td = _repo.GetBoardById(bid);
            return td == null ? new HttpResponseMessage(HttpStatusCode.NotFound) :
                new HttpResponseMessage
                {
                    Content = new SingleBoardView(td).AsHtmlContent()
                };
        }

        //ONE LIST
        [HttpMethod("GET", "/boards/{bid}/lists/{lid}")]
        public HttpResponseMessage GetSingleList(string bid,string lid)
        {
            var td = _repo.GetListById(bid,lid);
            return td == null ? new HttpResponseMessage(HttpStatusCode.NotFound) :
                new HttpResponseMessage
                {
                    Content = new SingleListView(td,bid).AsHtmlContent()
                };
        }

        //ONE CARD
        [HttpMethod("GET", "/boards/{bid}/cards/{cid}")]
        public HttpResponseMessage GetSingleCard(string bid, string cid)
        {
            var td = _repo.GetCardById(bid, cid);
            return td == null ? new HttpResponseMessage(HttpStatusCode.NotFound) :
                new HttpResponseMessage
                {
                    Content = new SingleCardView(td, bid).AsHtmlContent()
                };
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
            return new HttpResponseMessage{
                Content = new RootView().AsHtmlContent()
            };
        }

        //CREATE BOARD PAGE
        [HttpMethod("GET", "/create/boards")]
        public HttpResponseMessage CreateBoard()
        {
            return new HttpResponseMessage
            {
                Content = new CreateBoardView().AsHtmlContent()
            };
        }

        //CREATE LIST PAGE
        [HttpMethod("GET", "/create/boards/{bid}/lists")]
        public HttpResponseMessage CreateList(string bid)
        {
            return new HttpResponseMessage
            {
                Content = new CreateListView(bid).AsHtmlContent()
            };
        }

        //CREATE CARD PAGE
        [HttpMethod("GET", "/create/boards/{bid}/lists/{lid}/cards")]
        public HttpResponseMessage CreateCard(string bid, string lid)
        {
            return new HttpResponseMessage
            {
                Content = new CreateCardView(bid,lid).AsHtmlContent()
            };
        }

        //EDIT BOARD
        [HttpMethod("GET", "/edit/boards/{bid}")]
        public HttpResponseMessage EditBoard(string bid)
        {
            var td = _repo.GetBoardById(bid);
            return td == null ? new HttpResponseMessage(HttpStatusCode.NotFound) :
                new HttpResponseMessage
                {
                    Content = new EditBoardView(td).AsHtmlContent()
                };
        }

        //POST EDIT BOARD
        [HttpMethod("POST", "/edit/boards/{bid}")]
        public HttpResponseMessage PostEditBoard(NameValueCollection content,string bid)
        {
            var desc = content["desc"];
            if (desc == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var td = _repo.GetBoardById(bid);
            td.Description = desc;
            var resp = new HttpResponseMessage(HttpStatusCode.SeeOther);
            resp.Headers.Location = new Uri(ResolveUri.SingleBoardUri(td));
            return resp;
        }

        //EDIT LIST
        [HttpMethod("GET", "/edit/boards/{bid}/lists/{lid}")]
        public HttpResponseMessage EditBoard(string bid, string lid)
        {
            var td = _repo.GetListById(bid, lid);
            return td == null ? new HttpResponseMessage(HttpStatusCode.NotFound) :
                new HttpResponseMessage
                {
                    Content = new EditListView(td,bid).AsHtmlContent()
                };
        }

        //POST EDIT LIST
        [HttpMethod("POST", "/edit/boards/{bid}/lists/{lid}")]
        public HttpResponseMessage PostEditBoard(NameValueCollection content, string bid, string lid)
        {
            var desc = content["desc"];
            if (desc == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            _repo.GetListById(bid, lid).Description = desc;
            var resp = new HttpResponseMessage(HttpStatusCode.SeeOther);
            resp.Headers.Location = new Uri(ResolveUri.SingleListUri(bid,lid));
            return resp;
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
        [HttpMethod("GET", "/move")]
        public HttpResponseMessage Remove()
        {
            return new HttpResponseMessage
            {
                //  Content = new TestView().AsHtmlContent()
            };
        }

        //POST BOARD
        [HttpMethod("POST", "/create/boards")]
        public HttpResponseMessage PostBoard(NameValueCollection content)
        {
            var desc = content["desc"];
            var id = content["id"];
            if (id == null || desc == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var td = new Board(id,desc);
            _repo.AddBoard(td);
            var resp = new HttpResponseMessage(HttpStatusCode.SeeOther);
            resp.Headers.Location = new Uri(ResolveUri.SingleBoardUri(td));
            return resp;
        }

        //POST LIST
        [HttpMethod("POST", "/create/boards/{bid}/lists")]
        public HttpResponseMessage PostBoard(NameValueCollection content,string bid)
        {
            var desc = content["desc"];
            var id = content["id"];
            if (id == null || desc == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var board = _repo.GetBoardById(bid);
            board.AddList(id, desc);
            var resp = new HttpResponseMessage(HttpStatusCode.SeeOther);
            resp.Headers.Location = new Uri(ResolveUri.SingleListUri(board.Id,id));
            return resp;
        }

        //POST CARD
        [HttpMethod("POST", "/create/boards/{bid}/lists/{lid}/cards")]
        public HttpResponseMessage PostBoard(NameValueCollection content, string bid, string lid)
        {
            var desc = content["desc"];
            var id = content["id"];
            var date = content["date"];
            if (id == null || desc == null || date == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var board = _repo.GetBoardById(bid);
            var card = new Card(id,desc);
            card.creationDate = DateTime.Today;
            card.dueDate = DateTime.Parse(date + " 00:00:00");
            card.listContainer = lid;
            board.AddCard(card);
            board.AddCardToList(card, lid);
            var resp = new HttpResponseMessage(HttpStatusCode.SeeOther);
            resp.Headers.Location = new Uri(ResolveUri.SingleCardUri(bid,id));
            return resp;
        }
    }
}
