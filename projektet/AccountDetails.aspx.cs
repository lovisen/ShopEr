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

public partial class AccountDetails : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!UserAuthentication.IsAuthenticated())
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            CustomerItem c = CustomerManager.GetCustomerDetails(Convert.ToInt64( UserAuthentication.getUserID()));
            txtAddress.Text = c.Adress;
            txtEpost.Text = c.Email;
            txtForName.Text = c.FirstName;
            txtMobile.Text = c.MobileNumber;
            txtPostNumber.Text = c.ZipCode;
            txtSocialNumber.Text = c.DateOfBirth;
            txtSurName.Text = c.LastName;
            txtTelephone.Text = c.Phone;
            txtCity.Text = c.City;
            chbNewsLetter.Checked = c.NewsLetter;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        CustomerItem c = new CustomerItem();
        bool updateUser = true;

        if (txtForName.Text.Length < 1)
        {
            updateUser = false;
            lblError.Text += "* Förnamnet måste vara minst 1 tecken <br />";
        }
        if (txtSurName.Text.Length < 5)
        {
            updateUser = false;
            lblError.Text += "* Efternamnet måste vara minst 5 tecken <br />";
        }
        if (txtAddress.Text.Length < 5)
        {
            updateUser = false;
            lblError.Text += "* Adressen måste vara minst 5 tecken <br />";
        }
        if (!StringHelper.isEmail(txtEpost.Text))
        {
            updateUser = false;
            lblError.Text += "* Du har inte skrivit en riktig epostadress <br />";
        }
        if (txtMobile.Text.Length < 5)
        {
            updateUser = false;
            lblError.Text += "* Mobiltelefon måste vara minst 5 tecken <br />";
        }
        if (txtTelephone.Text.Length < 5)
        {
            updateUser = false;
            lblError.Text += "* Telefon måste vara minst 5 tecken <br />";
        }
        
        
        if (txtPostNumber.Text.Length < 5)
        {
            updateUser = false;
            lblError.Text += "* Postnumret måste vara minst 5 tecken <br />";
        }
        if (txtSocialNumber.Text.Length < 12)
        {
            updateUser = false;
            lblError.Text += "* Personnummret måste vara minst 12 tecken <br />";
        }
        if (txtCity.Text.Length < 2)
        {
            updateUser = false;
            lblError.Text += "* Stad måste vara minst 2 tecken <br />";
        }

        if (updateUser)
        {
            c.FirstName = txtForName.Text;
            c.LastName = txtSurName.Text;
            c.Adress = txtAddress.Text;
            c.Email = txtEpost.Text;
            c.MobileNumber = txtMobile.Text;
            c.Phone = txtTelephone.Text;
            //c.Password = StringHelper.HashWithMD5(txtPassword.Text);
            c.ZipCode = txtPostNumber.Text;
            //c.Activated = false;
            //c.ActivationCode = StringHelper.RandomString(20);
            c.Country = new CountryItem();
            c.Country.Id = Convert.ToInt64(ddlCountry.SelectedValue);
            c.DateOfBirth = txtSocialNumber.Text;
            c.NewsLetter = chbNewsLetter.Checked;
            c.Role = new RoleItem();
            c.City = txtCity.Text;
            c.Id = Convert.ToInt64( UserAuthentication.getUserID());

            if (!CustomerManager.UpdateCustomerDetails(c))
                lblError.Text += "Något Gick fel! Försök igen senare.  <br />";
            else
            {
                lblError.Text += "Uppdateringen Lyckades.  <br />";
            }
        }
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        CustomerItem c = new CustomerItem();
        bool updatePassword = true;
        if (txtPassword.Text.Length < 5)
        {
            updatePassword = false;
            lblError.Text += "* Lösenordet måste vara minst 5 tecken <br />";
        }
        if (txtPassword.Text != txtPassword2.Text)
        {
            updatePassword = false;
            lblError.Text += "* Lösenorden måste stämma överens <br />";
        }

        if (updatePassword)
        {
            
            c.Password = StringHelper.HashWithMD5(txtPassword.Text);

            c.Id = Convert.ToInt64( UserAuthentication.getUserID());

            if (!CustomerManager.UpdateCustomerPassword(c))
                lblError.Text += "Något Gick fel! Försök igen senare.  <br />";
            else
            {
                lblError.Text += "Du har nu uppdaterat ditt lösenord.  <br />";
            }
        }
    }
}
