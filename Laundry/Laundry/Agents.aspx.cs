using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class Agents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
                Response.Redirect("AdminLogin.aspx");

            if (!Page.IsPostBack)
            ViewAgents();
        }
        protected void btnAgent_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAgent.aspx");
        }

        public void ViewAgents()
        {
            DataTable DtAgents = LogicKernal.LaundryAgent.GetAllLaundryAgent();
            gdvAgents.DataSource = DtAgents;
            gdvAgents.DataBind();
        }
        protected void gdvAgents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label lblAdminID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAdminID");
                DataTable dtAdmin = new DataTable();
                dtAdmin = LogicKernal.LaundryAdmin.GetLaundryAdminByID(Convert.ToInt32(lblAdminID.Text));
                System.Web.UI.WebControls.Label lblAdminName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAdminName");
                lblAdminName.Text = dtAdmin.Rows[0]["AdminName"].ToString();
            }
        }

        protected void gdvAgents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditAgent")
            {
                Response.Redirect("AddAgent.aspx?AgentID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeleteAgent")
            {
                LogicKernal.LaundryAgent.DeleteLaundryAgent(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("AdminDefault.aspx");
            }
        }
    }
}