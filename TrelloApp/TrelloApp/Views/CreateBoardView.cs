using TrelloApp.Models;
using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class CreateBoardView : HtmlDoc
    {
        public CreateBoardView()
            :base("Trello App",
                H1(Text("Create a new Board")),
                Form("post","/create/boards",
                    Li(Label("id","Identification: ")),InputText("id"),
                    Li(Label("desc","Description: ")),InputText("desc"),
                    Li(InputSubmit("Submit"))
                    )
                ){}
    }
}
