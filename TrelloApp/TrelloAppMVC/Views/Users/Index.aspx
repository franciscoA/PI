<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TrelloAppMVC.Models.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.name) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.password) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.role) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.email) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.active) %>
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.name) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.password) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.role) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.email) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.active) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.username }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.username }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.username }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
