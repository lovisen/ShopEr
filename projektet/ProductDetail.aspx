<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" Title="ShopEr Product Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="padding:35px;">

     <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
         
         <LayoutTemplate>
             <ul ID="itemPlaceholderContainer" runat="server" style="">
                 <li ID="itemPlaceholder" runat="server" />
                 </ul>
                 <div style="">
                 </div>
         </LayoutTemplate>
             
             
             <EmptyDataTemplate>
                 No data was returned.
             </EmptyDataTemplate>
             
             <ItemTemplate>
                 <li style="">Namn:
                     <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                     <br />
                     Beskrivning:
                     <asp:Label ID="DescriptionLabel" runat="server" 
                         Text='<%# Eval("Description") %>' />
                     <br />
                     Pris:
                     <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                     <br />
                     Images:
<%--                     <asp:Label ID="ImagesLabel" runat="server" Text='<%# Eval("Images") %>' />--%>
                      <%--<img src='images/Product/<%# Eval("Images[0].ImageURL") %>' alt="" style="padding: 20px;" />--%>
                     
                     <br />
                     Id:
                     <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                     <br />
                 </li>
             </ItemTemplate>
             <ItemSeparatorTemplate>
                 <br />
             </ItemSeparatorTemplate>
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

