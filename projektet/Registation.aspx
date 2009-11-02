<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registation.aspx.cs" Inherits="Registation" Title="ShopEr Reiestration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 62%;
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
<h1>Registera dig här!<asp:ObjectDataSource ID="ODSCountry" runat="server" 
        SelectMethod="GetAllCountries" TypeName="CountryManager">
    </asp:ObjectDataSource>
    </h1>
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="#FF3300"></asp:Label>
    <table class="style1" style="padding:20px;" cellpadding="50px">
        <tr>
            <td class="style5">
                    <asp:Label ID="lblForName" runat="server" Text="Namn:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtForName" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblLastName" runat="server" Text="Efternamn:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtSurName" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                    <asp:Label ID="lblPersNr" runat="server" Text="Personnr:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtSocialNumber" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblAdress" runat="server" Text="Adress:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtAddress" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblPostNr" runat="server" Text="Postnr:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtPostNumber" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblCountry" runat="server" Text="Land:"></asp:Label></td>
            <td class="style6">
                <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="ODSCountry" 
                    DataTextField="CountryName" DataValueField="Id" Height="28px" Width="258px">
                </asp:DropDownList>
            </td>
        </tr>        
        <tr>
            <td class="style5">
                <asp:Label ID="lblStad" runat="server" Text="Ort:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtCity" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                    <asp:Label ID="lblTele" runat="server" Text="Telefon:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtTelephone" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblMobil" runat="server" Text="Mobil"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtMobile" runat="server" Width="260px"></asp:TextBox>
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
                    <asp:Label ID="Label1" runat="server" Text="Repetera Lösenord:"></asp:Label></td>
            <td class="style6">
                <asp:TextBox ID="txtPassword2" runat="server" Width="260px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                    <asp:Label ID="Label2" runat="server" Text="Jag vill ha nyhetsbrev"></asp:Label></td>
            <td class="style6">
                    <asp:CheckBox ID="chbNewsLetter" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style6">
                <asp:Button ID="btnSubmit" runat="server" Text="Registrera" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

