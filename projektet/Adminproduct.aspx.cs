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

//TODO: Louise - Göra detaljsida för produkten man sökt på, för att 
    //uppdatera produkten samt kunna ladda upp fler bilder till den. Man bör även kunna ladda upp fler bilder när man gör
    //produkten. 

public partial class Adminproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                var lista = CategoryManager.GetCategories();
                foreach (CategoryItem c in lista)
                {
                    //ddlCategory.Items.Add(new ListItem(c.CategoryName, c.Id.ToString()));
                    foreach (CategoryItem cc in c.SubCategories)
                    {
                        ddlCategory.Items.Add(new ListItem(cc.CategoryName, cc.Id.ToString()));
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
        byte discount;
        int amount;
        int price;

        if (int.TryParse(txtAmount.Text, out amount) && int.TryParse(txtPrice.Text, out price) && Page.IsValid)
        {
            try
            {
                var insertProduct = new ProductLINQ();
                if (txtName.Text.Length < 2)
                {
                    lblMessageText.Text = "Produktnamnet måste bestå av minst två tecken";
                }

                if (txtDiscount.Text.Length > 0)
                {
                    if (byte.TryParse(txtDiscount.Text, out discount) && byte.Parse(txtDiscount.Text) < 99)
                    {
                        insertProduct.Discount = discount;
                    }
                    else
                    {
                        lblMessageText.Text = "Rabatten kan bara innehålla ett nummer mellan 1-99";
                    }
                }
                else
                {
                    insertProduct.Amount = amount;
                    insertProduct.Description = txtDescription.Text;
                    insertProduct.Featured = cbYesFeature.Checked;
                    insertProduct.Name = txtName.Text;
                    insertProduct.Price = price;
                    insertProduct.ShowOnPage = cbYesShowOnPage.Checked;
                    insertProduct.SubCategory = long.Parse(ddlCategory.SelectedValue);
                    var insertFunc = new ProductManagerByLINQ();
                    if (imageUpload.HasFile)
                    {
                        try
                        {
                            imageUpload.SaveAs(HttpContext.Current.Server.MapPath("~/images/Product/" + imageUpload.FileName));
                        }
                        catch (Exception)
                        {

                            lblMessageText.Text = "Det gick inte att ladda upp bilden, försök igen";
                        }
                    }



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
            catch (Exception)
            {
                lblMessageText.Text = "Något gick fel, försök igen";
            }
        }
        else
        {
            lblMessageText.Text = "Du måste fylla i antal produkter och pris.";
        }
    }
 
 
}
