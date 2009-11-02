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

    protected void Page_Init(object sender, EventArgs e)
    {
        DropdownCateory.DataSource = CategoryManager.GetChildCategories(0);
        DropdownCateory.DataBind();
        DropDownCategoryUpdate.DataSource = CategoryManager.GetChildCategories(0);
        DropDownCategoryUpdate.DataBind();
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }

    protected void btnInsertCategory_Click(object sender, EventArgs e)
    {
        lblRedFeeback.Visible = lblGreenFeedbck.Visible = false;

        if (txtInsertCategory.Text.Length > 1)
        {
            CategoryItem c = new CategoryItem();
            c.CategoryName = txtInsertCategory.Text;
            c.ParentCategoryId = 0;
            CategoryManager.InsertCategory(c);
            lblGreenFeedbck.Text = "Kategorin har lagts till i din meny";
            lblGreenFeedbck.Visible = true;
            txtInsertCategory.Text = "";
             //Response.Redirect("AdminCategory.aspx"); 


        }
        else 
        {
            lblRedFeeback.Text = "Det misslyckades att lägga till din kategori";
            lblRedFeeback.Visible = true;
            
        }
    }



    protected void btnInsertChildCategory_Click1(object sender, EventArgs e)
    {
        lblRedFeeback.Visible = lblGreenFeedbck.Visible = false;

        if (txtInsertChildCategory.Text.Length > 1)
        {
            CategoryItem c = new CategoryItem();
            c.CategoryName = txtInsertChildCategory.Text;
            c.ShowOnPage = true;
            c.ParentCategoryId = Convert.ToInt64(DropdownCateory.SelectedValue.ToString());
            if (CategoryManager.InsertChildCategory(c))
            {
                lblGreenFeedbck.Text = "Underkategorin har lagts till i din meny";
                lblGreenFeedbck.Visible = true;
                txtInsertChildCategory.Text = "";
            }

        }
        else
        {
            lblRedFeeback.Text = "Det misslyckades med att lägga till underkategorin";
            lblRedFeeback.Visible = true;
        }
    }


    protected void btnUpdateCategory_Click(object sender, EventArgs e)
    {
        lblRedFeeback.Visible = lblGreenFeedbck.Visible = false;

        if (txtUpdateCategory.Text.Length > 1)
        {
            CategoryItem c = new CategoryItem();
            c.CategoryName = txtUpdateCategory.Text;
            c.Id = Convert.ToInt64(DropDownCategoryUpdate.SelectedValue);

            if (CategoryManager.UpdateCategory(c))
            {
                lblGreenFeedbck.Text = "Kategorin är uppdaterad";
                lblGreenFeedbck.Visible = true;
                txtUpdateCategory.Text = "";
            }
            else lblRedFeeback.Text = "Uppdateringen misslyckades";
            lblRedFeeback.Visible = true;
        }
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
        lblRedFeeback.Visible = lblGreenFeedbck.Visible = false;

        if (txtUpdateChildCategory.Text.Length > 1)
        {
            CategoryItem c = new CategoryItem();
            c.CategoryName = txtUpdateChildCategory.Text;
            c.Id = Convert.ToInt64(DropDownList2.SelectedValue);

            if (CategoryManager.UpdateChildCategory(c))
            {
                lblGreenFeedbck.Text = "Uppdateringen lyckades";
                lblGreenFeedbck.Visible = true;
                txtUpdateChildCategory.Text = "";

            }
        }
        else lblRedFeeback.Text = "Uppdateringen misslyckades";
        lblRedFeeback.Visible = true;

    }
}
