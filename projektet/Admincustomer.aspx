<%@ Page Language="VB" MasterPageFile="~/Admin.master" AutoEventWireup="false" CodeFile="Admincustomer.aspx.vb" Inherits="Admincustomer" title="Admin Kundhantering" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            border-style: solid;
            border-width: 1px;
            background-color: #FFFFCC;
        }
        .style2
        {
            height: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Kundhantering</h2>
<li style="padding:25px; margin-left:60px; list-style:none;">
    <table class="style1" style="padding: 20px; border-style: dotted; border-width: 2px; width: 600px;">
        <tr>
            <td>
                <asp:Label ID="name" runat="server" Text="Namn:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="241px"></asp:TextBox>
            </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lastname" runat="server" Text="Efternamn:"></asp:Label>
                                </td>
                                <td>
                <asp:TextBox ID="txtLastName" runat="server" Width="241px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Personnr" runat="server" Text="Person nr:"></asp:Label>
                                </td>
                                <td>
                <asp:TextBox ID="txtPersonnr" runat="server" Width="241px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="adress" runat="server" Text="Adress:"></asp:Label>
                                </td>
                                <td>
                <asp:TextBox ID="txtAdress" runat="server" Width="241px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="ort" runat="server" Text="Ort:"></asp:Label>
                                </td>
                                <td>
                <asp:TextBox ID="txtOrt" runat="server" Width="241px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="land" runat="server" Text="Land:"></asp:Label>
                                </td>
                                <td>
                <asp:TextBox ID="txtLand" runat="server" Width="241px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="telefon" runat="server" Text="Telefon:"></asp:Label>
                                </td>
                                <td>
                <asp:TextBox ID="txtTelefon" runat="server" Width="241px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="mobil" runat="server" Text="Mobil:"></asp:Label>
                                </td>
                                <td>
                <asp:TextBox ID="txtMobil" runat="server" Width="241px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="epost" runat="server" Text="E-post:"></asp:Label>
                                </td>
                                <td>
                <asp:TextBox ID="txtEpost" runat="server" Width="241px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="password" runat="server" Text="Lösenord:"></asp:Label>
                                </td>
                                <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="241px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td class="style2">
                                    <asp:Button ID="btnInputCustomer" runat="server" Text="Lägg till kund" />
                                    <asp:Button ID="btbUpdateCustomer" runat="server" Text="Ändra kunduppgifter" />
                                </td>
                            </tr>
                        </table>
                        <br /><br />
                        <asp:TextBox ID="txtSearch" runat="server" Height="23px" Width="263px"></asp:TextBox> 
        <asp:Button ID="btbSearch" runat="server" Text="SÖK KUND" Height="28px" /></li>
    <b style="margin-left:65px; padding:25px;">Resultat:</b>
</asp:Content>

