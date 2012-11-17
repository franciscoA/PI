<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.Card>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<% TempData["bid"] = ViewBag.bid; %>
<% TempData["lid"] = ViewBag.lid; %>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Card</legend>

        <%: Html.HiddenFor(model => model.cid) %>

        <%: Html.HiddenFor(model => model.lid) %>

        <%: Html.HiddenFor(model => model.bid) %>

        <%: Html.HiddenFor(model => model.cdate) %>
        

        <div class="editor-label">
            <%: Html.LabelFor(model => model.card_description) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.card_description) %>
            <%: Html.ValidationMessageFor(model => model.card_description) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.cardPos) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.cardPos) %>
            <%: Html.ValidationMessageFor(model => model.cardPos) %>
        </div>

      
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ddate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ddate) %>
            <%: Html.ValidationMessageFor(model => model.ddate) %>
        </div>

        <p>
            <input type="submit" value="Save" />
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
