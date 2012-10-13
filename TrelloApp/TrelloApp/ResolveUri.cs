using TrelloApp.Models;

namespace TrelloApp
{
    static class ResolveUri
    {
        public static string SingleBoardUri(Board b)
        {
            return SingleBoardUri(b.Id);
        }

        public static string SingleBoardUri(string b)
        {
            return string.Format("http://localhost:8080/boards/{0}", b);
        }

        public static string SingleListUri(Board b, List l)
        {
            return string.Format("http://localhost:8080/boards/{0}/lists/{1}", b.Id, l.Id);
        }

        public static string SingleCardUri(Board b, Card c)
        {
            return SingleCardUri(b.Id, c.Id);
        }

        public static string SingleCardUri(string b, string c)
        {
            return string.Format("http://localhost:8080/boards/{0}/cards/{1}", b, c);
        }

        public const string RootUri = "http://localhost:8080/";

        public const string CreateBoard = "http://localhost:8080/create/board";

        public const string AllBoardsUri = "http://localhost:8080/boards";

        public const string EditBoard = "http://localhost:8080/edit/board";

        public const string EditList = "http://localhost:8080/edit/list";

        public const string CreateList = "http://localhost:8080/create/list";

        public const string CreateCard = "http://localhost:8080/create/card";

        public const string MoveList = "http://localhost:8080/move/list";
    }
}
