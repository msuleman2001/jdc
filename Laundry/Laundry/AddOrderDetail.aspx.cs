using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AddOrderDetail : System.Web.UI.Page
    {
        DataTable dtItemsDetails = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AgentID"] == null)
                Response.Redirect("Agentlogin.aspx");
            if(!Page.IsPostBack)
            {
                viewItems();
                viewDetail();
            }
            if (Session["dtItemDetails"] == null)
            {
                
                DataColumn colItemID = new DataColumn("ItemID");
                DataColumn colItemName = new DataColumn("ItemName");
                DataColumn colItemUnitPrice = new DataColumn("ItemUnitPrice", typeof(decimal));
                DataColumn colQuantity = new DataColumn("Quantity", typeof(decimal));
                DataColumn colTotal = new DataColumn("Total", typeof(decimal), "Quantity * ItemUnitPrice");

               
                dtItemsDetails.Columns.Add(colItemID);
                dtItemsDetails.Columns.Add(colItemName);
                dtItemsDetails.Columns.Add(colItemUnitPrice);
                dtItemsDetails.Columns.Add(colQuantity);
                dtItemsDetails.Columns.Add(colTotal);
            }
            else
                dtItemsDetails = (DataTable)Session["dtItemDetails"];
                


        }

        public void viewItems()
        {
            DataTable dtItems = LogicKernal.Items.GetAllItems();
            ddlItems.DataSource = dtItems;
            ddlItems.DataBind();
            ddlItems.DataTextField = "ItemName";
            ddlItems.DataValueField = "ItemID";
            ddlItems.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            int item_id = Convert.ToInt32(ddlItems.SelectedValue);
            DataTable dtItems = LogicKernal.Items.GetItemsByID(item_id);
            bool is_exist = false;
            foreach (DataRow dr in dtItemsDetails.Rows)
            {
                //if item already exists in table then update quantity
                if (Convert.ToInt32(dr["ItemID"]) == item_id)
                {
                    dr["Quantity"] = Convert.ToInt32(dr["Quantity"]) + Convert.ToInt32(txtQty.Text);
                    is_exist = true;
                    break;
                }
            }

            //if item not exist in table then insert new item
            if (!is_exist)
            {
                DataRow dr = dtItemsDetails.NewRow();

                dr["ItemID"] = Convert.ToInt32(ddlItems.SelectedValue);
                dr["ItemName"] = dtItems.Rows[0]["ItemName"];
                dr["ItemUnitPrice"] = dtItems.Rows[0]["UnitPrice"];
                dr["Quantity"] = txtQty.Text;
                dtItemsDetails.Rows.Add(dr);
            }
            Session["dtItemDetails"] = dtItemsDetails;
            
            viewDetail();
        }

        public void viewDetail()
        {
            Gdvorder.DataSource = dtItemsDetails;
            Gdvorder.DataBind();
            GrandTotal();
        }

    
        private void GrandTotal()
        {
            int GTotal = 0;
            for (int i = 0; i < Gdvorder.Rows.Count; i++)
            {
                String total = (Gdvorder.Rows[i].FindControl("lbltotal") as Label).Text;
                GTotal += Convert.ToUInt16(total);
            }
            lbltotalbill.Text = GTotal.ToString();
        }

        protected void Gdvorder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditOrderDetail")
            {
                DataRow[] rows = dtItemsDetails.Select("ItemID = " + e.CommandArgument.ToString());
                foreach (DataRow r in rows)
                    dtItemsDetails.Rows.Remove(r);

                viewDetail();
                ddlItems.SelectedValue =e.CommandArgument.ToString();
            }
            if (e.CommandName == "DeleteOrderDetail")
            {
                DataRow[] rows = dtItemsDetails.Select("ItemID = " + e.CommandArgument.ToString());
                foreach (DataRow r in rows)
                    dtItemsDetails.Rows.Remove(r);

                viewDetail();
            }
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            foreach(DataRow dr in dtItemsDetails.Rows)
            {
                BusinessEntities.OrderDetail objOrderDetail = new BusinessEntities.OrderDetail();
                objOrderDetail.OrderDetailID = 0;
                objOrderDetail.ItemID = Convert.ToInt32(dr["ItemID"]);
                objOrderDetail.OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
                objOrderDetail.AgentID = Convert.ToInt32(Session["AgentID"]);
                objOrderDetail.Quantity= Convert.ToInt32(dr["Quantity"]);
                objOrderDetail.UnitPrice= dr[2].ToString();
                objOrderDetail.DateTimeCreated = DateTime.Now;
                objOrderDetail.IsEnabled = true;
                objOrderDetail.Remarks = txtRemarks.Text;
                LogicKernal.OrderDetail.InsertUpdateOrderDetail(objOrderDetail); 
            }
            Session["dtItemDetails"] = null;
            Response.Redirect("AgentOrders.aspx");
        }
    }
}