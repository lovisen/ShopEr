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
    public long GetProdIDByQueryString()
    {
        long id = 0;
        long.TryParse(Request.QueryString["id"], out id);
        return id;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack || GetProdIDByQueryString() == 0)
        {
            return;
        }
        var product = ProductManagerByLINQ.GetProductByIdWithLinq(GetProdIDByQueryString());
        txtAmount.Text = product.Amount.ToString();
        txtDescription.Text = product.Description.ToString().Trim();
        txtDiscount.Text = product.Discount.ToString();
        txtName.Text = product.Name.ToString().Trim();
        txtPrice.Text = product.Price.ToString();
        cbYesFeature.Checked = (bool)product.Featured;
        cbYesShowOnPage.Checked = (bool)product.ShowOnPage;
        var images = from p in ProductImageManager.GetImagesForProduct(GetProdIDByQueryString()) select p;
        Repeater1.DataSource = images;
        Repeater1.DataBind();
        try
        {
            var lista = CategoryManager.GetCategories();
            foreach (CategoryItem c in lista)
            {
                foreach (CategoryItem cc in c.SubCategories)
                {
                    ddlCategory.Items.Add(new ListItem(cc.CategoryName, cc.Id.ToString()));

                }
                ddlCategory.SelectedValue = product.SubCategoryId.ToString();
            }
        }
        catch (Exception)
        {
            lblMessageText.Text = "Något gick fel, försök igen";
            throw;
        }
    }

    protected void btnUpdateProduct_Click(object sender, EventArgs e)
    {
        if (GetProdIDByQueryString() == 0)
        {
            lblMessageText.Text = "Var god sök efter en produkt för att uppdatera";
        }
        var productToUpdate = new ProductItem();
        bool updateProd = true;
        int amount = 0;
        int price = 0;
        byte discount = 0;
        long id = 0;

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
        if (updateProd == false)
        {
            return;
        }
        productToUpdate.Discount = discount;
        productToUpdate.Amount = amount;
        productToUpdate.Description = txtDescription.Text;
        productToUpdate.Featured = cbYesFeature.Checked;
        productToUpdate.Name = txtName.Text;
        productToUpdate.Price = price;
        productToUpdate.ShowOnPage = cbYesShowOnPage.Checked;
        productToUpdate.SubCategoryId = long.Parse(ddlCategory.SelectedValue);
        productToUpdate.Id = id;
        //uppdatera produkten
        try
        {
            ProductManagerByLINQ manager = new ProductManagerByLINQ();
            manager.UpdateProduct(productToUpdate);
        }
        catch (Exception)
        {
            lblMessageText.Text = "Produkten gick ej att spara, försök igen";
        }

        //spara bilden till mappen
        if (imageUpload.HasFile)
        {
            if (!imageUpload.PostedFile.ContentType.ToLower().StartsWith("image"))
            {
                lblMessageText.Text = "Filen du försöker ladda upp är inte en bild, försök igen";
                return;
            }
            //lägga till bildnamnet i databasen
            var imageName = StringHelper.RandomString(5) + "_" + GetProdIDByQueryString() + "_" + imageUpload.FileName.Replace(" ", "_");
            var imageid = ProductImageManager.InsertProductImage(GetProdIDByQueryString(), imageName);
            imageUpload.SaveAs(HttpContext.Current.Server.MapPath("~/images/Product/" + imageName)); 
          //resize bild och lägg den i thumbs mappen
            System.Drawing.Image imageToCrop = System.Drawing.Image.FromFile(Server.MapPath("images/Product/" + imageName));
            System.Drawing.Image thumbImage = ProductImageManager.FixedSizeThumb(imageToCrop);
            thumbImage.Save(Server.MapPath("images/Product/Thumbs/" + imageName));
            thumbImage.Dispose();            
        }
        Response.Redirect(Request.Url.AbsoluteUri);
        lblMessageText.Text = "Produkten är sparad";
    }

    public void DeleteImage(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        try
        {
            ProductImageManager.DeleteProductImage(GetProdIDByQueryString(), long.Parse(lnk.CommandArgument));
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        catch (Exception)
        {
            lblMessageText.Text = "Det gick ej att ta bort bilden, försök igen";
        }
    }
}






