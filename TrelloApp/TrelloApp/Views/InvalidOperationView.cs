using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class InvalidOperationView : HtmlDoc
    {
        public InvalidOperationView(string action)
            : base("TrelloApp",
               H1(Text("ERROR")),
               P(Text("Oups! Sorry, but your request to "+action+" wasnt sucessfull.")),
               A(ResolveUri.RootUri,"HomePage")
               ) { }
    }
}
