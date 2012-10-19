using TrelloApp.Models;
using System.Collections.Generic;
using System.Linq;
using WebGarten2.Html;

namespace TrelloApp
{
    static class ResolveUri
    {

        // SINGLE ELEMENTS URIS 

        public static string SingleBoardUri(Board b)
        {
            return SingleBoardUri(b.Id);
        }

        public static string SingleBoardUri(string b)
        {
            return string.Format("http://localhost:8080/boards/{0}", b);
        }

        public static string SingleListUri(string bid, string lid)
        {
            return string.Format("http://localhost:8080/boards/{0}/lists/{1}", bid, lid);
        }

        public static string SingleListUri(Board b, List l)
        {
            return SingleListUri(b.Id,l.Id);
        }

        public static string SingleCardUri(Board b, Card c)
        {
            return SingleCardUri(b.Id, c.Id);
        }

        public static string SingleCardUri(string b, string c)
        {
            return string.Format("http://localhost:8080/boards/{0}/cards/{1}", b, c);
        }

        //ROOT URI

        public const string RootUri = "http://localhost:8080/";

        //CREATION URIS 

        public const string CreateBoard = "http://localhost:8080/create/boards";

        public static string CreateList(string b)
        {
            return string.Format("http://localhost:8080/create/boards/{0}/lists", b);
        }

        public static string CreateCard(string b, string l)
        {
            return string.Format("http://localhost:8080/create/boards/{0}/lists/{1}/cards", b,l);
        }

        //ALL BOARDS URI (INCLUDES ALL LISTS AND ALL CARDS)

        public const string AllBoardsUri = "http://localhost:8080/boards";


        //EDITION URIS

        public static string EditBoard(string b)
        {
            return string.Format("http://localhost:8080/edit/boards/{0}", b);
        }

        public static string EditList(string b, string l)
        {
            return string.Format("http://localhost:8080/edit/boards/{0}/lists/{1}", b,l);
        }

        public static string EditCard(string b, string l, string c)
        {
            return string.Format("http://localhost:8080/edit/boards/{0}/lists/{1}/cards/{2}", b, l, c);
        }

        //MOVE URI

        public static string Move(string b, string l, string c)
        {
            return string.Format("http://localhost:8080/move/boards/{0}/lists/{1}/cards/{2}", b, l, c);
        }

        //ARCHIVE URIS

        public const string Archive ="http://localhost:8080/archive";

        public static string Archived(string b, string l, string c)
        {
            return string.Format("http://localhost:8080/archive/boards/{0}/list/{1}/cards/{2}", b, l, c);
        }

        //REMOVE

        public static string Remove(string b, string l)
        {
            return string.Format("http://localhost:8080/remove/boards/{0}/lists/{1}", b, l);
        }
        
    }
}
