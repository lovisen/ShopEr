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
        }
        else lblError.Text = "Det misslyckades att lägga till din kategori";
    }



    protected void btnInsertChildCategory_Click1(object sender, EventArgs e)
    {
        if (txtInsertChildCategory.Text.Length > 1)
        {
            CategoryItem c = new CategoryItem();
            c.CategoryName = txtInsertChildCategory.Text;
            
            c.ParentCategoryId = Convert.ToInt64(DropdownCateory.SelectedValue.ToString());
            if (CategoryManager.InsertChildCategory(c))
            {
                lblRespons.Text = "Underkategorin har lagts till i din meny";
            }
            
        }
        else lblError.Text = "Det misslyckades med att lägga till underkategorin";
    }
}
