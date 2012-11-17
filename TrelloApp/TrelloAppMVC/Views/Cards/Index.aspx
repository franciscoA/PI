<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcDemo.Models.Card>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% TempData["bid"] = ViewBag.bid; %>
    <% TempData["lid"] = ViewBag.lid; %>
<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.card_description) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.cardPos) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.cdate) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.ddate) %>
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.card_description) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.cardPos) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.cdate) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.ddate) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { item.cid,item.bid}) %> |
            <%: Html.ActionLink("Details", "Details", new { item.cid,item.bid}) %> |
            <%: Html.ActionLink("Delete", "Delete", new { item.cid,item.bid}) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
