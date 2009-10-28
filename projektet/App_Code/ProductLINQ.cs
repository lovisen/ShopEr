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

public partial class ProductLINQ
{
    public static explicit operator ProductItem(ProductLINQ prod)
    {
        return new ProductItem() { Amount = prod.Amount, Description = prod.Description, Discount = Convert.ToInt32(prod.Discount), Featured = (bool)prod.Featured, Id = prod.Id, Name = prod.Name, Price = prod.Price, ShowOnPage = (bool)prod.ShowOnPage, SubCategoryId = prod.SubCategory };
           
    }
}
