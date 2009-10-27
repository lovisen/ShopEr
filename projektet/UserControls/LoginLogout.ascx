<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginLogout.ascx.cs" Inherits="UserControls_LoginLogout" %>
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />

<asp:Panel ID="PanelLogin" runat="server">
        <ul>      
            <li style="margin-top: 5px; margin-left: 30px;">
                Mail:
                <asp:TextBox ID="txtUsername" runat="server" Width="130px" Text="Användarnamn" onfocus="this.value='a@a.se';" onclick="this.value='';"> </asp:TextBox></li>
            <li style="margin-top: 5px; margin-left: 5px;">
                Lösenord: 
                <asp:TextBox ID="txtPassword" runat="server" Width="130px" TextMode="Password" Text="Lösenord" onclick="this.value='123';"></asp:TextBox></li>
            <li style="margin-top: 4px; margin-left: 5px;">
                <asp:Button ID="btnLogin" runat="server" Text="Logga in" OnClick="btnLogin_Click" /></li>
            <li style="margin-top: 4px; margin-left: 5px;">
                <img alt="" style="margin-left:15px;" src="images/Sign-In.png" /></li>
        </ul>    
</asp:Panel>

<asp:Panel ID="PanelLogout" runat="server">
        <ul>
            <li style="margin-top: 6px; margin-left: 5px;">
                <asp:Label ID="lblStatus" runat="server"></asp:Label></li>
            <li style="margin-top: 6px; margin-left: 5px;">
                <asp:Label ID="lblUsername" runat="server" Font-Bold="True"></asp:Label></li>
            <li style="margin-top: 4px; margin-left: 5px;">
                <asp:Button ID="btnLogout" runat="server" Text="Logga ut" OnClick="btnLogout_Click" /></li>
            <li style="margin-top: 4px; margin-left: 5px;">
                <img alt="" style="margin-left:15px;" src="images/Sign-In.png" /></li>
        </ul>
</asp:Panel>        

<asp:Panel ID="PanelError" runat="server" Visible="False">
        <ul>
            <li style="margin-left: 5px;">
                <asp:LinkButton ID="btnToLogin" runat="server" OnClick="btnToLogin_Click" Font-Bold="True">Fel vid inloggning. Klicka här för att logga in igen.</asp:LinkButton></li>
        </ul>
</asp:Panel>  

