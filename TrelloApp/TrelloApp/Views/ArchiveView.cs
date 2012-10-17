using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebGarten2.Html;
using TrelloApp.Models;

namespace TrelloApp.Views
{
    class ArchiveView : HtmlDoc
    {
        public ArchiveView(IEnumerable<Card> enumCards)
            : base("TrelloApp",
            H1(Text("Archived Cards")),
            Ul(
                enumCards.Select(card => Li(A(ResolveUri.SingleCardUri(card.boardContainer, card.Id), card.Id))).ToArray()
            )

            ) { }
    }
}
