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
/// Summary description for CategoryManager
/// </summary>
public class CategoryManager
{



    public struct IncludeToFill
    {
        public bool Id;
        public bool CategoryName;
        public bool SubCategory;
    }

    public CategoryManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static CategoryItem FillOne(DataRow r, IncludeToFill inc)
    {
        CategoryItem c = new CategoryItem();

        if (inc.Id) c.Id = (long)r["Id"];
        if (inc.CategoryName) c.CategoryName = (string)r["Name"];
        if (inc.SubCategory) c.SubCategories = GetChildCategories(c.Id);

        return c;
    }

    public static List<CategoryItem> FillAll(DataTable table, IncludeToFill inc)
    {
        List<CategoryItem> list = new List<CategoryItem>();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            list.Add(FillOne(table.Rows[i], inc));
        }

        return list;
    }


    public static List<CategoryItem> GetCategories()
    {
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT Id, Name, ParentCategoryId FROM Category WHERE ParentCategoryId = 0";
        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        IncludeToFill inc;
        inc.Id = true;
        inc.CategoryName = true;
        inc.SubCategory = true;

        return FillAll(table, inc);
    }

    public static CategoryItem GetCategory(int id)
    {
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT Id, CategoryName, ParentCategoryId FROM Category WHERE Id = @Id";
        comm.CreateAndAddParameter("@Id", id, DbType.Int32);
        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        IncludeToFill inc;
        inc.CategoryName = true;
        inc.Id = true;
        inc.SubCategory = true;

        return FillOne(table.Rows[0], inc);
    }

    public static List<CategoryItem> GetChildCategories(long parentCategoryId)
    {
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT Id, Name, ParentCategoryId FROM Category WHERE ParentCategoryId = @ParentCategoryId";
        comm.CreateAndAddParameter("@ParentCategoryId", parentCategoryId, DbType.Int32);
        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        IncludeToFill inc;
        inc.CategoryName = true;
        inc.Id = true;
        inc.SubCategory = true;

        return FillAll(table, inc);
    }

    //public static List<CategoryItem> InsertCategory(int Id)
    //{
    //    DbCommand comm = DataAccess.CreateCommand();
    //    comm.CommandText = CommandType.Text;
    //    comm.CommandText = "INSERT INTO Category(Name, ParentCategoryId) VALUES(@Name, @ParentCategoryId)";

    //}




}
