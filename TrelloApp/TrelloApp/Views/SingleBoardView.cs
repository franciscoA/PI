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
               P(Text("Description: "+board.Description)),
               Li(A(ResolveUri.RootUri,"HomePage")),
               Li(A(ResolveUri.AllBoardsUri,"Boards")),
               Li(A(ResolveUri.EditBoard(board.Id),"Edit")),
               Li(A(ResolveUri.CreateList(board.Id),"Create List")),
               Ul(
                   AllCardsByLists(board).ToArray()
               )
          ){ }

         //ALL CARDS BY LISTS PROCESSOR

         private static IEnumerable<IWritable> AllCardsByLists(Board b)
         {
             IEnumerable<List> lists = b.GetAllLists();
             foreach (List l in lists)
             {
                 yield return Li(A(ResolveUri.SingleListUri(b, l), l.Id));
                 yield return Ul(
                   l.GetAllCards().Select(td => Li(A(ResolveUri.SingleCardUri(b.Id, td.Id), td.Id))).ToArray()
                 );
             }
         }

        
    }
}
