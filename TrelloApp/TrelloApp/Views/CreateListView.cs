using TrelloApp.Models;
using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class CreateListView : HtmlDoc
    {
        public CreateListView(string bid)
            :base("Trello App",
                H1(Text("Create a new List")),
                Form("post","/create/boards/"+bid+"/lists",
                    Li(Label("id","Identification: ")),InputText("id"),
                    Li(Label("desc","Description: ")),InputText("desc"),
                    Li(InputSubmit("Submit"))
                    )
                ){}
    }
}
