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

public partial class Registation : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        //ddlCountry.DataSource = CountryManager.GetAllCountries();
        //ddlCountry.DataBind();
        //ddlCountry.DataTextField = "CountryName";
        //ddlCountry.DataValueField = "Id";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        CustomerItem c = new CustomerItem();
        bool addUser = true;



        if (txtForName.Text.Length < 1)
        {
            addUser = false;
            lblError.Text += "* Förnamnet måste vara minst 1 tecken <br />";
        }
        if (txtSurName.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Efternamnet måste vara minst 5 tecken <br />";
        }
        if (txtAddress.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Adressen måste vara minst 5 tecken <br />";
        }
        if (txtEpost.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Email måste vara minst 5 tecken <br />";
        }
        if (txtMobile.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Mobiltelefon måste vara minst 5 tecken <br />";
        }
        if (txtTelephone.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Telefon måste vara minst 5 tecken <br />";
        }
        if (txtPassword.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Lösenordet måste vara minst 5 tecken <br />";
        }
        if (txtPassword.Text != txtPassword2.Text)
        {
            addUser = false;
            lblError.Text += "* Lösenorden måste stämma överens <br />";
        }
        if (txtPostNumber.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Postnumret måste vara minst 5 tecken <br />";
        }
        if (txtSocialNumber.Text.Length < 12)
        {
            addUser = false;
            lblError.Text += "* Personnummret måste vara minst 12 tecken <br />";
        }

        if (addUser)
        {
            c.FirstName = txtForName.Text;
            c.LastName = txtSurName.Text;
            c.Adress = txtAddress.Text;
            c.Email = txtEpost.Text;
            c.MobileNumber = txtMobile.Text;
            c.Phone = txtTelephone.Text;
            c.Password = StringHelper.HashWithMD5(txtPassword.Text);
            c.ZipCode = txtPostNumber.Text;
            c.Activated = false;
            c.ActivationCode = StringHelper.RandomString(20);
            c.Country = new CountryItem();
            c.Country.Id = Convert.ToInt64(ddlCountry.SelectedValue);
            c.DateOfBirth = txtSocialNumber.Text;
            c.NewsLetter = false;
            c.Role = new RoleItem();
            c.Role.Id = 1;

            if (!CustomerManager.InsertCustomer(c))
                lblError.Text += "Något Gick fel! Försök igen senare.  <br />";
            else
            {
                lblError.Text += "Du har nu regeristrerat dig. För att kunna börja använda ditt konto så måste du aktivera det genom ett mail som strax kommer skickas till dig.  <br />";
                MailManager.SendMail(c);
            }
        }
        //TODO: Fixa emailvalidation så de bara går att skriva mailadresser
    }
}
