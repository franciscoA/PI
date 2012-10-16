using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class AlreadyExistsView : HtmlDoc
    {
        public AlreadyExistsView(string element)
            : base("TrelloApp",
               H1(Text("ERROR")),
               P(Text("That "+element+" already exists. Please choose a diferent identifier.")),
               A(ResolveUri.RootUri,"HomePage")
               ) { }
    }
}
