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
/// Summary description for CategoryItem
/// </summary>
public class CategoryItem : BaseStructure<long>
{
    public string CategoryName { get; set; }
    public List<CategoryItem> SubCategories { get; set; }
    public long ParentCategoryId { get; set; }
    
	public CategoryItem()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
