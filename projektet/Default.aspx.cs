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
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
