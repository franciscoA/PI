using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class MoveView : HtmlDoc
    {
        public MoveView(string bid, string lid, string cid)
            : base("TrelloApp",
            H1(Text("MoveCard")),
             Form("post", "/move/boards/" + bid+"/lists/"+lid+"/cards/"+cid,
                    Li(Label("list", "Destination List: ")), InputText("list"),
                    Li(Label("pos", "Destination Position: ")), InputText("pos"),
                    Li(InputSubmit("Submit"))
              )

            ) { }
    }
}
