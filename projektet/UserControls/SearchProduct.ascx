<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchProduct.ascx.cs" Inherits="UserControls_SearchProduct" %>
   <p>
            Sök efter produkt för att uppdatera</p>
<asp:TextBox ID="txtSearch" runat="server" ></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Sök" onclick="btnSearch_Click" />
                        <asp:Label ID="lblSearchMessage" runat="server" />
                       
                       
<asp:ListView ID="lstSearchResult" runat="server">
<LayoutTemplate>

<ul class="searchlist" >
<asp:PlaceHolder ID="itemPlaceholder" runat="server" />
</ul> 
</LayoutTemplate>
<ItemTemplate>

<li><a href="AdminUpdateProduct.aspx?id=<%# Eval("Id") %>"><%# Eval("Name") %></a> <%# Eval("Price") %> kr</li>
</ItemTemplate>
<EmptyDataTemplate><p>Din sökning gav inget resultat, försök igen</p>
<%Pager.Visible = false; %>
</EmptyDataTemplate>


</asp:ListView>
          
    <asp:DataPager ID="Pager" runat="server" PagedControlID="lstSearchResult" 
    PageSize="10">
        <Fields>
            <asp:NextPreviousPagerField PreviousPageText="Föregående" 
                ShowNextPageButton="False" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField NextPageText="Nästa" 
                ShowPreviousPageButton="False" />
        </Fields>
</asp:DataPager>

            
    