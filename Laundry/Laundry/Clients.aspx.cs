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
            if(!Page.IsPostBack)
            AllClients();
        }
        public void AllClients()
        {
            DataTable dtClients = LogicKernal.CustomerProfile.GetAllCustomerProfile();
            grdClients.DataSource = dtClients;
            grdClients.DataBind();
        }

        protected void grdClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditClient")
            {
                Response.Redirect("EditClientProfile.aspx?ClientID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "deleteClient")
            {
                LogicKernal.CustomerProfile.DeleteCustomerProfile(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("Clients.aspx");
            }
        }
    }
}