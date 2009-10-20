<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODSSearch">
        <HeaderTemplate>
            <table>
            <tr>
                <td>
                    <b>Name</b>&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <b>Price</b>&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href="ProductDetail.aspx?Product=<%# Eval("Id") %>"><%# Eval("Name") %></a>
                </td>
                <td>
                    <%# Eval("Price") %> kr
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ODSSearch" runat="server" 
        SelectMethod="SearchProducts" TypeName="ProductManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="searchString" QueryStringField="searchString" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

