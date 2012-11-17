<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.List>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Edit</h2>

<% TempData["bid"] = ViewBag.bid; %>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>List</legend>

        <%: Html.HiddenFor(model => model.lid) %>

        <%: Html.HiddenFor(model => model.bid) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.list_description) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.list_description) %>
            <%: Html.ValidationMessageFor(model => model.list_description) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.listPos) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.listPos) %>
            <%: Html.ValidationMessageFor(model => model.listPos) %>
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
