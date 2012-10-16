using TrelloApp.Models;
using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class EditListView : HtmlDoc
    {
        public EditListView(List list, string bid)
            : base("TrelloApp",
               H1(Text("List: "+list.Id)),
               P(Text("Description: "+list.Description)),
               H2(Text("Edit List")),
                Form("post", "/edit/boards/"+bid+"/lists/"+list.Id,
                    Li(Label("desc", "Description: ")), InputText("desc"),
                    Li(InputSubmit("Submit"))
                    )
                ){ }
    }
}
