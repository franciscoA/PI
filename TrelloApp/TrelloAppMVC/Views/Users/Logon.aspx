<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TrelloAppMVC.Models.User>" %>
<%@ Import Namespace="System.Web.Security" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Logon
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% TempData["url"] = ViewBag.url; %>
<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Logon</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.username) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.username) %>
            <%: Html.ValidationMessageFor(model => model.username) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.password) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.password) %>
            <%: Html.ValidationMessageFor(model => model.password) %>
        </div>

        <p>
            <input type="submit" value="Logon" />
        </p>
    </fieldset>
<% } %>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
   
</asp:Content>




