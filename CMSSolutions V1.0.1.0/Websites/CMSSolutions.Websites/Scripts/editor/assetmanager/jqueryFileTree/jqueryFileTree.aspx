<%@ Page Language="C#" AutoEventWireup="true" %>

<%
	//
	// jQuery File Tree ASP Connector
	//
	// Version 1.0
	//
	// Copyright (c)2008 Andrew Sweeny
	// asweeny@fit.edu
	// 24 March 2008
	//
	string dir;
	if(Request.Form["dir"] == null || Request.Form["dir"].Length <= 0)
		dir = "/";
	else
		dir = Server.UrlDecode(Request.Form["dir"]);

    if (dir == null || dir.Length <= 0)
        dir = "/";
    else
        dir = Server.UrlDecode(dir);

    var path = Server.MapPath(dir);

    var di = new System.IO.DirectoryInfo(path);
	Response.Write("<ul class=\"jqueryFileTree\" style=\"display: none;\">\n");
	foreach (System.IO.DirectoryInfo diChild in di.GetDirectories())
		Response.Write("\t<li class=\"directory collapsed\"><a href=\"#\" rel=\"" + dir + diChild.Name + "/\">" + diChild.Name + "</a></li>\n");
	foreach (System.IO.FileInfo fi in di.GetFiles())
	{
		var ext = ""; 
		if(fi.Extension.Length > 1)
			ext = fi.Extension.Substring(1).ToLower();
			
		Response.Write("\t<li class=\"file ext_" + ext + "\"><a href=\"#\" rel=\"" + dir + fi.Name + "\">" + fi.Name + "</a></li>\n");		
	}
	Response.Write("</ul>");
 %>