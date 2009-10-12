<%@ Page Language="VB" MasterPageFile="~/Admin.master" AutoEventWireup="false" CodeFile="Adminproduct.aspx.vb" Inherits="Adminproduct" title="AdminProdukt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 66px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Produkthantering:</h2>
    <table class="style1" 
        
        style="padding: 50px; border-style: dotted; border-width: 2px; width: 600px; margin-left: 100px; margin-top: 50px;" 
        title="Produkthantering">
        <tr>
            <td dir="ltr">
                <asp:Label ID="Label1" runat="server" Text="Produkt namn:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Kategori:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Beskrivning:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="134px" TextMode="MultiLine" 
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Välj bild:</td>
            <td class="style2">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnInsertProduct" runat="server" Text="Lägg till produkt" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br /><br />
    <li style="padding:25px; margin-left:60px; list-style:none;"><asp:TextBox ID="txtSearch" runat="server" Height="23px" Width="263px"></asp:TextBox> 
        <asp:Button ID="btbSearch" runat="server" Text="SÖK PRODUKT" Height="28px" /></li>
    <b style="margin-left:65px; padding:25px;">Resultat:</b>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>

