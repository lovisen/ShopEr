<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AccountDetails.aspx.cs" Inherits="AccountDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
<asp:ObjectDataSource ID="ODSCountry" runat="server" 
        SelectMethod="GetAllCountries" TypeName="CountryManager">
    </asp:ObjectDataSource>
    <asp:Label ID="lblForName" runat="server" Text="Namn:"></asp:Label><br />
    <asp:TextBox ID="txtForName" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Label ID="lblLastName" runat="server" Text="Efternamn:"></asp:Label><br />
    <asp:TextBox ID="txtSurName" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Label ID="lblPersNr" runat="server" Text="Personnr:"></asp:Label><br />
    <asp:TextBox ID="txtSocialNumber" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Label ID="lblAdress" runat="server" Text="Adress:"></asp:Label><br />
    <asp:TextBox ID="txtAddress" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Label ID="lblPostNr" runat="server" Text="Postnr:"></asp:Label><br />
    <asp:TextBox ID="txtPostNumber" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Label ID="lblCountry" runat="server" Text="Land:"></asp:Label><br />
    <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="ODSCountry" DataTextField="CountryName"
        DataValueField="Id" Height="28px" Width="258px">
    </asp:DropDownList><br />
    <asp:Label ID="lblStad" runat="server" Text="Ort:"></asp:Label><br />
    <asp:TextBox ID="txtCity" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Label ID="lblTele" runat="server" Text="Telefon:"></asp:Label><br />
    <asp:TextBox ID="txtTelephone" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Label ID="lblMobil" runat="server" Text="Mobil"></asp:Label><br />
    <asp:TextBox ID="txtMobile" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Label ID="lblEpost" runat="server" Text="E-post:"></asp:Label><br />
    <asp:TextBox ID="txtEpost" runat="server" Width="260px"></asp:TextBox><br />
    
    <asp:Button ID="btnSubmit" runat="server" Text="Ändra Uppgifter" OnClick="btnSubmit_Click" /><br />
    <br /><br />
    <asp:Label ID="Llblasdasd" runat="server" Text="Om du vill byta lösenord: "></asp:Label><br />
    <asp:Label ID="lblPassword" runat="server" Text="Nytt Lösenord:"></asp:Label><br />
    <asp:TextBox ID="txtPassword" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Label ID="Label1" runat="server" Text="Repetera Nytt Lösenord:"></asp:Label><br />
    <asp:TextBox ID="txtPassword2" runat="server" Width="260px"></asp:TextBox><br />
    <asp:Button ID="btnChangePassword" runat="server" Text="Ändra Lösenord" 
        onclick="btnChangePassword_Click" /><br />
</asp:Content>
