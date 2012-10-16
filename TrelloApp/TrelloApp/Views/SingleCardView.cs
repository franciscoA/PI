using TrelloApp.Models;
using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class SingleCardView : HtmlDoc
    {
        public SingleCardView(Card card, string bid)
            : base("TrelloApp",
               H1(Text("Card: " + card.Id)),
               P(Text("Description: " + card.Description)),
               P(Text("Creation Date: " + card.creationDate.ToString("d"))),
               P(Text("Due Date: " + card.dueDate.ToString("d"))),
               Li(A(ResolveUri.RootUri, "HomePage")),
               Li(A(ResolveUri.EditCard(bid,card.listContainer,card.Id), "Edit")),
               Li(A(ResolveUri.Move(bid,card.listContainer,card.Id), "Move")),
               Li(A(ResolveUri.Archive(bid,card.listContainer,card.Id), "Archive")),
               Li(A(ResolveUri.SingleBoardUri(bid), "Return to Board: "+bid)),
               Li(A(ResolveUri.SingleListUri(bid,card.listContainer), "Return to List: "+card.listContainer))

                ) { }

    }
}
