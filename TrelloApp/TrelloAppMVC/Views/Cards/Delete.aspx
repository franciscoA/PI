<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.Card>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Card</legend>

     <div class="display-label">
        <%: Html.DisplayNameFor(model => model.cid) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.cid) %>
    </div>
   
    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.bid) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.bid) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.lid) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.lid) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.card_description) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.card_description) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.cardPos) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.cardPos) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.cdate) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.cdate) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.ddate) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ddate) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
