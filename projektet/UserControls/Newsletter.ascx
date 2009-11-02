<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Newsletter.ascx.cs" Inherits="UserControls_Newsletter" %>
            
<div style="background-image: url(images/meny.jpg);">Skicka ett nyhetesbrev till mig:<br /></div><br />
<asp:TextBox ID="txtEmail" runat="server" Width="193px"></asp:TextBox><br />
<asp:Button ID="btnSend" runat="server" Text="Skicka" onclick="btnSend_Click" /><br />
<asp:Label ID="lblSent" runat="server" Text="" ForeColor="Red"></asp:Label>