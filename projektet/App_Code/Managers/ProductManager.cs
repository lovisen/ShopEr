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
using System.Data.Common;

/// <summary>
/// Summary description for ProductManager
/// </summary>
public class ProductManager : IProductManager
{
	public ProductManager() 
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public struct IncludeToFill
    {
        public bool Amount;
        public bool Description;
        public bool Discount;
        public bool Featured;
        public bool Id;
        public bool Images;
        public bool Name;
        public bool ShowOnPage;
        public bool Price;
    }

    public static ProductItem FillOne(DataRow r, IncludeToFill i)
    {
        
        ProductItem p = new ProductItem();
        if (i.Amount) p.Amount = (int)r["Amount"];
        if (i.Description) p.Description = (string)r["Description"];
        if (i.Discount) p.Discount = (byte)r["Discount"];
        if (i.Featured) p.Featured = (bool)r["Featured"];
        if (i.Id) p.Id = (long)r["Id"];
        if (i.Images) p.Images = ProductImageManager.GetImagesForProduct(p.Id);
        if (i.Name) p.Name = (string)r["Name"];
        if (i.Price) p.Price = (int)r["Price"];
        if (i.ShowOnPage) p.ShowOnPage = (bool)r["ShowOnPage"];

        return p;
    }

    public static List<ProductItem> FillAll(DataTable table, IncludeToFill inc)
    {
        List<ProductItem> list = new List<ProductItem>();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            list.Add(FillOne(table.Rows[i], inc));
        }

        return list;
    }

    public ProductItem GetProductById(int id)
    {
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandText = "SELECT Amount, Description, Discount, Featured, Id, Name, Price FROM Product WHERE Id = @Id";

        comm.CreateAndAddParameter("@Id", id, DbType.Int32);

        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        IncludeToFill inc;
        inc.Amount = true;
        inc.Description = true;
        inc.Discount = true;
        inc.Featured = false;
        inc.Id = true;
        inc.Images = true;
        inc.Name = true;
        inc.ShowOnPage = false;
        inc.Price = true;

        return FillOne(table.Rows[0], inc);
    }

    public List<ProductItem> GetAllProducts()
    {
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandText = "SELECT * FROM Product";

        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        IncludeToFill inc;
        inc.Amount = true;
        inc.Description = true;
        inc.Discount = true;
        inc.Featured = true;
        inc.Id = true;
        inc.Images = true;
        inc.Name = true;
        inc.ShowOnPage = true;
        inc.Price = true;

        return FillAll(table, inc);
    }

    public List<ProductItem> GetProductsByCategoryId(long SubCategoryId)
    {
        DbCommand comm = DataAccess.CreateCommand();

        comm.CommandText = "SELECT Description, Id, Name, Price FROM Product WHERE SubCategory = @SubCategoryId";

        comm.CreateAndAddParameter("@SubCategoryID", SubCategoryId, DbType.Int64);

        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        IncludeToFill inc;
        inc.Amount = false;
        inc.Discount = false;
        inc.ShowOnPage = false;
        inc.Featured = false;
        inc.Description = true;
        inc.Id = true;
        inc.Images = true;
        inc.Name = true;
        inc.Price = true;

        return FillAll(table, inc);
    }





    #region IProductManager Members


    public List<ProductItem> SearchProducts(string searchString)
    {
        if (searchString == "" || searchString == null)
        {
            return null;
        }
        DbCommand comm = DataAccess.CreateCommand();

        comm.CommandText = "SELECT Id, Name, Price FROM Product WHERE Name LIKE @searchString OR Description LIKE @searchString";

        comm.CreateAndAddParameter("@searchString", "%" + searchString + "%", DbType.String);

        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        IncludeToFill inc;
        inc.Amount = false;
        inc.Discount = false;
        inc.ShowOnPage = false;
        inc.Featured = false;
        inc.Description = false;
        inc.Id = true;
        inc.Images = false;
        inc.Name = true;
        inc.Price = true;

        return FillAll(table, inc);


        throw new NotImplementedException();
    }

    public List<ProductItem> GetAllFeaturedProducts()
    {
        throw new NotImplementedException();
    }

    public long InsertProduct(ProductLINQ insertProduct)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(ProductLINQ productToUpdate)
    {
        throw new NotImplementedException();
    }

    #endregion
}
