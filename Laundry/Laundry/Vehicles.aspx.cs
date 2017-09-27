using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class Vehicles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
                Response.Redirect("AdminLogin.aspx");
            if (!Page.IsPostBack)
            vehicles();
        }

        public  void vehicles()
        {
            DataTable dtVehicle = LogicKernal.Vehicles.GetAllVehicles();
            gdvVehicle.DataSource = dtVehicle;
            gdvVehicle.DataBind();
        }

        protected void gdvVehicle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label LblAgentID = (System.Web.UI.WebControls.Label)e.Row.FindControl("LblAgentID");
                DataTable dtAgent = new DataTable();
                dtAgent = LogicKernal.LaundryAgent.GetLaundryAgentByID(Convert.ToInt32(LblAgentID.Text));
                System.Web.UI.WebControls.Label lblAgentName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAgentName");
                lblAgentName.Text = dtAgent.Rows[0]["AgentName"].ToString();

                System.Web.UI.WebControls.Label LblAdminID = (System.Web.UI.WebControls.Label)e.Row.FindControl("LblAdminID");
                DataTable DtAdmin = new DataTable();
                dtAgent = LogicKernal.LaundryAdmin.GetLaundryAdminByID(Convert.ToInt32(LblAdminID.Text));
                System.Web.UI.WebControls.Label lblAdminName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAdminName");
                if (dtAgent.Rows.Count > 0)
                    lblAdminName.Text = dtAgent.Rows[0]["AdminName"].ToString();
            }
                        
        }

        protected void gdvVehicle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditVehicle")
            {
                Response.Redirect("AddVehicle.aspx?VehicleID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeleteVehicle")
            {
                LogicKernal.Vehicles.DeleteVehicles(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("Vehicles.aspx");
            }
        }
    }
}