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
using System.Text;
using System.Data.Common;
using System.Collections.Generic;

/// <summary>
/// Summary description for CustomerManager
/// </summary>
public class CustomerManager
{
	public CustomerManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public struct IncludeToFill
    {
        public bool Adress;
        public bool DateOfBirth;
        public bool Email;
        public bool FirstName;
        public bool LastName;
        public bool MobileNumber;
        public bool NewsLetter;
        public bool Password;
        public bool Phone;
        public bool ZipCode;
        public bool Country;
        public bool Id;
        public bool City;
    }

    public static CustomerItem FillOne(DataRow r, IncludeToFill inc)
    {
        CustomerItem c = new CustomerItem();
        if (inc.Id) c.Id = (long)r["Id"];
        if (inc.Adress) c.Adress = (string)r["Adress"];
        if (inc.Country)
        {
            c.Country = new CountryItem();
            c.Country.Id = (long)r["CountryId"];
        } 
        if (inc.DateOfBirth) c.DateOfBirth = (string)r["DateOfBirth"];
        if (inc.Email) c.Email = (string)r["Email"];
        if (inc.FirstName) c.FirstName = (string)r["FirstName"];
        if (inc.LastName) c.LastName = (string)r["LastName"];
        if (inc.MobileNumber) c.MobileNumber = (string)r["MobilePhone"];
        if (inc.NewsLetter) c.NewsLetter = (bool)r["NewsLetter"];
        if (inc.Password) c.Password = (string)r["Password"];
        if (inc.Phone) c.Phone = (string)r["Phone"];
        if (inc.ZipCode) c.ZipCode = (string)r["ZipCode"];
        if (inc.City) c.City = (string)r["City"];

        return c;
    }

    public static List<CustomerItem> FillAll(DataTable t, IncludeToFill inc)
    {
        List<CustomerItem> list = new List<CustomerItem>();
        for (int i = 0; i < t.Rows.Count; i++)
        {
            list.Add(FillOne(t.Rows[i], inc));
        }
        return list;
    }

    public static bool InsertCustomer(CustomerItem c)
    {
        StringBuilder str = new StringBuilder();
        DbCommand comm = DataAccess.CreateCommand();
        
        str.Append("INSERT INTO Customer ");
        str.Append("(City, Adress, CountryId, DateOfBirth, Email, FirstName, LastName, MobilePhone, NewsLetter, Password, Phone, RoleID, ZipCode, ActivationCode, Activated) ");
        str.Append("VALUES (@City, @Adress, @CountryId, @DateOfBirth, @Email, @FirstName, @LastName, @MobilePhone, @NewsLetter, @Password, @Phone, @RoleID, @ZipCode, @ActivationCode, @Activated);");
        comm.CreateAndAddParameter("@Adress", c.Adress, DbType.String);
        comm.CreateAndAddParameter("@CountryId", c.Country.Id, DbType.Int64);
        comm.CreateAndAddParameter("@DateOfBirth", c.DateOfBirth, DbType.String);
        comm.CreateAndAddParameter("@Email", c.Email, DbType.String);
        comm.CreateAndAddParameter("@FirstName", c.FirstName, DbType.String);
        comm.CreateAndAddParameter("@LastName", c.LastName, DbType.String);
        comm.CreateAndAddParameter("@MobilePhone", c.MobileNumber, DbType.String);
        comm.CreateAndAddParameter("@NewsLetter", c.NewsLetter, DbType.Boolean);
        comm.CreateAndAddParameter("@Password", c.Password, DbType.String);
        comm.CreateAndAddParameter("@Phone", c.Phone, DbType.String);
        comm.CreateAndAddParameter("@RoleID", c.Role.Id, DbType.String);
        comm.CreateAndAddParameter("@ZipCode", c.ZipCode, DbType.String);
        comm.CreateAndAddParameter("@ActivationCode", c.ActivationCode, DbType.String);
        comm.CreateAndAddParameter("@Activated", c.Activated, DbType.Boolean);
        comm.CreateAndAddParameter("@City", c.City, DbType.String);

        comm.CommandText = str.ToString();


        return (DataAccess.ExecuteNonQuery(comm) != 0);
    }

