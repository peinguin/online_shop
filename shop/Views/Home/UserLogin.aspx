<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%
 if (Model != null)
{%> 
    <li><%= Model.Email %></li>
    <li><%= Html.ActionLink("Выход", "Logout", "Login") %></li>
    <% if (Model.InRoles("admin"))
       { %>
       <li><%= Html.ActionLink("Categories", "Categories", "Admin") %></li>
    <% } %>
<% }
else
{%> 
    <li><%= Html.ActionLink("Вход", "Index", "Login") %></li>
<%}%>
