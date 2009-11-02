<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminCategory.aspx.cs"
    Inherits="AdminCategory" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    
        <h1>Kategorihantering:</h1>
        <div id="CategoryAdmin"> 
                    <p>
                        &nbsp;</p>
                    <p>
                        <asp:Label ID="lblGreenFeedbck" runat="server" BackColor="#CCFFCC" 
                            BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                        <asp:Label ID="lblRedFeeback" runat="server" BackColor="#FFCCCC" 
                            BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                    </p>
    <br />
    <br />
    
    <br />
    <img alt="" src="images/Add.png" /> LÄGG TILL
    
    <table>
        <tr>
            <td>
                Lägg till en huvudkategori:
            </td>
            <td>
                <asp:TextBox ID="txtInsertCategory" runat="server" Width="200px"></asp:TextBox>
                <asp:Button ID="btnInsertCategory" runat="server" OnClick="btnInsertCategory_Click"
                    Text="Lägg till" />
            </td>
        </tr>
        <tr>
            <td>
                Lägg tll en under kategori:
            </td>
            <td>
                Välj en huvudkategori som din underkategori skall ligga under:<br />
                <asp:DropDownList ID="DropdownCateory" runat="server" 
                    DataTextField="CategoryName" DataValueField="Id" Height="20px" 
                    Width="134px">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetChildCategories"
                    TypeName="CategoryManager">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="parentCategoryId" Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <%--DataSourceID="ObjectDataSource1"--%>
            </td>
        </tr>
        <tr>
            <td>
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
    <table>
        <tr>
            <td>
                Uppdatera huvudkategori:
            </td>
            
            
            <td>
                &nbsp;Välj vilken kategori som skall uppdateras<br />
                <asp:DropDownList ID="DropDownCategoryUpdate" runat="server" 
                    AutoPostBack="true" 
                    DataTextField="CategoryName" DataValueField="Id" Height="20px" 
                    OnSelectedIndexChanged="DropDownCategoryUpdate_SelectedIndexChanged" 
                    Width="134px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>

                <asp:TextBox ID="txtUpdateCategory" runat="server" Width="200px"></asp:TextBox>

                <asp:Button ID="btnUpdateCategory" runat="server" Text="Uppdatera" 
                    onclick="btnUpdateCategory_Click" />

            </td>

        </tr>
        
        <tr>
            <td>
                Uppdatera underkategori:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" 
                     DataTextField="CategoryName" 
                    DataValueField="Id" Height="20px" Width="134px" 
                    onselectedindexchanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtUpdateChildCategory" runat="server" Width="200px"></asp:TextBox>
 
                    <br />
                <asp:CheckBox ID="chbSkallIntesynas" runat="server" 
                    Text="Denna kategori ska inte synas på sidan:" />
                <asp:Button ID="btnUpdateChildCategory" runat="server" 
                    onclick="btnUpdateChildCategory_Click" Text="Uppdatera" />

 
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
    
    
      <br /></div>
    
    </asp:Content>
