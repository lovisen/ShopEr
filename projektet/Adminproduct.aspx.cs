using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class Adminproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var lista = CategoryManager.GetCategories();
            foreach (CategoryItem c in lista) // TODO: Här ska jag fortsätta - Louise. Se till att subcat ser bra ut, samt att det går att inserta
            {
                ddlCategory.Items.Add(new ListItem(c.CategoryName, c.Id.ToString()));
                foreach (CategoryItem cc in c.SubCategories)
                {
                    ddlCategory.Items.Add(new ListItem("  -" + cc.CategoryName, cc.Id.ToString()));
                }
            }

        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void btnInsertProduct_Click(object sender, EventArgs e)
    {
        byte discount;
        int amount;
        int price;


        if (byte.TryParse(txtDiscount.Text, out discount) && int.TryParse(txtAmount.Text, out amount) && int.TryParse(txtPrice.Text, out price) && Page.IsValid)
        {
            try
            {
                var insertProduct = new ProductLINQ();
                insertProduct.Amount = amount;
                insertProduct.Description = txtDescription.Text;
                insertProduct.Discount = discount;
                insertProduct.Featured = true;
                insertProduct.Name = txtName.Text;
                insertProduct.Price = price;
                insertProduct.ShowOnPage = true;
                insertProduct.SubCategory = 1;
                var insertFunc = new ProductManagerByLINQ();
                insertFunc.InsertProduct(insertProduct);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
   
}
