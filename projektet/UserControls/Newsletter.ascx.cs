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
using System.Data.Common;

public partial class UserControls_Newsletter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        lblSent.Text = "";

        if (!StringHelper.isEmail(txtEmail.Text))
        {
            lblSent.Text += "Du har inte skrivit en riktig epostadress.";
        }
        else if (txtEmail.Text.Length > 1)
        {
            SubscriberItem n = new SubscriberItem();
            n.Email = txtEmail.Text;
            SubscriberManager.InsertSubscriber(n);
            lblSent.Text = "Du kommer nu få vårt nyhetsbrev.";
            txtEmail.Text = "";

        }

    }
}
