<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	
	<script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
	<script src="/Scripts/main.js"></script>
</head>
<body>
	<div>
		<div id="data"></div>
		
		<form id="add" method="POST" action="/Home/Add">
			<input type="text" name="name" />
			<input type="text" name="points" />
			<input type="submit" id="addPeople" value="Get People" />
		</form>
	</div>
</body>

