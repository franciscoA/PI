using WebGarten2.Html;

namespace TrelloApp.Views
{
    class RootView : HtmlDoc
    {
         public RootView()
            : base("TrelloApp",
               H1(Text("Welcome")),
               Li(A(ResolveUri.AllBoardsUri,"Boards")),
               Li(A(ResolveUri.Archive, "Archive"))
               ) { }
    }
}