    public static bool ActivateAccount(string activationCode)
    {
        StringBuilder str = new StringBuilder();
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandText = "UPDATE Customer SET Activated=@Activated WHERE ActivationCode = @ActivationCode";

        comm.CreateAndAddParameter("@ActivationCode", activationCode, DbType.String);
        comm.CreateAndAddParameter("@Activated", true, DbType.Boolean);

        return (DataAccess.ExecuteNonQuery(comm) != 0);
    }

    public static CustomerItem GetCustomerDetails(long customerid)
    {
        StringBuilder str = new StringBuilder();
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandText = "SELECT FirstName, LastName, DateOfBirth, Adress, Email, MobilePhone, NewsLetter, Phone, ZipCode, CountryId, City FROM Customer WHERE Id = @Id;";

        comm.CreateAndAddParameter("@Id", customerid, DbType.Int64);

        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        IncludeToFill inc;
        inc.FirstName = true;
        inc.LastName = true;
        inc.DateOfBirth = true;
        inc.MobileNumber = true;
        inc.NewsLetter = true;
        inc.Password = false;
        inc.Phone = true;
        inc.ZipCode = true;
        inc.Country = true;
        inc.Email = true;
        inc.Id = false;
        inc.Adress = true;
        inc.City = true;

        return FillOne(table.Rows[0], inc);

    }

    public static bool UpdateCustomerDetails(CustomerItem c)
    {
        StringBuilder str = new StringBuilder();
        DbCommand comm = DataAccess.CreateCommand();

        str.Append("UPDATE Customer SET");
        str.Append(" City=@City, Adress=@Adress, CountryId=@CountryId, DateOfBirth=@DateOfBirth, Email=@Email, FirstName=@FirstName, LastName=@LastName, MobilePhone=@MobilePhone, NewsLetter=@NewsLetter, Phone=@Phone, ZipCode=@ZipCode");
        str.Append(" WHERE Id = @Id ");
        comm.CreateAndAddParameter("@Adress", c.Adress, DbType.String);
        comm.CreateAndAddParameter("@CountryId", c.Country.Id, DbType.Int64);
        comm.CreateAndAddParameter("@DateOfBirth", c.DateOfBirth, DbType.String);
        comm.CreateAndAddParameter("@Email", c.Email, DbType.String);
        comm.CreateAndAddParameter("@FirstName", c.FirstName, DbType.String);
        comm.CreateAndAddParameter("@LastName", c.LastName, DbType.String);
        comm.CreateAndAddParameter("@MobilePhone", c.MobileNumber, DbType.String);
        comm.CreateAndAddParameter("@NewsLetter", c.NewsLetter, DbType.Boolean);
        comm.CreateAndAddParameter("@Phone", c.Phone, DbType.String);
        comm.CreateAndAddParameter("@ZipCode", c.ZipCode, DbType.String);
        comm.CreateAndAddParameter("@City", c.City, DbType.String);
        comm.CreateAndAddParameter("@Id", c.Id, DbType.Int64);

        comm.CommandText = str.ToString();

        return (DataAccess.ExecuteNonQuery(comm) != 0);
    }

    public static bool UpdateCustomerPassword(CustomerItem c)
    {
        StringBuilder str = new StringBuilder();
        DbCommand comm = DataAccess.CreateCommand();

        str.Append("UPDATE Customer SET ");
        str.Append("Password=@Password ");
        str.Append("WHERE Id = @Id ");
        comm.CreateAndAddParameter("@Password", c.Password, DbType.String);
        comm.CreateAndAddParameter("@Id", c.Id, DbType.Int64);

        comm.CommandText = str.ToString();

        return (DataAccess.ExecuteNonQuery(comm) != 0);
    }
    
}

