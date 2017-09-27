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
    public partial class AgentOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AgentID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    topickorders();
                    Picked();
                    Processed();
                    Delivered();
                    DeclinedOrders();
                }
            }
            else
                Response.Redirect("Agentlogin.aspx");
        }
        public void DeclinedOrders()
        {
            DataTable dtDeclined = LogicKernal.DeclinedOrders.GetOrderByAgentID(Convert.ToInt32(Session["AgentID"]));
            grdOrderReAssigned.DataSource = dtDeclined;
            grdOrderReAssigned.DataBind();
        }


        public void topickorders()
        {
            DataTable Dtpick = LogicKernal.Orders.AgentToBePickOrder(Convert.ToInt32(Session["AgentID"]));
            gdvToPick.DataSource = Dtpick;
            gdvToPick.DataBind();
        }
        public void Picked()
        {
            DataTable Dtpicked = LogicKernal.Orders.AgentPickedOrders(Convert.ToInt32(Session["AgentID"]));
            gdvPicked.DataSource = Dtpicked;
            gdvPicked.DataBind();
        }

        public void Processed()
        {
            DataTable Dtprocess = LogicKernal.Orders.AgentInProcessOrders(Convert.ToInt32(Session["AgentID"]));
            gdvProcess.DataSource = Dtprocess;
            gdvProcess.DataBind();
        }

        public void Delivered()
        {
            DataTable Dtdeliverd = LogicKernal.Orders.AgentDeliveredOrders(Convert.ToInt32(Session["AgentID"]));
            gdvDelivered.DataSource = Dtdeliverd;
            gdvDelivered.DataBind();
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

            }
        }

    

        protected void gdvToPick_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Completed")
            {
                Int32 OrderID=Convert.ToInt32( e.CommandArgument);
                DataTable dtorder = LogicKernal.Orders.GetOrdersByID(OrderID);

                BusinessEntities.Orders objOrder = new BusinessEntities.Orders();
                objOrder.OrderID = OrderID;
                objOrder.AgentID = Convert.ToInt32(dtorder.Rows[0]["AgentID"]);
                objOrder.AdminID = Convert.ToInt32(Session["AdminID"]);
                objOrder.ClientID = Convert.ToInt32(dtorder.Rows[0]["ClientID"]);
                objOrder.DateCreation = Convert.ToDateTime(dtorder.Rows[0]["DateCreation"]);
                objOrder.RequestPickupDate = Convert.ToDateTime(dtorder.Rows[0]["RequestPickupDate"]);
                objOrder.PickupTimeSlot = dtorder.Rows[0]["PickupTimeSlot"].ToString();
                objOrder.RequestDropOffDate = Convert.ToDateTime(dtorder.Rows[0]["RequestDropOffDate"]);
                objOrder.DropOffTimeSlot = dtorder.Rows[0]["DropOffTimeSlot"].ToString();
                objOrder.PickupDateTime = DateTime.Now;
                objOrder.DropOfDateTime = Convert.ToDateTime(dtorder.Rows[0]["DropOfDateTime"]);
                objOrder.Status = "Picked";
                objOrder.IsEbabled = Convert.ToBoolean(dtorder.Rows[0]["IsEbabled"]);
                objOrder.Remarks = dtorder.Rows[0]["Remarks"].ToString();
                objOrder.OrderNumber = dtorder.Rows[0]["OrderNumber"].ToString();
                if (LogicKernal.Orders.InsertUpdateOrders(objOrder).Rows.Count > 0)
                    Response.Redirect("AgentOrders.aspx");
            }

            if (e.CommandName == "Cancel")
            {
                string DeclinedRemarks= (string)(HttpContext.Current.Session["DeclinedRemarks"]);
                if(DeclinedRemarks!="")
                {
                    Int32 OrderID = Convert.ToInt32(e.CommandArgument);
                    DataTable dtorder = LogicKernal.Orders.GetOrdersByID(OrderID);

                    BusinessEntities.Orders objOrder = new BusinessEntities.Orders();
                    objOrder.OrderID = OrderID;
                    objOrder.AgentID = Convert.ToInt32(Session["AgentID"]);
                    objOrder.AdminID = Convert.ToInt32(dtorder.Rows[0]["AdminID"]);
                    objOrder.ClientID = Convert.ToInt32(dtorder.Rows[0]["ClientID"]);
                    objOrder.DateCreation = Convert.ToDateTime(dtorder.Rows[0]["DateCreation"]);
                    objOrder.RequestPickupDate = Convert.ToDateTime(dtorder.Rows[0]["RequestPickupDate"]);
                    objOrder.PickupTimeSlot = dtorder.Rows[0]["PickupTimeSlot"].ToString();
                    objOrder.RequestDropOffDate = Convert.ToDateTime(dtorder.Rows[0]["RequestDropOffDate"]);
                    objOrder.DropOffTimeSlot = dtorder.Rows[0]["DropOffTimeSlot"].ToString();
                    objOrder.PickupDateTime = Convert.ToDateTime(dtorder.Rows[0]["PickupDateTime"]);
                    objOrder.DropOfDateTime = Convert.ToDateTime(dtorder.Rows[0]["DropOfDateTime"]);
                    objOrder.Status = "Canceled";
                    objOrder.IsEbabled = Convert.ToBoolean(dtorder.Rows[0]["IsEbabled"]);
                    objOrder.Remarks = dtorder.Rows[0]["Remarks"].ToString();

                    BusinessEntities.DeclinedOrders objDeclined = new BusinessEntities.DeclinedOrders();
                    objDeclined.OrderDeclinedID = 0;
                    objDeclined.OrderID = OrderID;
                    objDeclined.AgentID = Convert.ToInt32(Session["AgentID"]);
                    objDeclined.AdminID = Convert.ToInt32(dtorder.Rows[0]["AdminID"]);
                    objDeclined.DateCreated = System.DateTime.Now;
                    objDeclined.IsEnabled = false;
                    objDeclined.DeclinedRemarks = DeclinedRemarks;
                    LogicKernal.DeclinedOrders.InsertUpdateDeclinedOrders(objDeclined);

                    objOrder.OrderNumber = dtorder.Rows[0]["OrderNumber"].ToString();
                    if (LogicKernal.Orders.InsertUpdateOrders(objOrder).Rows.Count > 0)
                    {
                        HttpContext.Current.Session["DeclinedRemarks"] = null;
                        Response.Redirect("AgentOrders.aspx");
                    }
                }
                Response.Redirect("AgentOrders.aspx");
            }
            }
        [WebMethod]
        public static string declinedOrdersRemarks(string DeclinedRemarks)
        {
            var Remarks = DeclinedRemarks;
            HttpContext.Current.Session["DeclinedRemarks"] = Remarks;
            return "1";

        }
        protected void gdvPicked_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Completed")
            {
                Int32 OrderID = Convert.ToInt32(e.CommandArgument);
                DataTable dtorder = LogicKernal.Orders.GetOrdersByID(OrderID);

                BusinessEntities.Orders objOrder = new BusinessEntities.Orders();
                objOrder.OrderID = OrderID;
                objOrder.AgentID = Convert.ToInt32(dtorder.Rows[0]["AgentID"]);
                objOrder.AdminID = Convert.ToInt32(Session["AdminID"]);
                objOrder.ClientID = Convert.ToInt32(dtorder.Rows[0]["ClientID"]);
                objOrder.DateCreation = Convert.ToDateTime(dtorder.Rows[0]["DateCreation"]);
                objOrder.RequestPickupDate = Convert.ToDateTime(dtorder.Rows[0]["RequestPickupDate"]);
                objOrder.PickupTimeSlot = dtorder.Rows[0]["PickupTimeSlot"].ToString();
                objOrder.RequestDropOffDate = Convert.ToDateTime(dtorder.Rows[0]["RequestDropOffDate"]);
                objOrder.DropOffTimeSlot = dtorder.Rows[0]["DropOffTimeSlot"].ToString();
                objOrder.PickupDateTime = Convert.ToDateTime(dtorder.Rows[0]["PickupDateTime"]);
                objOrder.DropOfDateTime = Convert.ToDateTime(dtorder.Rows[0]["DropOfDateTime"]);
                objOrder.Status = "InProcess";
                objOrder.IsEbabled = Convert.ToBoolean(dtorder.Rows[0]["IsEbabled"]);
                objOrder.Remarks = dtorder.Rows[0]["Remarks"].ToString();
                objOrder.OrderNumber = dtorder.Rows[0]["OrderNumber"].ToString();
                if (LogicKernal.Orders.InsertUpdateOrders(objOrder).Rows.Count > 0)
                    Response.Redirect("AgentOrders.aspx");
            }
            if (e.CommandName == "Details")
            {
                Response.Redirect("AddOrderDetail.aspx?OrderID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Preview")
            {
                Response.Redirect("ViewOrderDetails.aspx?OrderID=" + e.CommandArgument.ToString());
            }
        }

        protected void gdvProcess_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Completed")
            {
                Int32 OrderID = Convert.ToInt32(e.CommandArgument);
                DataTable dtorder = LogicKernal.Orders.GetOrdersByID(OrderID);

                BusinessEntities.Orders objOrder = new BusinessEntities.Orders();
                objOrder.OrderID = OrderID;
                objOrder.AgentID = Convert.ToInt32(dtorder.Rows[0]["AgentID"]);
                objOrder.AdminID = Convert.ToInt32(Session["AdminID"]);
                objOrder.ClientID = Convert.ToInt32(dtorder.Rows[0]["ClientID"]);
                objOrder.DateCreation = Convert.ToDateTime(dtorder.Rows[0]["DateCreation"]);
                objOrder.RequestPickupDate = Convert.ToDateTime(dtorder.Rows[0]["RequestPickupDate"]);
                objOrder.PickupTimeSlot = dtorder.Rows[0]["PickupTimeSlot"].ToString();
                objOrder.RequestDropOffDate = Convert.ToDateTime(dtorder.Rows[0]["RequestDropOffDate"]);
                objOrder.DropOffTimeSlot = dtorder.Rows[0]["DropOffTimeSlot"].ToString();
                objOrder.PickupDateTime = Convert.ToDateTime(dtorder.Rows[0]["PickupDateTime"]);
                objOrder.DropOfDateTime = DateTime.Now;
                objOrder.Status = "DELIVERED";
                objOrder.IsEbabled = Convert.ToBoolean(dtorder.Rows[0]["IsEbabled"]);
                objOrder.Remarks = dtorder.Rows[0]["Remarks"].ToString();
                objOrder.OrderNumber = dtorder.Rows[0]["OrderNumber"].ToString();
                if (LogicKernal.Orders.InsertUpdateOrders(objOrder).Rows.Count > 0)
                    Response.Redirect("AgentOrders.aspx");
            }
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

        protected void grdOrderReAssigned_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblOrderID = (Label)e.Row.FindControl("LblOrderID");
                DataTable dtOrder = LogicKernal.Orders.GetOrdersByID(Convert.ToInt16(LblOrderID.Text));

                Label lblOrderno = (Label)e.Row.FindControl("lblOrderno");
                lblOrderno.Text = dtOrder.Rows[0]["OrderNumber"].ToString();

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