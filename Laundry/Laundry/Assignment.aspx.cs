using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Laundry
{
    public partial class Assignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Agents();

            if (Session["AdminID"] == null)
                Response.Redirect("AdminLogin.aspx");
        }

        public void Agents()
        {
            DataTable dtAgent = LogicKernal.LaundryAgent.GetAllLaundryAgent();
            ddlAgent.DataSource = dtAgent;
            ddlAgent.DataBind();
            ddlAgent.DataTextField = "AgentName";
            ddlAgent.DataValueField = "AgentID";
            ddlAgent.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(Request.QueryString["OrderID"]) != 0)
            {
                DataTable dtorder = LogicKernal.Orders.GetOrdersByID(Convert.ToInt16(Request.QueryString["OrderID"]));

                BusinessEntities.Orders objOrder = new BusinessEntities.Orders();
                objOrder.OrderID = Convert.ToInt16(Request.QueryString["OrderID"]);
                objOrder.AgentID = Convert.ToInt32(ddlAgent.SelectedValue);
                objOrder.AdminID = Convert.ToInt32(Session["AdminID"]);
                objOrder.ClientID = Convert.ToInt32(dtorder.Rows[0]["ClientID"]);
                objOrder.DateCreation = Convert.ToDateTime(dtorder.Rows[0]["DateCreation"]);
                objOrder.RequestPickupDate = Convert.ToDateTime(dtorder.Rows[0]["RequestPickupDate"]);
                objOrder.PickupTimeSlot = dtorder.Rows[0]["PickupTimeSlot"].ToString();
                objOrder.RequestDropOffDate = Convert.ToDateTime(dtorder.Rows[0]["RequestDropOffDate"]);
                objOrder.DropOffTimeSlot = dtorder.Rows[0]["DropOffTimeSlot"].ToString();
                objOrder.PickupDateTime = Convert.ToDateTime(dtorder.Rows[0]["PickupDateTime"]);
                objOrder.DropOfDateTime = Convert.ToDateTime(dtorder.Rows[0]["DropOfDateTime"]);
                objOrder.Status = "Assigned";
                objOrder.IsEbabled = Convert.ToBoolean(dtorder.Rows[0]["IsEbabled"]);
                objOrder.Remarks = dtorder.Rows[0]["Remarks"].ToString();
                objOrder.OrderNumber = dtorder.Rows[0]["OrderNumber"].ToString();
                if (LogicKernal.Orders.InsertUpdateOrders(objOrder).Rows.Count > 0)
                    Response.Redirect("AdminDefault.aspx");
                else
                    lblerror.Text = "Try Again";
            }
        }
    }
}