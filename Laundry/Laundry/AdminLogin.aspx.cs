using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string AdminEmail = txtLoginEmail.Text;
            string adminpassword = txtloginPassword.Text;
            int AdminID = LogicKernal.LaundryAdmin.Login(AdminEmail, adminpassword);
            if (AdminID > 0)
            {
                Session["AdminID"] = AdminID;
                Response.Redirect("DashDefault.aspx");
            }
            else
                lblError.Text = "Can not Login";
            
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminRegister.aspx");
        }
    }
}