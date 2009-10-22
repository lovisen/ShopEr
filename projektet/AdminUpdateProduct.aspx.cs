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

public partial class AdminUpdateProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ////TODO: Louise - Ändra så det blir koden med querystringen när jag fått sökfunkationen. 
            ////Göra så att man ser produktens existerande bilder, samt att man kan ladda upp fler
           //ProductManagerByLINQ product= ProductManagerByLINQ.GetProductById(Request.QueryString("productId"));
            var product= ProductManagerByLINQ.GetProductByIdWithLinq(1);
            txtAmount.Text = product.Amount.ToString();
            txtDescription.Text = product.Description.ToString();
            txtDiscount.Text = product.Discount.ToString();
            txtName.Text = product.Name.ToString();
            txtPrice.Text = product.Price.ToString();
            cbYesFeature.Checked = (bool)product.Featured;
            cbYesShowOnPage.Checked = (bool)product.ShowOnPage;
            try
            {
                var lista = CategoryManager.GetCategories();
                foreach (CategoryItem c in lista)
                {
                    //ddlCategory.Items.Add(new ListItem(c.CategoryName, c.Id.ToString()));
                    foreach (CategoryItem cc in c.SubCategories)
                    {
                        ddlCategory.Items.Add(new ListItem(cc.CategoryName, cc.Id.ToString()));
                        ddlCategory.SelectedValue = product.SubCategory.ToString();
                    }
                }
            }
            catch (Exception)
            {
                lblMessageText.Text = "Något gick fel, försök igen";
                throw;
            }
        }
    }
    protected void btnInsertProduct_Click(object sender, EventArgs e)
    {

    }
}
