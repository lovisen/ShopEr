using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for MailManager
/// </summary>
public class MailManager
{
	public MailManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool SendMail(CustomerItem c)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(c.Email);
            mailMessage.Subject = "Aktivera Ditt Konto";
            mailMessage.Body = string.Format(
                "Hej {0} {1}, <br /><br /> För att kunna börja använda ditt konto så måste du aktivera ditt konto.<br />" +
                "Klicka på länken nedan för att kunna göra detta:<br />" +
                "<a href=\"{2}ConfirmAccount.aspx?ActivationCode={3}\">{2}ConfirmAccount.aspx?ActivationCode={3}</a>"
                , c.FirstName, c.LastName, "http://localhost:1453/", c.ActivationCode);
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("lbsshoper@gmail.com", "ShopEr");

            // Create the credentials to login to the gmail account associated with my custom domain
            string sendEmailsFrom = "lbsshoper@gmail.com";
            string sendEmailsFromPassword = "abc123abc";
            NetworkCredential cred = new NetworkCredential(sendEmailsFrom, sendEmailsFromPassword);
            SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
            mailClient.EnableSsl = true;
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailClient.UseDefaultCredentials = false;
            mailClient.Timeout = 20000;
            mailClient.Credentials = cred;
            mailClient.EnableSsl = true;
            mailClient.Send(mailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
