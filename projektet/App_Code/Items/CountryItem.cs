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
/// Summary description for CountryItem
/// </summary>
public class CountryItem : BaseStructure<long>
{
	public CountryItem()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string CountryName { get; set; }
}
