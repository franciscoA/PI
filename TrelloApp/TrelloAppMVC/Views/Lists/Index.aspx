<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcDemo.Models.List>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% TempData["bid"] = ViewBag.bid; %>
<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.list_description) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.listPos) %>
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.list_description) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.listPos) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { item.lid,item.bid}) %> |
            <%: Html.ActionLink("Details", "Details", new { item.lid,item.bid}) %> |
            <%: Html.ActionLink("Delete", "Delete", new { item.lid,item.bid}) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
