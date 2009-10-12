<%@ Page Language="VB" MasterPageFile="~/ShopErMaster.master" AutoEventWireup="false" CodeFile="Order.aspx.vb" Inherits="Order" title="ShopEr Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 307px;
        }
        .style4
        {
            width: 308px;
        }
        .style5
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <a href="#" style="color:Green">Ange rabattkod</a><br /><br />
<h1>Personuppgifter</h1> 
        <style="background-color: #CCFFCC" />
    <table bgcolor="#CCFFCC" class="style2" width="650px;">
        <tr>
            <td>
                Personnummer:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Förnamn:</td>
            <td>
                Efternamn:</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Gatuadress:</td>
            <td>
                c/o</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Postnummer:</td>
            <td>
                Ort:</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox10" runat="server" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Mobilnummer:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                SMS-avisering sker till ovan nummer.</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
<br />

    <table class="style2">
        <tr bgcolor="#CCCCCC">
            <td>
                <b>Titel</b></td>
            <td>
                <b>Antal</b></td>
            <td>
                <b>á pris</b></td>
            <td>
                <b>Summa</b></td>
        </tr>
        <tr>
            <td class="style5">
                Produkt</td>
            <td class="style5">
                1</td>
            <td class="style5">
                100kr</td>
            <td class="style5">
                100kr</td>
        </tr>
        <tr>
            <td class="style5">
            </td>
            <td class="style5">
            </td>
            <td class="style5">
            </td>
            <td class="style5">
                Frakt 29kr</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr bgcolor="Silver">
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <b>Totalt 129kr</b></td>
        </tr>

    </table>
    <br />
    <h2>Betalningsalternativ:</h2>
    <a href="#" style="color:Red">Faktura</a>/
    <a href="#" style="color:Red">Delbetalning</a>/
    <a href="#" style="color:Red">Betal-/Kreditkort</a>
    <br /><br /><br /><br />
    <a href="#"><img src="images/order-abort.gif" border="0" /></a>
    <a href="#"><img src="images/order-confirm.gif" border="0" 
        style="float: right" /></a>
  
</asp:Content>

