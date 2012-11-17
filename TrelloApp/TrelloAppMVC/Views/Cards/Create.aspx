<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.Card>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% TempData["bid"] = ViewBag.bid; %>
    <% TempData["lid"] = ViewBag.lid; %>
<h2>Create</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Card</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.cid) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.cid) %>
            <%: Html.ValidationMessageFor(model => model.cid) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.card_description) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.card_description) %>
            <%: Html.ValidationMessageFor(model => model.card_description) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ddate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ddate) %>
            <%: Html.ValidationMessageFor(model => model.ddate) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
