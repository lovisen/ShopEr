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
/// Summary description for ShopErConfiguration
/// </summary>
public class ShopErConfiguration
{
    private static string dbConnectionString;
    private static string dbProviderName;

    //Konstruktorn
    static ShopErConfiguration()
    {
        //dbConnectionString = ConfigurationManager.ConnectionStrings["ShopErConnection"].ConnectionString;
        //dbProviderName = ConfigurationManager.ConnectionStrings["ShopErConnection"].ProviderName;
    }

    //Returnerar connectionstringen från databasen
    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }

    }
    //Returnerar namnet på data providern
    public static string DbProviderName
    {
        get
        {
            return dbProviderName;
        }
    }

}
