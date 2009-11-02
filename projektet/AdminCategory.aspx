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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        Kategorihantering:</h1>
                    <p>
                        &nbsp;</p>
                    <p>
                <asp:Label ID="lblRespons" runat="server" Font-Bold="True"></asp:Label>
                    </p>
    <br />
    <br />
    
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
    <img alt="" src="images/Update.png" />UPPDATERA
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <table class="style1" frame="border" style="border-style: dotted; border-width: 1px">
        <tr>
            <td class="style5">
                Uppdatera huvudkategori:
            </td>
            
            
            <td class="style6">
                &nbsp;Välj vilken kategori som skall uppdateras<br />
                <asp:DropDownList ID="DropDownCategoryUpdate" runat="server" 
                    AutoPostBack="true" DataSourceID="ObjectDataSource1" 
                    DataTextField="CategoryName" DataValueField="Id" Height="20px" 
                    OnSelectedIndexChanged="DropDownCategoryUpdate_SelectedIndexChanged" 
                    Width="134px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style7">
            </td>
            <td class="style8">

                <asp:TextBox ID="txtUpdateCategory" runat="server" Width="200px"></asp:TextBox>

                <asp:Button ID="btnUpdateCategory" runat="server" Text="Uppdatera" 
                    onclick="btnUpdateCategory_Click" />

                <asp:Label ID="lblFeedback" runat="server" Font-Bold="True"></asp:Label>

            </td>

        </tr>
        
        <tr>
            <td class="style9">
                Uppdatera underkategori:
            </td>
            <td class="style10">
                <asp:DropDownList ID="DropDownList2" runat="server" 
                     DataTextField="CategoryName" 
                    DataValueField="Id" Height="20px" Width="134px" 
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtUpdateChildCategory" runat="server" Width="200px"></asp:TextBox>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:CheckBox ID="chbSkallIntesynas" runat="server" 
                                Text="Denna kategori ska inte synas på sidan:" />
                            &nbsp;<asp:Button ID="btnUpdateChildCategory" runat="server" 
                                onclick="btnUpdateChildCategory_Click" Text="Uppdatera" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
      
    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownCategoryUpdate" 
                        EventName="SelectedIndexChanged" />
                         <asp:AsyncPostBackTrigger ControlID="DropDownList2" 
                        EventName="SelectedIndexChanged" />
                </Triggers>
                </asp:UpdatePanel> 
    
    
      <br />
    
    </asp:Content>
