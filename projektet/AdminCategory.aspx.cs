using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AdminCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnInsertCategory_Click(object sender, EventArgs e)
    {
        if (txtInsertCategory.Text.Length > 1)
        {
            CategoryItem c = new CategoryItem();
            c.CategoryName = txtInsertCategory.Text;
            c.ParentCategoryId = 0;
            CategoryManager.InsertCategory(c);
            lblRespons.Text = "Kategorin har lagts till i din meny";
            txtInsertCategory.Text = "";

        }
        else lblRespons.Text = "Det misslyckades att lägga till din kategori";
        lblRespons.Text = "";

    }



    protected void btnInsertChildCategory_Click1(object sender, EventArgs e)
    {
        if (txtInsertChildCategory.Text.Length > 1)
        {
            CategoryItem c = new CategoryItem();
            c.CategoryName = txtInsertChildCategory.Text;
            c.ShowOnPage = true;
            c.ParentCategoryId = Convert.ToInt64(DropdownCateory.SelectedValue.ToString());
            if (CategoryManager.InsertChildCategory(c))
            {
                lblRespons.Text = "Underkategorin har lagts till i din meny";
                txtInsertChildCategory.Text = "";
            }
            
        }
        else lblRespons.Text = "Det misslyckades med att lägga till underkategorin";
    }


    protected void btnUpdateCategory_Click(object sender, EventArgs e)
    {
        if (txtUpdateCategory.Text.Length > 1)
        {
            CategoryItem c = new CategoryItem();
            c.CategoryName = txtUpdateCategory.Text;
            c.Id = Convert.ToInt64(DropDownCategoryUpdate.SelectedValue);
            
            if (CategoryManager.UpdateCategory(c))
            {
                lblFeedback.Text = "Kategorin är uppdaterad";
                txtUpdateCategory.Text = "";
            }
        }
        else lblFeedback.Text = "Uppdateringen misslyckades";

        
    }

    protected void DropDownCategoryUpdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtUpdateCategory.Text = DropDownCategoryUpdate.SelectedItem.Text;
        DropDownList2.DataSource = CategoryManager.GetChildCategories(Convert.ToInt64(DropDownCategoryUpdate.SelectedValue));
        DropDownList2.DataBind();
        
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtUpdateChildCategory.Text = DropDownList2.SelectedItem.Text;
        chbSkallIntesynas.Checked = !CategoryManager.GetShowOnPage(long.Parse(DropDownList2.SelectedValue));
    }


    protected void btnUpdateChildCategory_Click(object sender, EventArgs e)
    {
        if (txtUpdateChildCategory.Text.Length > 1)

        {
            CategoryItem c = new CategoryItem();
            c.CategoryName = txtUpdateChildCategory.Text;
            c.Id = Convert.ToInt64(DropDownList2.SelectedValue);

            if (CategoryManager.UpdateChildCategory(c))
            {
                lblFeedback.Text = "Uppdateringen lyckades";
                txtUpdateChildCategory.Text = "";
                    
            }
        }
        else lblFeedback.Text = "Uppdateringen misslyckades";
        
    }
}
