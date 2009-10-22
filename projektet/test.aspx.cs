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

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerItem c = new CustomerItem();

        c.FirstName = "Marcus";
        c.LastName = "Malmestad";
        c.Email = "javlarochhelvete@gmail.com";
        c.ActivationCode = StringHelper.RandomString(20);

        MailManager.SendMail(c);
    }
}
