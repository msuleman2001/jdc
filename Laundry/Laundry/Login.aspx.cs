using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;



namespace Laundry
{
    public partial class LoginRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtLoginEmail.Text = Request.Cookies["UserName"].Value;
                    txtloginPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            int ClientID = 0;
            string CustomerEmail = txtLoginEmail.Text;
            string CustomerPassword = txtloginPassword.Text;
            ClientID = LogicKernal.CustomerProfile.Login(CustomerEmail, CustomerPassword);
            if(ClientID!=0)
            {
                Session["ClientID"] = ClientID;
                Response.Redirect("Profile.aspx");
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Invalid User Name Password";
            }
            if (rememberme.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }
            Response.Cookies["UserName"].Value = txtloginPassword.Text.Trim();
            Response.Cookies["Password"].Value = txtloginPassword.Text.Trim();
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}