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
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        CustomerItem c = new CustomerItem();
        bool addUser = true;

        if (txtForName.Text.Length < 1)
        {
            addUser = false;
            lblError.Text += "* Förnamnet måste vara minst 1 tecken\n";
        }
        if (txtSurName.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Efternamnet måste vara minst 5 tecken\n";
        }
        if (txtAddress.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Adressen måste vara minst 5 tecken\n";
        }
        if (txtEpost.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Email måste vara minst 5 tecken\n";
        }
        if (txtMobile.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Mobiltelefon måste vara minst 5 tecken\n";
        }
        if (txtTelephone.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Telefon måste vara minst 5 tecken\n";
        }
        if (txtPassword.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Lösenordet måste vara minst 5 tecken\n";
        }
        if (txtPostNumber.Text.Length < 5)
        {
            addUser = false;
            lblError.Text += "* Postnumret måste vara minst 5 tecken\n";
        }
        if (addUser)
        {
            c.FirstName = txtForName.Text;
            c.LastName = txtSurName.Text;
            c.Adress = txtAddress.Text;
            c.Email = txtEpost.Text;
            c.MobileNumber = txtMobile.Text;
            c.Phone = txtTelephone.Text;
            c.Password = txtPassword.Text;
            c.ZipCode = txtPostNumber.Text;
            c.Activated = false;
            c.ActivationCode = StringHelper.RandomString(20);
            c.Country = new CountryItem();
            c.Country.Id = 1;
            c.DateOfBirth = DateTime.Now;
            c.NewsLetter = false;
            c.Role = new RoleItem();
            c.Role.Id = 1;

            if (!CustomerManager.InsertCustomer(c))
                lblError.Text += "Något Gick fel! Försök igen senare.";
        }
    }
}
