using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AgentDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AgentID"] != null)
                {
                    DataTable DtAgent = LogicKernal.LaundryAgent.GetLaundryAgentByID(Convert.ToInt32(Session["AgentID"]));
                    lblname.Text = DtAgent.Rows[0]["AgentName"].ToString();
                    lblEmail.Text = DtAgent.Rows[0]["AgentEmail"].ToString();
                    lblphone.Text = DtAgent.Rows[0]["AgentPhoneNO"].ToString();
                    lbljoind.Text = DtAgent.Rows[0]["DateCreated"].ToString();
                    imgCustomer.ImageUrl = DtAgent.Rows[0]["AgentImage"].ToString();
                }

                else
                    Response.Redirect("agentlogin.aspx");

                record();
            }
        }

        public void record()
        {
            DataTable dtTopick = LogicKernal.Orders.AgentToBePickOrder(Convert.ToInt32(Session["AgentID"]));
            lblPlace.Text = dtTopick.Rows.Count.ToString();
            DataTable dtPicked=LogicKernal.Orders.AgentPickedOrders(Convert.ToInt32(Session["AgentID"]));
            lblPicked.Text = dtPicked.Rows.Count.ToString();
            DataTable dtProcess = LogicKernal.Orders.AgentInProcessOrders(Convert.ToInt32(Session["AgentID"]));
            lblprocess.Text = dtProcess.Rows.Count.ToString();
            DataTable dtDeliverd = LogicKernal.Orders.AgentDeliveredOrders(Convert.ToInt32(Session["AgentID"]));
            LblDeliverd.Text = dtDeliverd.Rows.Count.ToString();
        }
    }
}