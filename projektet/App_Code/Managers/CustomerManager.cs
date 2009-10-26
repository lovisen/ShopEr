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

    public static bool InsertCustomer(CustomerItem c)
    {
        StringBuilder str = new StringBuilder();
        DbCommand comm = DataAccess.CreateCommand();
        
        str.Append("INSERT INTO Customer ");
        str.Append("(Adress, CountryId, DateOfBirth, Email, FirstName, LastName, MobilePhone, NewsLetter, Password, Phone, RoleID, ZipCode, ActivationCode, Activated) ");
        str.Append("VALUES (@Adress, @CountryId, @DateOfBirth, @Email, @FirstName, @LastName, @MobilePhone, @NewsLetter, @Password, @Phone, @RoleID, @ZipCode, @ActivationCode, @Activated);");
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
    
}

