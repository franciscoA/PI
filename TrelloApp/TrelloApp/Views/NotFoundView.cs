using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class NotFoundView : HtmlDoc
    {
        public NotFoundView()
            : base("TrelloApp",
               H1(Text("ERROR")),
               P(Text("The requested resource doesnt exist.")),
               A(ResolveUri.RootUri,"HomePage")
               ) { }
    }
}
