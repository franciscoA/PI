using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrelloApp.Models;

namespace TrelloApp.Views
{
    class AllBoardsView :HtmlDoc
    {
         public AllBoardsView(IEnumerable<Board> t)
            : base("TrelloApp",
               H1(Text("Boards")),
               Ul(
                   t.Select(td => Li(A(ResolveUri.SingleBoardUri(td), td.Id))).ToArray()
                   ),
                A(ResolveUri.RootUri,"HomePage"),
                A(ResolveUri.CreateBoard,"Create Board")
                ){ }
    }
}
