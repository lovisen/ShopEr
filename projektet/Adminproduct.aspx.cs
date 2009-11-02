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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
public partial class Adminproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cbYesShowOnPage.Checked = true;
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

        if (!int.TryParse(txtAmount.Text, out amount) && !int.TryParse(txtPrice.Text, out price) && !Page.IsValid)
        {
            lblMessageText.Text = "Du måste fylla i antal produkter och pris.";
            return;
        }
        try
        {
            if (txtName.Text.Length < 2)
            {
                lblMessageText.Text = "Produktnamnet måste bestå av minst två tecken";
            }
            var insertProduct = new ProductItem();
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
            //spara produkten
            insertProduct.Amount = amount;
            insertProduct.Description = txtDescription.Text;
            insertProduct.Featured = cbYesFeature.Checked;
            insertProduct.Name = txtName.Text;
            insertProduct.Price = int.Parse(txtPrice.Text);
            insertProduct.ShowOnPage = cbYesShowOnPage.Checked;
            insertProduct.SubCategoryId = long.Parse(ddlCategory.SelectedValue);

            var insertFunc = new ProductManagerByLINQ().InsertProduct(insertProduct);

            if (imageUpload.HasFile)
            {
                if (!imageUpload.PostedFile.ContentType.ToLower().StartsWith("image"))
                {
                    lblMessageText.Text = "Filen du försöker ladda upp är inte en bild, försök igen";
                    return;
                }
                //lägga till bildnamnet i databasen
                var imageName = StringHelper.RandomString(5) + "_" + insertFunc + "_" + imageUpload.FileName.Replace(" ", "_");
                var imageid = ProductImageManager.InsertProductImage(insertFunc, imageName);
                //spara bilden till mappen
                imageUpload.SaveAs(HttpContext.Current.Server.MapPath("~/images/Product/" + imageName));
                //resize bild och lägg den i thumbs mappen
                System.Drawing.Image imageToCrop = System.Drawing.Image.FromFile(Server.MapPath("images/Product/" + imageName));
                System.Drawing.Image thumbImage = ProductImageManager.FixedSizeThumb(imageToCrop);
                thumbImage.Save(Server.MapPath("images/Product/Thumbs/" + imageName));
                thumbImage.Dispose();

                //// TODO - Louise - fråga Magnus varför det ej går att deleta bilden så jag kan spara över den. eller finns det nåt
                //// bättre sätt att lösa detta på? annars så får vi strunta i att bilderna kan bli hur stora som helst.

                ////resize stor bild och spara över den existerande i image mappen
                //System.Drawing.Image bigImageToCrop = System.Drawing.Image.FromFile(Server.MapPath("images/Product/" + imageName));
                //System.Drawing.Image bigImage = ProductImageManager.FixedSizeImage(bigImageToCrop);
                //File.Delete(Server.MapPath("images/Product/" + imageName));
                //bigImage.Save(Server.MapPath("images/Product/" + imageName));
                //bigImage.Dispose();

            }
            lblMessageText.Text = "Produkten är sparad";
        }
        catch (Exception)
        {
            lblMessageText.Text = "Något gick fel, försök igen";
        }
    }




}
