using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AllOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
                Response.Redirect("AdminLogin.aspx");
            if (!Page.IsPostBack)
            {
                PlacedOrders();
                ToBePick();
                Picked();
                Processing();
                Delivered();
                cancelorders();
                DeclinedOrders();
            }
        }

        public void cancelorders()
        {
            DataTable dtcancel = LogicKernal.Orders.CancledOrders();
            grdcanceled.DataSource = dtcancel;
            grdcanceled.DataBind();
        }
        public void PlacedOrders()
        {
            DataTable dtOrders = LogicKernal.Orders.PlacedOrders();
            if (dtOrders.Rows.Count > 0)
            {
                gdvPlaced.DataSource = dtOrders;
                gdvPlaced.DataBind();
            }
            else
                lblPlaced.Text = "No new Order";
        }

        public void Processing()
        {
            DataTable dtOrders = LogicKernal.Orders.InProcessOrders();
            gdvProcess.DataSource = dtOrders;
            gdvProcess.DataBind();
        }

        public void Delivered()
        {
            DataTable dtOrders = LogicKernal.Orders.DeliveredOrders();
            gdvDelivered.DataSource = dtOrders;
            gdvDelivered.DataBind();
        }

        public void ToBePick()
        {
            DataTable dtTopick = LogicKernal.Orders.GetToBePickOrder();
            gdvToPick.DataSource = dtTopick;
            gdvToPick.DataBind();
        }

        public void Picked()
        {
            DataTable DtPicked = LogicKernal.Orders.PickedOrders();
            gdvPicked.DataSource = DtPicked;
            gdvPicked.DataBind();
        }

        public void DeclinedOrders()
        {
            DataTable dtDeclined = LogicKernal.DeclinedOrders.GetOrderenabled();
            grdOrderReAssigned.DataSource = dtDeclined;
            grdOrderReAssigned.DataBind();
        }
        protected void gdvPlaced_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label LblCustomerID = (System.Web.UI.WebControls.Label)e.Row.FindControl("LblCustomerID");
                DataTable dtCustomer = new DataTable();
                dtCustomer = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt32(LblCustomerID.Text));
                System.Web.UI.WebControls.Label lblCustomerName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblCustomerName");

                System.Web.UI.WebControls.Label lblCustomerAdd = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblCustomerAdd");
                lblCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                lblCustomerName.Visible = true;
                lblCustomerAdd.Text = dtCustomer.Rows[0]["CustomerAddress"].ToString();

            }
         }

        protected void gdvToPick_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label LblCustomerID = (System.Web.UI.WebControls.Label)e.Row.FindControl("LblCustomerID");
                DataTable dtCustomer = new DataTable();
                dtCustomer = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt32(LblCustomerID.Text));
                System.Web.UI.WebControls.Label lblCustomerName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblCustomerName");

                System.Web.UI.WebControls.Label lblCustomerAdd = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblCustomerAdd");
                lblCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                lblCustomerName.Visible = true;
                lblCustomerAdd.Text = dtCustomer.Rows[0]["CustomerAddress"].ToString();

                System.Web.UI.WebControls.Label LblAgentID = (System.Web.UI.WebControls.Label)e.Row.FindControl("LblAgentID");
                DataTable dtAgent = new DataTable();
                dtAgent = LogicKernal.LaundryAgent.GetLaundryAgentByID(Convert.ToInt32(LblAgentID.Text));
                System.Web.UI.WebControls.Label lblAgentName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAgentName");
                lblAgentName.Text = dtAgent.Rows[0]["AgentName"].ToString();

                System.Web.UI.WebControls.Label LblAdminID = (System.Web.UI.WebControls.Label)e.Row.FindControl("LblAdminID");
                DataTable DtAdmin = new DataTable();
                dtAgent = LogicKernal.LaundryAdmin.GetLaundryAdminByID(Convert.ToInt32(LblAdminID.Text));
                System.Web.UI.WebControls.Label lblAdminName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAdminName");
                if(dtAgent.Rows.Count>0)
                lblAdminName.Text = dtAgent.Rows[0]["AdminName"].ToString();


            }
        }

        protected void gdvPlaced_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Assign")
            {
                Response.Redirect("Assignment.aspx?OrderID=" + e.CommandArgument.ToString());
            }
        }

        protected void gdvPicked_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Preview")
            {
                Response.Redirect("ViewOrderDetails.aspx?OrderID=" + e.CommandArgument.ToString());
            }
        }

        protected void gdvProcess_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Preview")
            {
                Response.Redirect("ViewOrderDetails.aspx?OrderID=" + e.CommandArgument.ToString());
            }
        }

        protected void gdvDelivered_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Preview")
            {
                Response.Redirect("ViewOrderDetails.aspx?OrderID=" + e.CommandArgument.ToString());
            }
        }

        protected void grdcanceled_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label LblCustomerID = (System.Web.UI.WebControls.Label)e.Row.FindControl("LblCustomerID");
                DataTable dtCustomer = new DataTable();
                dtCustomer = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt32(LblCustomerID.Text));
                System.Web.UI.WebControls.Label lblCustomerName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblCustomerName");

                System.Web.UI.WebControls.Label lblCustomerAdd = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblCustomerAdd");
                lblCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                lblCustomerName.Visible = true;
                lblCustomerAdd.Text = dtCustomer.Rows[0]["CustomerAddress"].ToString();

                System.Web.UI.WebControls.Label lblagentID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblagentID");
                DataTable dtAgent = new DataTable();
                dtAgent = LogicKernal.LaundryAgent.GetLaundryAgentByID(Convert.ToInt32(lblagentID.Text));
                System.Web.UI.WebControls.Label lblAgentName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAgentName");
                lblAgentName.Text = dtAgent.Rows[0]["AgentName"].ToString();

                System.Web.UI.WebControls.Label LblOrderID = (System.Web.UI.WebControls.Label)e.Row.FindControl("LblOrderID");
                DataTable dtDeclinedOrder = new DataTable();
                dtDeclinedOrder = LogicKernal.DeclinedOrders.GetOrderByorderID(Convert.ToInt32(LblOrderID.Text));
                System.Web.UI.WebControls.Label lbldeclinedRemarks = (System.Web.UI.WebControls.Label)e.Row.FindControl("lbldeclinedRemarks");
                lbldeclinedRemarks.Text = dtDeclinedOrder.Rows[0]["DeclinedRemarks"].ToString();
                System.Web.UI.WebControls.Label lbldeclinedDateTime = (System.Web.UI.WebControls.Label)e.Row.FindControl("lbldeclinedDateTime");
                lbldeclinedDateTime.Text = dtDeclinedOrder.Rows[0]["DateCreated"].ToString();
                System.Web.UI.WebControls.Label lblDeclined = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblDeclined");
                string Status = dtDeclinedOrder.Rows[0]["IsEnabled"].ToString();
                if (Status == "False")
                    lblDeclined.Text = "To Be Assigned";
                else
                    lblDeclined.Text = "Assigned to Other Agent";
            }
            }

        protected void grdcanceled_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Assign")
            {
                BusinessEntities.DeclinedOrders objDeclined = new BusinessEntities.DeclinedOrders();
                DataTable DtDeclinedOrders = LogicKernal.DeclinedOrders.GetOrderByorderID(Convert.ToInt32(e.CommandArgument));
                objDeclined.OrderDeclinedID = Convert.ToInt32(DtDeclinedOrders.Rows[0]["OrderDeclinedID"]);
                objDeclined.OrderID = Convert.ToInt32(DtDeclinedOrders.Rows[0]["OrderID"]);
                objDeclined.AgentID = Convert.ToInt32(DtDeclinedOrders.Rows[0]["AgentID"]);
                objDeclined.DateCreated = Convert.ToDateTime(DtDeclinedOrders.Rows[0]["DateCreated"]);
                objDeclined.DeclinedRemarks = DtDeclinedOrders.Rows[0]["DeclinedRemarks"].ToString();
                objDeclined.IsEnabled = Convert.ToBoolean("True");
                objDeclined.AdminID = Convert.ToInt32(DtDeclinedOrders.Rows[0]["AdminID"]);
                LogicKernal.DeclinedOrders.InsertUpdateDeclinedOrders(objDeclined);

                Response.Redirect("Assignment.aspx?OrderID=" + e.CommandArgument.ToString());
            }
        }

        protected void grdOrderReAssigned_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label LblOrderID = (System.Web.UI.WebControls.Label)e.Row.FindControl("LblOrderID");
                DataTable dtOrder = LogicKernal.Orders.GetOrdersByID(Convert.ToInt16(LblOrderID.Text));

                DataTable dtClient = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt32(dtOrder.Rows[0]["ClientID"]));

                System.Web.UI.WebControls.Label lblCustomerName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblCustomerName");

                System.Web.UI.WebControls.Label lblCustomerAdd = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblCustomerAdd");
                lblCustomerName.Text = dtClient.Rows[0]["CustomerName"].ToString();
                lblCustomerName.Visible = true;
                lblCustomerAdd.Text = dtClient.Rows[0]["CustomerAddress"].ToString();

                System.Web.UI.WebControls.Label lblagentID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblagentID");
                DataTable dtAgent = new DataTable();
                dtAgent = LogicKernal.LaundryAgent.GetLaundryAgentByID(Convert.ToInt32(lblagentID.Text));
                System.Web.UI.WebControls.Label lblAgentName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblAgentName");
                lblAgentName.Text = dtAgent.Rows[0]["AgentName"].ToString();
            }
            }
    }
}