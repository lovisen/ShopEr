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
/// Summary description for ProductItem
/// </summary>
public class ProductItem : BaseStructure<long>
{
	public ProductItem()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value.Trim();
        }
    }
    public int Amount { get; set; }
    private string _description;
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value.Trim();
        }
    }
    public bool Featured { get; set; }
    public int Discount { get; set; }
    public int Price { get; set; }
    public bool ShowOnPage { get; set; }
    public List<ProductImageItem> Images { get; set; }


}
