<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<MvcDemo.Models.Board>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Board</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.bid) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.bid) %>
            <%: Html.ValidationMessageFor(model => model.bid) %>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.board_description) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.board_description) %>
            <%: Html.ValidationMessageFor(model => model.board_description) %>
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
