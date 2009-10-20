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

    public System.Collections.Generic.List<ProductItem> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public ProductItem GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public System.Collections.Generic.List<ProductItem> SearchProducts()
    {
        throw new NotImplementedException();
    }

    public void GetAllFeaturedProducts()
    {
        throw new NotImplementedException();
    }

    public bool InsertProduct(ProductLINQ insertProduct)
    {
        ShopErDataContext db = new ShopErDataContext();
        try
        {
            db.ProductLINQs.InsertOnSubmit((ProductLINQ)insertProduct);
            db.SubmitChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
            throw;

        }
    }

    public void UpdateProduct()
    {
        throw new NotImplementedException();
    }

    #endregion

}