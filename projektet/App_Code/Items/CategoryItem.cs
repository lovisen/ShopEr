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
    private string _categoryName;
    public string CategoryName
    {
        get
        {
            return _categoryName;
        }
        set
        {
            _categoryName = value.Trim();
        }
    }
    public List<CategoryItem> SubCategories { get; set; }
    public long ParentCategoryId { get; set; }
    
	public CategoryItem()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
