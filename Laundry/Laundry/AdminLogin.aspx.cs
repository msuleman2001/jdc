using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

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

        [System.Web.Services.WebMethod]
        public static string notification()
        {
            DataTable dtplaced = LogicKernal.Orders.PlacedOrders();
            int placed = dtplaced.Rows.Count;
            DataTable dtcancled = LogicKernal.Orders.CancledOrders();
            int cancled = dtcancled.Rows.Count;
            int total = placed + cancled;
            string json_string = "";
            json_string = total.ToString();
            return json_string;
            
        }
    }
}