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

/// <summary>
/// Summary description for SubscriberItem
/// </summary>
public class SubscriberItem : BaseStructure<long>
{
    public string Email { get; set; }

    public SubscriberItem()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
