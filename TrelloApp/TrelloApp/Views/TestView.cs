using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGarten2.Html;
using TrelloApp.Models;

namespace TrelloApp.Views
{
    class TestView : HtmlDoc
    {
        public TestView()
            : base("To Dos",
               H1(Text("To Do list"))
               ) { }
    }
}
