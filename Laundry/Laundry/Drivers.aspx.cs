using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class Drivers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
                Response.Redirect("AdminLogin.aspx");
            if (!Page.IsPostBack)
                LoadDrivers();
        }

        protected void BtnDriverAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDriver.aspx");
        }

        public void LoadDrivers()
        {
            DataTable dtDriver = LogicKernal.LaundryDrivers.GetAllLaundryDrivers();
            gdvDriver.DataSource = dtDriver;
            gdvDriver.DataBind();
        }

        protected void gdvDriver_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label lblAdminID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAdminID");
                DataTable dtAdmin = new DataTable();
                dtAdmin = LogicKernal.LaundryAdmin.GetLaundryAdminByID(Convert.ToInt32(lblAdminID.Text));
                System.Web.UI.WebControls.Label lblAdminName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAdminName");
                lblAdminName.Text = dtAdmin.Rows[0]["AdminName"].ToString();

                System.Web.UI.WebControls.Label lblAgentID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAgentID");
                DataTable dtAgent = new DataTable();
                dtAgent = LogicKernal.LaundryAgent.GetLaundryAgentByID(Convert.ToInt32(lblAgentID.Text));
                System.Web.UI.WebControls.Label lblAgentName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAgentName");
                lblAgentName.Text = dtAgent.Rows[0]["AgentName"].ToString();
            }
        }

        protected void gdvDriver_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditDriver")
            {
                Response.Redirect("AddDriver.aspx?DriverID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeleteDriver")
            {
                LogicKernal.LaundryDrivers.DeleteLaundryDrivers(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("AdminDefault.aspx");
            }
        }
    }
}