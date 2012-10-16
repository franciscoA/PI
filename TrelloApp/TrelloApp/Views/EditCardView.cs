using TrelloApp.Models;
using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class EditCardView : HtmlDoc
    {
        public EditCardView(Card card, string bid, string lid)
            : base("TrelloApp",
              H1(Text("Card: " + card.Id)),
              P(Text("Description: " + card.Description)),
              P(Text("Creation Date: " + card.creationDate.ToString("d"))),
              P(Text("Due Date: " + card.dueDate.ToString("d"))),
              H2(Text("Edit Card")),
               Form("post", "/edit/boards/" + bid + "/lists/"+ lid + "/cards/" + card.Id,
                    Li(Label("desc", "Description: ")), InputText("desc"),
                    Li(Label("date", "DueDate (dd/mm/yyyy): ")), InputText("date"),
                    Li(InputSubmit("Submit"))
                   )
               ) { }
    }
}
