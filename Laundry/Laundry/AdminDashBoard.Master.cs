using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AdminDashBoard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // notifications();
        }


        public void notifications()
        {
            DataTable dtplaced = LogicKernal.Orders.PlacedOrders();
            int placed = dtplaced.Rows.Count;
            DataTable dtcancled = LogicKernal.Orders.CancledOrders();
            int cancled = dtcancled.Rows.Count;
            int total = placed + cancled;
            lblnotification.Text = "0";

        }
    }
}