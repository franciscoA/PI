<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.Card>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Move
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Move</h2>

<% TempData["bid"] = ViewBag.bid; %>

<% using (Html.BeginForm()) { %>
     <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Destination</legend>

        <%: Html.HiddenFor(model => model.cdate) %>
        <%: Html.HiddenFor(model => model.ddate) %>
        <%: Html.HiddenFor(model => model.card_description) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.lid) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.lid) %>
            <%: Html.ValidationMessageFor(model => model.lid) %>
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
