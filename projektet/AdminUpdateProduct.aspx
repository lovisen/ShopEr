<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminUpdateProduct.aspx.cs" Inherits="AdminUpdateProduct" Title="ShopEr Admin - Uppdatera produkt" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> <h2>
        Produkthantering:</h2>
    <table class="style1" style="padding: 50px; border-style: dotted; border-width: 2px;
        width: 600px; margin-left: 100px; margin-top: 50px;" title="Produkthantering">
        <tr>
            <td dir="ltr">
                <asp:Label ID="lblMessageTitle" runat="server" Text="Meddelande:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMessageText" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td dir="ltr">
                <asp:Label ID="Label1" runat="server" Text="Produktnamn:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtName">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td dir="ltr">
                <asp:Label ID="Label4" runat="server" Text="Antal produkter i lager:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server" Width="300px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtAmount">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td dir="ltr">
                <asp:Label ID="Label5" runat="server" Text="Rabatt:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDiscount" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td dir="ltr">
                <asp:Label ID="Label6" runat="server" Text="Pris:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                    ControlToValidate="txtPrice">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td dir="ltr">
                <asp:Label ID="Label7" runat="server" Text="Featured:"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="cbYesFeature" runat="server" Text=" Ja" />
                       </td>
        </tr>
        <tr>
            <td dir="ltr">
                <asp:Label ID="Label8" runat="server" Text="Visa på sida:"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="cbYesShowOnPage" runat="server" Text=" Ja" />
              
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Kategori:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Beskrivning:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="134px" TextMode="MultiLine"
                    Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Välj bild:
            </td>
            <td class="style2">
                <asp:FileUpload ID="imageUpload" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnInsertProduct" runat="server" Text="Uppdatera produkt" OnClick="btnInsertProduct_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <br />
    <li style="padding: 25px; margin-left: 60px; list-style: none;">
        <asp:TextBox ID="txtSearch" runat="server" Height="23px" Width="263px"></asp:TextBox>
        <asp:Button ID="btbSearch" runat="server" Text="SÖK PRODUKT" Height="28px" /></li>
    <b style="margin-left: 65px; padding: 25px;">Resultat:</b>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>

