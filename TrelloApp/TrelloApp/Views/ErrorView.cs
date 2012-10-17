using WebGarten2.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrelloApp.Views
{
    class ErrorView : HtmlDoc
    {
        public ErrorView(string desc)
            : base("TrelloApp",
               H1(Text("ERROR")),
               P(Text(desc))
               ) { }
    }
}
