using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductDetail.aspx");
    }

    public string WriteImageUrl(object img)
    {
        List<ProductImageItem> img2 = (List<ProductImageItem>)img;
        
        if (img2.Count > 0)
        {
            return img2[0].ImageURL;
        }
        return "no_image.jpeg";
    }
}

