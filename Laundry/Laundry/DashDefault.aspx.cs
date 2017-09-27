﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class DashDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
                Response.Redirect("AdminLogin.aspx");
            viewdata();
        }

        public void viewdata()
        {
            DataTable dtclients = LogicKernal.CustomerProfile.GetAllCustomerProfile();
                lblClients.Text = dtclients.Rows.Count.ToString();
            DataTable dtAgents = LogicKernal.LaundryAgent.GetAllLaundryAgent();
            lblAgents.Text = dtAgents.Rows.Count.ToString();
            DataTable dtOrders = LogicKernal.Orders.GetAllOrders();
            lblOrders.Text = dtOrders.Rows.Count.ToString();

        }
    }
}