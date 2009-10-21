<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminCategory.aspx.cs" Inherits="AdminCategory" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 232px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h1>Kategorihantering:</h1><br /><br />
    <table class="style1">
        <tr>
            <td class="style2">
                Lägg till en kategori:</td>
            <td>
                <asp:TextBox ID="txtInsertCategory" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Lägg tll en under kategori:</td>
            <td>
                <asp:TextBox ID="txtInsertChildCategory" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Ändra kategori:</td>
            <td>
                <asp:TextBox ID="txtUpdate" runat="server" Width="200px"></asp:TextBox>
                            </td>
        </tr>
        
        <tr>
            <td class="style2">
                Andra kategori:</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="ObjectDataSource1" DataTextField="CategoryName" 
                    DataValueField="CategoryName" Height="20px" Width="126px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="GetChildCategories" TypeName="CategoryManager">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="parentCategoryId" 
                            QueryStringField="ChildCategory" Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
                <tr>
            <td class="style2">
                Andra underkategori:</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" 
                    DataSourceID="ObjectDataSource1" DataTextField="CategoryName" 
                    DataValueField="CategoryName" Height="20px" Width="126px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                    SelectMethod="GetCategories" TypeName="CategoryManager">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Ta bort kategori:</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    

</asp:Content>

