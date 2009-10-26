using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UserControls_SearchProduct : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (txtSearch.Text.Length > 0)
        {
            try
            {
                var manager = new ProductManager().SearchProducts(txtSearch.Text);
                reSearch.DataSource = manager;
                reSearch.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
