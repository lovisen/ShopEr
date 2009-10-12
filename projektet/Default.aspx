<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="ShopEr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <h1>Erbjudande</h1>
            <br />
            <div style="padding:35px;"><img alt="sök" src="images/ipod.jpg" /><br />
            <asp:Button ID="Button1" runat="server" Text="Info" /><asp:Button ID="Button3" runat="server" Text="Köp" />
            </div>
</asp:Content>

