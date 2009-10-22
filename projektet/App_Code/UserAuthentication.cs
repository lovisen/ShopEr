using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Common;

/// <summary>
/// Summary description for UserAuthentication
/// 
/// IsAuthenticated - kollar om anv redan är inloggad, return true/false
/// LogIn(skicka med anv, lösen) - return true/false
///     vid true läggs Id(kallad UserId) och RoleId(kallad UserRole) i session
/// LogOut - tömmer session
/// </summary>

public class UserAuthentication
{
    //kollar om användaren redan är inloggad
    public static bool IsAuthenticated()
    {
        if (HttpContext.Current.Session["UserId"] == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //logga in
    public static bool LogIn(string username, string password)
    {
        string Id;

        //kolla om username och password stämmer, kolla id
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandType = CommandType.Text;
        comm.CreateAndAddParameter("@Username", username, DbType.String);
        comm.CreateAndAddParameter("@Password", password, DbType.String);
        comm.CommandText = "SELECT Id FROM Customer WHERE Email = @Username AND Password = @Password";
        comm.Connection.Open();

        try
        {
            Id = comm.ExecuteScalar().ToString();
        }

        catch
        {
            return false;
        }

        //kolla role
        comm.CreateAndAddParameter("@Id", Id, DbType.String);
        comm.CommandText = "SELECT RoleId FROM Customer WHERE Id = @Id";

        //lägg till role och id i session
        HttpContext.Current.Session["UserRole"] = comm.ExecuteScalar().ToString();
        HttpContext.Current.Session["UserId"] = Id.ToString(); 

        comm.Connection.Close();
        comm.Connection.Dispose();

        return true;

    }

    //logga ut - tömmer session
    public static void LogOut()
    {
        HttpContext.Current.Session.Abandon();
    }

}
