<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.Card>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

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

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.archived) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.archived) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Archive", "Archive", new { Model.cid,Model.bid}) %> |
    <%: Html.ActionLink("Move", "Move", new { Model.cid,Model.bid}) %> |
    <%: Html.ActionLink("Edit", "Edit", new { Model.cid,Model.bid}) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
