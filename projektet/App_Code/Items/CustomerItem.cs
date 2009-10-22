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

/// <summary>
/// Summary description for CustomerItem
/// </summary>
public class CustomerItem : BaseStructure<long>
{
	public CustomerItem()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Adress { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public bool NewsLetter { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public RoleItem Role { get; set; }
    public string ZipCode { get; set; }
    public CountryItem Country { get; set; }
    public string ActivationCode { get; set; }
    public bool Activated { get; set; }
}
