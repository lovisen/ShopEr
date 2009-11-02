<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="ShopEr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <h1>Erbjudanden</h1>
            <br />
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" GroupItemCount="3">
        <LayoutTemplate>
            <table id="Table1" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="1" style="margin-left: 20px;
                            background-color: #FFFFFF; border-collapse: collapse; border-color: #999999;
                            border-style: none; border-width: 2px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr2" runat="server">
                    <td id="Td2" runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif;
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
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' Font-Size="14px" /><br />
                <img src='images/Product/<%# WriteImageUrl(Eval("Images"))%>' alt="" style="padding: 20px;" /><br />
                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' Font-Size="16px" /> :-<br /><br />
                <a href=""><img alt="Köp" src="images/kop.png" /></a>
                <a href="ProductDetail.aspx?Product=<%# Eval("Id") %>&Category=<%#Request.QueryString["Category"] %>"><img alt="Köp" src="images/info.png" /></a>
            </td>
        </ItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllFeaturedProducts"
        TypeName="ProductManager">
</asp:ObjectDataSource>
</asp:Content>

