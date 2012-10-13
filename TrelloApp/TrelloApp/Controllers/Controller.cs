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
        public HttpResponseMessage GetSingleCard(int bid,int cid)
        {
            return new HttpResponseMessage
            {
                Content = new TestView().AsHtmlContent()
            };
        }

        //ARCHIVE
        [HttpMethod("GET", "/archive/boards/{bid}/cards/{cid}")]
        public HttpResponseMessage ArchiveCard(int bid,int cid)
        {
            return new HttpResponseMessage
            {
                Content = new TestView().AsHtmlContent()
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

        //CREATE PAGE
        [HttpMethod("GET", "/create")]
        public HttpResponseMessage Create()
        {
            return new HttpResponseMessage
            {
                Content = new TestView().AsHtmlContent()
            };
        }

        //EDIT PAGE
        [HttpMethod("GET", "/edit")]
        public HttpResponseMessage Edit()
        {
            return new HttpResponseMessage
            {
                Content = new TestView().AsHtmlContent()
            };
        }

        //MOVE PAGE
        [HttpMethod("GET", "/move")]
        public HttpResponseMessage Move()
        {
            return new HttpResponseMessage
            {
                Content = new TestView().AsHtmlContent()
            };
        }

        //POST BOARD
        [HttpMethod("POST", "/boards")]
        public HttpResponseMessage PostBoard(NameValueCollection content)
        {

            var id = content["id"];
            if (id == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            var td = new Board(id);
            _repo.AddBoard(td);
            var resp = new HttpResponseMessage(HttpStatusCode.SeeOther);
            resp.Headers.Location = new Uri(ResolveUri.SingleBoardUri(td));
            return resp;
        }
    }
}
