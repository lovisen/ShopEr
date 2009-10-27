using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for ProductManagerByLINQ
/// </summary>
public class ProductManagerByLINQ : IProductManager
{
    public ProductManagerByLINQ()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region IProductManager Members

    public List<ProductItem> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    ProductItem IProductManager.GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public System.Collections.Generic.List<ProductItem> SearchProducts(string searchString)
    {
        throw new NotImplementedException();
    }

    public List<ProductItem> GetAllFeaturedProducts()
    {
        throw new NotImplementedException();
    }

    public long InsertProduct(ProductLINQ insertProduct)
    {
        ShopErDataContext db = new ShopErDataContext();
        try
        {
            db.ProductLINQs.InsertOnSubmit((ProductLINQ)insertProduct);
            db.SubmitChanges();
            return insertProduct.Id;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public static ProductLINQ GetProductByIdWithLinq(long id)
    {
        ShopErDataContext db = new ShopErDataContext();
        try
        {
            var product = db.ProductLINQs.FirstOrDefault(p => p.Id == id);
            return product;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool UpdateProduct(ProductLINQ productToUpdate)
    {
        ShopErDataContext db = new ShopErDataContext();
        try
        {
            var pr = db.ProductLINQs.FirstOrDefault(p => p.Id == productToUpdate.Id);
            pr.Name = productToUpdate.Name;
            pr.Price = productToUpdate.Price;
            pr.Amount = productToUpdate.Amount;
            pr.Description = productToUpdate.Description;
            pr.Discount = productToUpdate.Discount;
            pr.Featured = productToUpdate.Featured;
            pr.ShowOnPage = productToUpdate.ShowOnPage;
            pr.SubCategory = productToUpdate.SubCategory;
            
            db.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }
     }
    #endregion

