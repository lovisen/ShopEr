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

public partial class UserControls_LoginLogout : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsername.Attributes.Add("value", "Användarnamn");
        PanelLogout.Visible = false;

        if (UserAuthentication.IsAuthenticated() == true)
        {
            //är anv redan inloggad
            PanelLogin.Visible = false;
            PanelLogout.Visible = true;
            lblStatus.Text = "Inloggad som ";
            lblUsername.Text = HttpContext.Current.Session["UserName"].ToString();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //stämmer anv och lösen - logga in
        if (UserAuthentication.LogIn(txtUsername.Text, txtPassword.Text))
        {
            PanelLogin.Visible = false;
            PanelLogout.Visible = true;
            lblStatus.Text = "Inloggad som ";
            lblUsername.Text = lblUsername.Text = HttpContext.Current.Session["UserName"].ToString();
        }
        else
        {
            //fel vid inloggning
            PanelLogin.Visible = false;
            PanelError.Visible = true;
            //visa popup istället: Page.ClientScript.RegisterStartupScript(this.GetType(), "Inloggning", ("alert('Fel användarnamn eller lösenord!')"), true);
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
            UserAuthentication.LogOut();
            txtUsername.Text = "";
            PanelLogin.Visible = true;
            PanelLogout.Visible = false;
    }

    protected void btnToLogin_Click(object sender, EventArgs e)
    {
        //tillbaka till login
        PanelError.Visible = false;
        PanelLogin.Visible = true;
    }
}
