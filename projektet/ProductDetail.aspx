<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" Title="ShopEr Product Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="padding:35px;">

     <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
     </asp:ListView>
     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
         SelectMethod="GetProductById" TypeName="ProductManager">
         <SelectParameters>
             <asp:QueryStringParameter DefaultValue="0" Name="id" QueryStringField="product" 
                 Type="Int32" />
         </SelectParameters>
     </asp:ObjectDataSource>
     
 </div>
</asp:Content>

