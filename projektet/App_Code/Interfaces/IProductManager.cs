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
/// Interface for ProductManagers
/// </summary>
public interface IProductManager
{
     List<ProductItem> GetAllProducts();
     ProductItem GetProductById(int id);
     List<ProductItem> SearchProducts(string searchString);
    void GetAllFeaturedProducts();
    long InsertProduct(ProductLINQ insertProduct);
    void UpdateProduct();

   }
