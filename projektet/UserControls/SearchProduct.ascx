<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchProduct.ascx.cs" Inherits="UserControls_SearchProduct" %>
<asp:TextBox ID="txtSearch" runat="server" ></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Sök" onclick="btnSearch_Click" 
            />
            
     <asp:Repeater ID="reSearch" runat="server">
        <HeaderTemplate>
            <table>
            <tr>
                <td>
                    <b>Namn</b>&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <b>Pris</b>&nbsp;&nbsp;&nbsp;
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