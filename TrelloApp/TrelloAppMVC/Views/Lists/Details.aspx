<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.List>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% TempData["bid"] = Model.bid; %>
<% TempData["lid"] = Model.lid; %>
<h2>Details</h2>

<fieldset>
    <legend>List</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.lid) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.lid) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.bid) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.bid) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.list_description) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.list_description) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.listPos) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.listPos) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Cards", "Index", "Cards")%> |
    <%: Html.ActionLink("Edit", "Edit", new { Model.lid,Model.bid }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
