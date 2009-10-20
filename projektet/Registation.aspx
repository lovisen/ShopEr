<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registation.aspx.cs" Inherits="Registation" Title="ShopEr Reiestration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 62%;
        }
        .style2
        {
            width: 118px;
        }
        .style3
        {
            width: 116px;
        }
        .style4
        {
            width: 115px;
        }
        .style5
        {
            width: 73px;
        }
        .style6
        {
            width: 326px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<h1>Registera dig här!</h1>
    <table class="style1" style="padding:20px;" cellpadding="50px">
        <tr>
            <td class="style5">
                    <asp:Label ID="lblForName" runat="server" Text="Namn:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="TextBox3" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblLastName" runat="server" Text="Efternamn:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="TextBox4" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                    <asp:Label ID="lblPersNr" runat="server" Text="Personnr:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="TextBox5" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblAdress" runat="server" Text="Adress:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="TextBox6" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblPostNr" runat="server" Text="Postnr:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="TextBox7" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblStad" runat="server" Text="Ort:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="TextBox8" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblCountry" runat="server" Text="Land:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="TextBox9" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                    <asp:Label ID="lblTele" runat="server" Text="Telefon:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="TextBox10" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblMobil" runat="server" Text="Mobil"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="TextBox11" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblEpost" runat="server" Text="E-post:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtEpost" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                    <asp:Label ID="lblPassword" runat="server" Text="Lösenord:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtPassword" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                <asp:Button ID="Button3" runat="server" Text="Registrera" />
            </td>
        </tr>
    </table>
</asp:Content>

