<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%
 if (Model != null)
{%> 
    <li><a href="javascript:;"><%= Model.Email %></a></li>
    <li><%= Html.ActionLink("Logout", "Logout", "Login")%></li>
    <% if (Model.InRoles("admin"))
       { %>
       <li><%= Html.ActionLink("Categories", "Categories", "Admin") %></li>
       <li><%= Html.ActionLink("Products", "Products", "Admin")%></li>
    <% } %>
<% }
else
{%> 
    <li><%= Html.ActionLink("Вход", "Index", "Login") %></li>
<%}%>
