<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.Board>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% TempData["bid"] = Model.bid; %>
<h2>Details</h2>

<fieldset>
    <legend>Board</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.bid) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.bid) %>
    </div>
    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.board_description) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.board_description) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Lists", "Index", "Lists")%> |
    <%: Html.ActionLink("Edit", "Edit", new { id=Model.bid }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
