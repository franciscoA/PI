<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<TrelloAppMVC.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>User</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.name) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.name) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.password) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.password) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.role) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.role) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.email) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.email) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.active) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.active) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.username }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
