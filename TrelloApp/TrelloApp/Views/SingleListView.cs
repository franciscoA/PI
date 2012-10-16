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
               P(Text("Description: "+list.Description)),
               Li(A(ResolveUri.RootUri,"HomePage")),
               Li(A(ResolveUri.CreateCard(bid,list.Id),"Create Card")),
               Li(A(ResolveUri.EditList(bid,list.Id),"Edit")),
               Li(A(ResolveUri.SingleBoardUri(bid),"Return to Board: "+bid)),
               Ul(
                   list.GetAllCards().Select(td => Li(A(ResolveUri.SingleCardUri(bid, td.Id), td.Id))).ToArray()
               )
                ){ }
    }
}
