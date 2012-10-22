using TrelloApp.Models;
using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class SingleCardView : HtmlDoc
    {
        public SingleCardView(Card card)
            : base("TrelloApp",
               H1(Text("Card: " + card.Id)),
               P(Text("Description: " + card.Description)),
               P(Text("Creation Date: " + card.creationDate.ToString("d"))),
               P(Text("Due Date: " + card.dueDate.ToString("d"))),
               Li(A(ResolveUri.RootUri, "HomePage")),
               CheckedArchived(card)
               )
        { }

        private static IWritable CheckedArchived(Card card)
        {
            if (!card.archived)
            {
                return Ul(Li(A(ResolveUri.EditCard(card.boardContainer, card.listContainer, card.Id), "Edit")),
                Li(A(ResolveUri.Move(card.boardContainer, card.listContainer, card.Id), "Move")),
                Li(A(ResolveUri.Archived(card.boardContainer, card.Id), "Archive")),
                Li(A(ResolveUri.SingleBoardUri(card.boardContainer), "Return to Board: " + card.boardContainer)),
                Li(A(ResolveUri.SingleListUri(card.boardContainer, card.listContainer), "Return to List: " + card.listContainer)));
            }
            return P(Text("Archived"));
        }
    }
}
