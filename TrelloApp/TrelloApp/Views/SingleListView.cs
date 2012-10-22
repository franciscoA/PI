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
               checkRemove(list,bid),
               Ul(
                   list.GetAllCards().Cast<Card>().Select(td => Li(A(ResolveUri.SingleCardUri(bid, td.Id), td.Id))).ToArray()
               )
                ){ }

        private static IWritable checkRemove(List list,string bid)
        {
            if (list.GetAllCards().Cast<Card>().Any())
                return P(Text("Cant Remove - Have Cards"));
            else
                return Li(A(ResolveUri.Remove(bid,list.Id), "Remove List"));
        }

    }
}
