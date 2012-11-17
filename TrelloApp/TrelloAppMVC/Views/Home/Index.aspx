<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page - My ASP.NET MVC Application
</asp:Content>

<asp:Content ID="indexFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Home Page.</h1>
            </hgroup>
            <p>
                Trello App MVC 
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>What is trello?:</h3>
    <ol class="round">
        <li class="one">
            <h5>Create Boards</h5>
            Blablabla boards
        </li>

        <li class="two">
            <h5>Fill them with Lists</h5>
            Blablabla lists
        </li>

        <li class="three">
            <h5>Manage your Cards</h5>
            Blablabla cards
        </li>
    </ol>
</asp:Content>
