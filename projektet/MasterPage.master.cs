﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        Response.Redirect("Order.aspx");
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Adminproduct.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SearchResult.aspx?searchString=" + txtSearch.Text);
    }
}
