using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
                Response.Redirect("AdminLogin.aspx");
            AllClients();
        }
        public void AllClients()
        {
            DataTable dtClients = LogicKernal.CustomerProfile.GetAllCustomerProfile();
            grdClients.DataSource = dtClients;
            grdClients.DataBind();
        }
    }
}