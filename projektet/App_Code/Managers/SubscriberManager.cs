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
/// Summary description for SubscriberManager
/// </summary>
public class SubscriberManager
{

    public SubscriberManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool InsertSubscriber(SubscriberItem n)
    {
        try
        {
            DbCommand comm = DataAccess.CreateCommand();
            comm.CommandText = "INSERT INTO Subscriber(Email) VALUES(@Email)";
            comm.CreateAndAddParameter("@Email", n.Email, DbType.String);

            DataAccess.ExecuteNonQuery(comm);
            return true;
        }
        catch
        {
            return false;
        }
    }
}