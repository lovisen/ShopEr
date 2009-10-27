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
            var product = ProductManagerByLINQ.GetProductByIdWithLinq(1);
            txtAmount.Text = product.Amount.ToString();
            txtDescription.Text = product.Description.ToString().Trim();
            txtDiscount.Text = product.Discount.ToString();
            txtName.Text = product.Name.ToString().Trim();
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
    protected void btnUpdateProduct_Click(object sender, EventArgs e)
    {
       var productToUpdate = new ProductLINQ();
        bool updateProd = true;
        int amount = 0;
        int price = 0;
        byte discount= 0;

        if (!int.TryParse(txtAmount.Text, out amount) || !int.TryParse(txtPrice.Text, out price) || !Page.IsValid)
        {
            updateProd = false;
            lblMessageText.Text = "Du måste fylla i antal produkter och pris.\n";
        }

        if (txtName.Text.Length < 2)
        {
            updateProd = false;
            lblMessageText.Text += "Produktnamnet måste bestå av minst två tecken\n";
        }

        if (txtDiscount.Text.Length > 0)
        {
            if (!byte.TryParse(txtDiscount.Text, out discount) && byte.Parse(txtDiscount.Text) > 99)
            {
                updateProd = false;
                lblMessageText.Text += "Rabatten kan bara innehålla ett nummer mellan 1-99\n";
                       }
        }
        if (updateProd== true)
        {
            productToUpdate.Discount = discount;
            productToUpdate.Amount = amount;
            productToUpdate.Description = txtDescription.Text;
            productToUpdate.Featured = cbYesFeature.Checked;
            productToUpdate.Name = txtName.Text;
            productToUpdate.Price = price;
            productToUpdate.ShowOnPage = cbYesShowOnPage.Checked;
            productToUpdate.SubCategory = long.Parse(ddlCategory.SelectedValue);
            //TODO: Lousie - ändra till querystring här!
            productToUpdate.Id = 1;
            //uppdatera produkten
            try
            {
                ProductManagerByLINQ manager = new ProductManagerByLINQ();
                manager.UpdateProduct(productToUpdate);
            }
            catch (Exception)
            {

                throw;
            }

            //ladda upp bilden till mappen
            if (imageUpload.HasFile)
            {
                try
                {
                    imageUpload.SaveAs(HttpContext.Current.Server.MapPath("~/images/Product/" + imageUpload.FileName));
                }
                catch (Exception)
                {

                    lblMessageText.Text += "Det gick inte att ladda upp bilden, försök igen";
                }
            }

            ////ladda upp filernas namn till databasen

            ////TODO: Louise - aktivera det här när funktionen för att spara bilderna i databasen funkar.
            //try
            //{
            //    var newprodId = insertFunc.InsertProduct(insertProduct);
            //    ProductImageManager.InsertProductImage(newprodId, imageUpload.FileName);

            //}
            //catch (Exception)
            //{

            //    lblMessageText.Text = "Något gick fel, försök igen";
            //}

            lblMessageText.Text = "Produkten är sparad"; 
        }
         
    }
}




