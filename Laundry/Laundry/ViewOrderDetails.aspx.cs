using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class ViewOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["OrderID"]!=null)
            {
                ViewDetail();
                vieworder();
            }
            

        }

        public void vieworder()
        {
            DataTable dtOrder = LogicKernal.Orders.GetOrdersByID(Convert.ToInt32(Request.QueryString["OrderID"]));
            lblOrderDate.Text = dtOrder.Rows[0]["DateCreation"].ToString();
            lblOrderID.Text = dtOrder.Rows[0]["OrderNumber"].ToString();
            LblPickedDateTime.Text = dtOrder.Rows[0]["PickupDateTime"].ToString();
            lblDropDateTime.Text = dtOrder.Rows[0]["DropOfDateTime"].ToString();
            int CLientID=Convert.ToInt32( dtOrder.Rows[0]["ClientID"]);
            DataTable dtcustomer = LogicKernal.CustomerProfile.GetCustomerProfileByID(CLientID);
            lblName.Text = dtcustomer.Rows[0]["CustomerName"].ToString();
            LblAddress.Text = dtcustomer.Rows[0]["CustomerAddress"].ToString();
        }

        public void ViewDetail()
        {
            DataTable dtDetail = LogicKernal.OrderDetail.GetOrderDetailbyOrderID(Convert.ToInt32(Request.QueryString["OrderID"]));
            Gdvorder.DataSource = dtDetail;
            Gdvorder.DataBind();
            GrandTotal();
        }

        protected void Gdvorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label lblItemID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblItemID");
                DataTable dtItem = new DataTable();
                dtItem = LogicKernal.Items.GetItemsByID(Convert.ToInt32(lblItemID.Text));
                System.Web.UI.WebControls.Label lblItemName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblItemName");
                lblItemName.Text = dtItem.Rows[0]["ItemName"].ToString();

                Label Quantity = (Label)e.Row.FindControl("lblqty");
              Label UnitPrice = (Label)e.Row.FindControl("lblPrice");
                Label lbltotal = (Label)e.Row.FindControl("lbltotal");
                lbltotal.Text = (Convert.ToDecimal(Quantity.Text) * Convert.ToDecimal(UnitPrice.Text)).ToString();


            }
        }

        private void GrandTotal()
        {
            int GTotal = 0;
            for (int i = 0; i < Gdvorder.Rows.Count; i++)
            {
                String total = (Gdvorder.Rows[i].FindControl("lbltotal") as Label).Text;
                GTotal += Convert.ToUInt16(total);
            }
            Label1.Text = GTotal.ToString();
        }
    }
}