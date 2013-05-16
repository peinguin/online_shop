<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%
 if (Model != null)
{%> 
    <li><%= Model.Email %></li>
    <li><%= Html.ActionLink("Выход", "Logout", "Login") %></li>
<% }
else
{%> 
    <li><%= Html.ActionLink("Вход", "Index", "Login") %></li>
<%}%>
