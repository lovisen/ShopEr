<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.ascx.cs" Inherits="UserControls_ShoppingCart" %>

    <table style="background:#FFFF99;color:#000;width:240px;padding:10px;margin:5px;" frame="box">
        <tr>
            <td>Produkt:</td>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="-"></asp:Label></td>
        </tr>
        <tr>
            <td>Antal:</td>
            <td style="text-align:right;"><asp:Label ID="lblAmount" runat="server" Text="-"></asp:Label></td>
        </tr>
        <tr>
            <td>Summa:</td>
            <td style="text-align:right;"><asp:Label ID="lblSum" runat="server" Text="-"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Totalt:</b></td>
            <td style="text-align:right;"><asp:Label ID="lblTotal" runat="server" Text="-" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Image ID="Image1" runat="server" ImageUrl="~/images/ShopList.png" /></td>
            <td style="text-align:right;"><asp:Label ID="lblMessage" runat="server" ForeColor="Black" Text="Varukorgen är tom" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:right;"><a href=""><img alt="" src="images/tillkassan.png" /></a></td>
        </tr>
    </table>    
    
</div>