<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Adminproduct.aspx.cs"
    Inherits="Adminproduct" Title="ShopEr Admin" %>

<%@ Register src="UserControls/SearchProduct.ascx" tagname="SearchProduct" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>             Lägg till produkt:</h2>
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
                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" 
                    ControlToValidate="txtName" ValidationGroup="insertProduct">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td dir="ltr">
                <asp:Label ID="Label4" runat="server" Text="Antal produkter i lager:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server" Width="300px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" 
                    ControlToValidate="txtAmount" ValidationGroup="insertProduct">*</asp:RequiredFieldValidator>
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
                    ControlToValidate="txtPrice" ValidationGroup="insertProduct">*</asp:RequiredFieldValidator>
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
                <asp:Button ID="btnInsertProduct" runat="server" Text="Lägg till produkt" 
                    OnClick="btnInsertProduct_Click" ValidationGroup="insertProduct" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <br />  <h3>
        Sök efter produkt för att redigera:</h3>
   
    <div id="search">
  
        <%-- 
        TODO: Fråga Magnus varför det ej går att trycka på knappen
        <asp:TextBox ID="txtSearch" runat="server" Height="23px" Width="263px"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Sök" 
            onclick="btnSearch_Click2"  />--%>
    
        <uc1:SearchProduct ID="SearchProduct1" runat="server" />
    
</div>
</asp:Content>

