using System;
using System.Data;
using System.Data.Common;
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
/// Summary description for CountryManager
/// </summary>
public class CountryManager
{
	public CountryManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public struct IncludeToFill
    {
        public bool id;
        public bool countryName;
    }

    public static CountryItem FillOne(DataRow r, IncludeToFill inc)
    {
        CountryItem c = new CountryItem();

        if (inc.id) c.Id = (long)r["Id"];
        if (inc.countryName) c.CountryName = (string)r["CountryName"];

        return c;
    }

    public static List<CountryItem> FillAll(DataTable table, IncludeToFill inc)
    {
        List<CountryItem> list = new List<CountryItem>();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            list.Add(FillOne(table.Rows[i], inc));
        }

        return list;
    }

    public static List<CountryItem> GetAllCountries()
    {
        DbCommand comm = DataAccess.CreateCommand();
        comm.CommandType = CommandType.Text;
        comm.CommandText = "SELECT Id, CountryName FROM Country;";
        DataTable table = DataAccess.ExecuteSelectCommand(comm);

        IncludeToFill inc;
        inc.id = true;
        inc.countryName = true;

        return FillAll(table, inc);
    }
}
