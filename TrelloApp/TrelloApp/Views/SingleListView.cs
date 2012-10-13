using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebGarten2.Html;
using TrelloApp.Models;

namespace TrelloApp.Views
{
    class SingleListView : HtmlDoc
    {
        public SingleListView(List list,string bid)
            : base("TrelloApp",
               H1(Text("List: "+list.Id)),
               A(ResolveUri.RootUri,"HomePage"),
               A(ResolveUri.CreateCard,"Create Card"),
               A(ResolveUri.EditList,"Edit"),
               A(ResolveUri.MoveList,"Move"),
               A(ResolveUri.SingleBoardUri(bid),"Return to Board: "+bid),
               Ul(
                   list.GetAllCards().Select(td => Li(A(ResolveUri.SingleCardUri(bid, td.Id), td.Id))).ToArray()
               )
                ){ }
    }
}
