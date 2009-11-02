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


    public List<ProductItem> SearchProducts(string searchString)
    {
        if (searchString.Length > 2)
        {
            searchString = searchString.Remove(2);
        }

        ShopErDataContext db = new ShopErDataContext();
        try
        {
            var productList = from p in db.ProductLINQs
                              where p.Name.StartsWith(searchString) || p.Name.Contains(searchString) && p.ShowOnPage == true
                              select p;
            List<ProductItem> productItemList = new List<ProductItem>();
            foreach (ProductLINQ p in productList)
            {
                productItemList.Add((ProductItem)p);
            }
            return productItemList;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public long InsertProduct(ProductItem prod)
    {
        ShopErDataContext db = new ShopErDataContext();
        try
        {
            ProductLINQ product = new ProductLINQ() { Amount = prod.Amount, Description = prod.Description, Discount = Convert.ToByte(prod.Discount), Featured = (bool)prod.Featured, Id = prod.Id, Name = prod.Name, Price = prod.Price, ShowOnPage = (bool)prod.ShowOnPage, SubCategory = prod.SubCategoryId };
            db.ProductLINQs.InsertOnSubmit(product);
            db.SubmitChanges();
            return product.Id;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public static ProductItem GetProductByIdWithLinq(long id)
    {
        ShopErDataContext db = new ShopErDataContext();
        try
        {
            var prod = db.ProductLINQs.FirstOrDefault(p => p.Id == id);
            //var product = new ProductItem() {Amount= prod.Amount, Description= prod.Description, Discount= Convert.ToInt32( prod.Discount), Featured = (bool)prod.Featured, Id= prod.Id, Name= prod.Name, Price= prod.Price, ShowOnPage= (bool)prod.ShowOnPage, SubCategoryId= prod.SubCategory };
            //gjort en explicit cast för att kunna casta om Linq produkt objekt till productitems
            return (ProductItem)prod;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool UpdateProduct(ProductItem productToUpdate)
    {
        ShopErDataContext db = new ShopErDataContext();
        try
        {
            var pr = db.ProductLINQs.FirstOrDefault(p => p.Id == productToUpdate.Id);
            pr.Name = productToUpdate.Name;
            pr.Price = productToUpdate.Price;
            pr.Amount = productToUpdate.Amount;
            pr.Description = productToUpdate.Description;
            pr.Discount = Convert.ToByte(productToUpdate.Discount);
            pr.Featured = productToUpdate.Featured;
            pr.ShowOnPage = productToUpdate.ShowOnPage;
            pr.SubCategory = productToUpdate.SubCategoryId;

            db.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
            throw;
        }
    }


    #region IProductManager Members not being used


    List<ProductItem> IProductManager.SearchProducts(string searchString)
    {
        throw new NotImplementedException();
    }
    public List<ProductItem> GetAllFeaturedProducts()
    {
        throw new NotImplementedException();
    }
    public List<ProductItem> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    ProductItem IProductManager.GetProductById(int id)
    {
        throw new NotImplementedException();
    }
    #endregion
}
    #endregion

