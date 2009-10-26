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

public partial class ConfirmAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string activationCode = Request.QueryString["ActivationCode"];
        if (CustomerManager.ActivateAccount(activationCode))
            lblFeedback.Text = "Ditt konto är nu aktiverat och kan börja användas";
        else
            lblFeedback.Text = "Något gick snett, försök igen eller alternativt regeristrera ett nytt konto.";
    }
}
