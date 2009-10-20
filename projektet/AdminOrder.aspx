<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminOrder.aspx.cs" Inherits="AdminOrder" Title="ShopEr Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Orderhantering</h2>
<li style="padding:25px; margin-left:60px; list-style:none;"><asp:TextBox ID="txtSearch" runat="server" Height="23px" Width="263px"></asp:TextBox> 
        <asp:Button ID="btbSearch" runat="server" Text="SÖK ORDER" Height="28px" /></li>
    <b style="margin-left:65px; padding:25px;">Resultat:</b>
</asp:Content>

