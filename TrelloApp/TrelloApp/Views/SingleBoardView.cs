using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrelloApp.Models;
using WebGarten2.Html;

namespace TrelloApp.Views
{
    class SingleBoardView : HtmlDoc
    {
         public SingleBoardView(Board board)
            : base("TrelloApp",
               H1(Text("Board: "+board.Id)),
               A(ResolveUri.RootUri,"HomePage"),
               A(ResolveUri.AllBoardsUri,"Boards"),
               A(ResolveUri.EditBoard,"Edit"),
               A(ResolveUri.CreateList,"Create List"),
               Ul(
                   board.GetAllLists().Select(td => Li(A(ResolveUri.SingleListUri(board,td), td.Id))).ToArray()
               ),
               Ul(
                   board.GetAllCards().Select(td => Li(A(ResolveUri.SingleCardUri(board, td), td.Id))).ToArray()
               )
                ){ }
    }
}
