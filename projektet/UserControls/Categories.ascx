<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Categories.ascx.cs" Inherits="UserControls_Categories" %>

<% foreach(CategoryItem c in CategoryManager.GetCategories()){ %>
        
    <a href="Product.aspx"><%= c.CategoryName %></a>
    <% foreach (CategoryItem cc in c.SubCategories){ %>
    <br />
       -<a href=""><%= cc.CategoryName %></a>
    <% } %>
    <br />
<%} %>