using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class MissingInfoView : HtmlDoc
    {
        public MissingInfoView()
            : base("TrelloApp",
               H1(Text("ERROR")),
               P(Text("One or more parameters are empy, please purchase all info.")),
               A(ResolveUri.RootUri,"HomePage")
               ) { }
    }
}
