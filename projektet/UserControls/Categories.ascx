<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Categories.ascx.cs" Inherits="UserControls_Categories" %>

<% foreach(CategoryItem c in CategoryManager.GetCategories()){ %>
        
    <a href="<%= ResolveUrl("~/Product.aspx?Category=" + c.Id)%>"><%= c.CategoryName %></a>
    <% if (Request.QueryString["Category"] == c.Id.ToString())
       { %>
    <% foreach (CategoryItem cc in c.SubCategories)
       { %>
    <br />
       -<a href="<%= ResolveUrl("~/Product.aspx?Category=" + c.Id + "&SubCategory=" + cc.Id)%>"><%= cc.CategoryName%></a>
    <% }
       }%>
    
    <br />
<%} %>