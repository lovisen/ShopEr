<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Product.aspx.cs" Inherits="Product" Title="ShopEr Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" GroupItemCount="3">
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="1" style="margin-left: 20px;
                            background-color: #FFFFFF; border-collapse: collapse; border-color: #999999;
                            border-style: none; border-width: 2px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif;
                        color: #FFFFFF">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server">
                </td>
            </tr>
        </GroupTemplate>
        <EmptyDataTemplate>
            <table style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999;
                border-style: none; border-width: 1px;">
                <tr>
                    <td>
                        No data was returned.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <td id="Td2" runat="server" style="background-color: #fff; font-weight: bold; color: #333333;
                width: 200px;">
                Namn:
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                <br />
                <img src='images/Product/<%# Eval("Images[0].ImageURL") %>' alt="" style="padding: 20px;" />
                <br />
                Beskrivning:
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                <br />
                <br />
                Pris:
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                <br />
                <br />
                
                
                <a href=""><img alt="Köp" src="images/kop.png" /></a>
                <a href="ProductDetail.aspx?Product=<%# Eval("Id") %>&Category=<%#Request.QueryString["Category"] %>"><img alt="Köp" src="images/info.png" /></a>

            </td>
        </ItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetProductsByCategoryId"
        TypeName="ProductManager">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="SubCategoryId" 
                QueryStringField="SubCategory" Type="Int64" />
        </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>
