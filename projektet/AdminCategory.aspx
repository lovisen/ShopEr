<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminCategory.aspx.cs"
    Inherits="AdminCategory" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 232px;
        }
        .style3
        {
            width: 232px;
            height: 40px;
        }
        .style4
        {
            height: 40px;
        }
        .style5
        {
            width: 232px;
            height: 25px;
        }
        .style6
        {
            height: 25px;
        }
        .style7
        {
            width: 232px;
            height: 47px;
        }
        .style8
        {
            height: 47px;
        }
        .style9
        {
            width: 232px;
            height: 39px;
        }
        .style10
        {
            height: 39px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div id="contentAdmin">
    <h1>
        Kategorihantering:</h1>
    <br />
    <br />
    <asp:Label ID="lblRespons" runat="server" ForeColor="#33CC33"></asp:Label>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <br />
   <img alt="" src="images/Add.png" /> LÄGG TILL<table class="style1" frame="border" style="border-style: dotted; border-width: 1px">
        <tr>
            <td class="style3">
                Lägg till en huvudkategori:
            </td>
            <td class="style4">
                <asp:TextBox ID="txtInsertCategory" runat="server" Width="200px"></asp:TextBox>
                <asp:Button ID="btnInsertCategory" runat="server" OnClick="btnInsertCategory_Click"
                    Text="Lägg till" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Lägg tll en under kategori:
            </td>
            <td>
                Välj en huvudkategori som din underkategori skall ligga under:<br />
                <asp:DropDownList ID="DropdownCateory" runat="server" DataSourceID="ObjectDataSource1"
                    DataTextField="CategoryName" DataValueField="Id" Height="20px" 
                    Width="134px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetChildCategories"
                    TypeName="CategoryManager">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="parentCategoryId" Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtInsertChildCategory" runat="server" Width="200px"></asp:TextBox>
                <asp:Button ID="btnInsertChildCategory" runat="server" Text="Lägg till" OnClick="btnInsertChildCategory_Click1" />
            </td>
        </tr>
    </table>
    <br />
   <img alt="" src="images/Update.png" /> UPPDATERA<table class="style1" frame="border" style="border-style: dotted; border-width: 1px">
        <tr>
            <td class="style5">
                Uppdatera huvudkategori:
            </td>
            <td class="style6">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="ObjectDataSource1" DataTextField="CategoryName" 
                    DataValueField="CategoryName" Height="20px" Width="134px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style7">
            </td>
            <td class="style8">

                <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Uppdatera" />

            </td>
        </tr>
        <tr>
            <td class="style9">
                Uppdatera underkategori:
            </td>
            <td class="style10">
                <asp:DropDownList ID="DropDownList2" runat="server" 
                    DataSourceID="ObjectDataSource1" DataTextField="SubCategories" 
                    DataValueField="CategoryName" Height="20px" Width="134px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                <asp:Button ID="btnUpdateChildCategory" runat="server" Text="Uppdatera" />
            </td>
        </tr>
      
    </table>
    
    
    
      <br />
   <img alt="" src="images/Delete.png" /> DELETE<table class="style1" frame="border" style="border-style: dotted; border-width: 1px">
        <tr>
            <td class="style3">
                Tabort en huvudkategori:
            </td>
            <td class="style4">
                <asp:DropDownList ID="DropDownList4" runat="server" 
                    DataSourceID="ObjectDataSource3" DataTextField="CategoryName" 
                    DataValueField="CategoryName" Height="20px" Width="134px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                    SelectMethod="GetCategories" TypeName="CategoryManager">
                </asp:ObjectDataSource>
                <asp:Button ID="btnDelete" runat="server" Text="Ta bort" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                Tabort en under kategori:
            </td>
            <td>
            
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetChildCategories"
                    TypeName="CategoryManager">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="parentCategoryId" Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
            
                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="ObjectDataSource1"
                    DataTextField="CategoryName" DataValueField="Id" Height="20px" 
                    Width="134px">
                </asp:DropDownList>
                <asp:Button ID="btnDeleteChildCategory" runat="server" Text="Ta bort" />
            </td>
        </tr>
    </table>
    </div>
    
    
</asp:Content>
