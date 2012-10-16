using TrelloApp.Models;
using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class CreateCardView : HtmlDoc
    {
        public CreateCardView(string bid, string lid)
            :base("Trello App",
                H1(Text("Create a new Card")),
                Form("post","/create/boards/"+bid+"/lists/"+lid+"/cards",
                    Li(Label("id","Identification: ")),InputText("id"),
                    Li(Label("desc","Description: ")),InputText("desc"),
                    Li(Label("date", "DueDate (dd/mm/yyyy): ")), InputText("date"),
                    Li(InputSubmit("Submit"))
                    )
                ){}
    }
}
