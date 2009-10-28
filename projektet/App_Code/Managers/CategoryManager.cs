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

    public static bool GetShowOnPage(long SubCategoryId)
    {
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT ShowOnPage FROM Category WHERE Id = @SubCategoryId";
        comm.CreateAndAddParameter("@SubCategoryId", SubCategoryId, DbType.Int32);
        var table = DataAccess.ExecuteScalar(comm);
        
        return bool.Parse(table);
    }

    public static bool InsertCategory(CategoryItem c)
    {
        try
        {
            DbCommand comm = DataAccess.CreateCommand();
            comm.CommandText = "INSERT INTO Category(Name, ParentCategoryId) VALUES(@Name, @ParentCategoryId)";
            comm.CreateAndAddParameter("@Name", c.CategoryName, DbType.String);
            comm.CreateAndAddParameter("@ParentCategoryId", c.ParentCategoryId, DbType.Int64);

            DataAccess.ExecuteNonQuery(comm);
            return true;
        }
        catch (Exception ex)
        {

            return false;
        }
    }


    public static bool InsertChildCategory (CategoryItem c)
    {
        try
        {
            DbCommand comm = DataAccess.CreateCommand();
            comm.CommandText = "INSERT INTO Category(Name, ParentCategoryId, ShowOnPage) VALUES(@Name, @ParentCategoryId, @ShowOnPage)";
            comm.CreateAndAddParameter("@Name", c.CategoryName, DbType.String);
            comm.CreateAndAddParameter("@ParentCategoryId", c.ParentCategoryId, DbType.Int64);
            comm.CreateAndAddParameter("@ShowOnPage", c.ShowOnPage, DbType.Boolean);

            DataAccess.ExecuteNonQuery(comm);
            return true;
        }
        catch (Exception ex)
        {

            return false;
        }
    }



    public static bool UpdateCategory(CategoryItem c)
    {
        try
        {
            DbCommand comm = DataAccess.CreateCommand();
            comm.CommandText = "UPDATE Category SET Name = @Name WHERE Id = @Id";
            comm.CreateAndAddParameter("@Name", c.CategoryName, DbType.String);
            comm.CreateAndAddParameter("@Id", c.Id, DbType.Int64);

            DataAccess.ExecuteNonQuery(comm);
            return true;
        }
        catch (Exception ex)
        {

            return false;
        }
    }


    public static bool UpdateChildCategory(CategoryItem c)
    {
        try
        {
            DbCommand comm = DataAccess.CreateCommand();
            comm.CommandText = "UPDATE Category SET Name = @Name, ShowOnPage = @ShowOnPage WHERE Id = @Id";
            comm.CreateAndAddParameter("@Name", c.CategoryName, DbType.String);
            comm.CreateAndAddParameter("@Id", c.Id, DbType.Int64);
            comm.CreateAndAddParameter("@ShowOnPage", c.ShowOnPage, DbType.Boolean);

            DataAccess.ExecuteNonQuery(comm);
            return true;
        }
        catch (Exception ex)
        {

            return false;
        }

    }
}