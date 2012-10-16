using TrelloApp.Models;
using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class EditBoardView : HtmlDoc
    {
        public EditBoardView(Board board)
            : base("TrelloApp",
               H1(Text("Board: "+board.Id)),
               P(Text("Description: "+board.Description)),
               H2(Text("Edit Board")),
                Form("post", "/edit/boards/"+board.Id,
                    Li(Label("desc", "Description: ")), InputText("desc"),
                    Li(InputSubmit("Submit"))
                    )
                ){ }
    }
}
