using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AdminDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["AdminID"]==null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            if (!Page.IsPostBack)
            {
                LoadPreferances();
                prefereancevalue();
                Agents();
                LoadDrivers();
                ShowAllDriver();
                Admin();
                AllCategory();
                AllItems();
            }
        }

        public void LoadPreferances()
        {
            DataTable dtPreferances = LogicKernal.Preferances.GetAllPreferances();
            gdvPreferances.DataSource = dtPreferances;
            gdvPreferances.DataBind();
        }
        public void Admin()
        {
            DataTable dtAdmin = LogicKernal.LaundryAdmin.GetLaundryAdminByID(Convert.ToInt32(Session["AdminID"]));
            lblname.Text = dtAdmin.Rows[0]["AdminName"].ToString();
            lblEmail.Text = dtAdmin.Rows[0]["AdminEmail"].ToString();
            lblAdress.Text  = dtAdmin.Rows[0]["Address"].ToString();
            lblPhoneNO.Text = dtAdmin.Rows[0]["PhoneNO"].ToString();
            lblRemarks.Text = dtAdmin.Rows[0]["AdminRemarks"].ToString();
            lblEnabled.Text = dtAdmin.Rows[0]["IsEnabled"].ToString();
            imgAdmin.ImageUrl = dtAdmin.Rows[0]["AdminImage"].ToString();
        }

        protected void gdvPreferances_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPreferance")
            {
                Response.Redirect("AddPreferecnes.aspx?PreferanceID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeletePreferance")
            {
                LogicKernal.Preferances.DeletePreferances(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("AdminDefault.aspx");
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPreferecnes.aspx");
        }
        public void prefereancevalue()
        {
            DataTable dtpreferancesValue = LogicKernal.ValuePreferance.GetAllValuePreferance();
            gdvValues.DataSource = dtpreferancesValue;
            gdvValues.DataBind();
        }
        protected void gdvValues_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label lblPreferanceID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblPreferanceID");
                DataTable dtPreferances = new DataTable();
                dtPreferances = LogicKernal.Preferances.GetPreferancesByID(Convert.ToInt32(lblPreferanceID.Text));
                System.Web.UI.WebControls.Label lblPresefarnceName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblPresefarnceName");
                lblPresefarnceName.Text = dtPreferances.Rows[0]["PreferanceName"].ToString();
            }
        }

        protected void gdvValues_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPreferanceValue")
            {
                Response.Redirect("AddPreferanceValue.aspx?ValueID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeletePreferanceValue")
            {
                LogicKernal.ValuePreferance.DeleteValuePreferance(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("AdminDefault.aspx");
            }

        }

        protected void btnValue_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPreferanceValue.aspx");
        }

        protected void btnAgent_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAgent.aspx");
        }

        public void Agents()
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

        public void ShowAllDriver()
        {
            DataTable DtVehicle = LogicKernal.Vehicles.GetAllVehicles();
            gdvVehicals.DataSource = DtVehicle;
            gdvVehicals.DataBind();
        }

        protected void gdvVehicals_RowDataBound(object sender, GridViewRowEventArgs e)
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

                System.Web.UI.WebControls.Label lblDriverID = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblDriverID");
                DataTable dtDriver = new DataTable();
                dtDriver = LogicKernal.LaundryDrivers.GetLaundryDriversByID(Convert.ToInt32(lblDriverID.Text));
                Label lblDriverName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblDriverName");
                if (dtDriver.Rows.Count > 0)
                    lblDriverName.Text = dtDriver.Rows[0]["DriverName"].ToString();
                else
                    lblDriverName.Text = "N/A";
            }
        }

        protected void btnVehicle_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddVehicle.aspx");
        }

        protected void gdvVehicals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditVehicle")
            {
                Response.Redirect("AddVehicle.aspx?VehicleID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeleteVehicle")
            {
                LogicKernal.Vehicles.DeleteVehicles(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("AdminDefault.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminRegister.aspx");
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItemCategory.aspx");
        }

        public void AllCategory()
        {
            DataTable dtCategory = LogicKernal.ItemCategory.GetAllItemCategory();
            GridItemCategory.DataSource=dtCategory;
            GridItemCategory.DataBind();
        }

        protected void GridItemCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdminID = (Label)e.Row.FindControl("lblAdminID");
                DataTable dtAdmin = new DataTable();
                dtAdmin = LogicKernal.LaundryAdmin.GetLaundryAdminByID(Convert.ToInt32(lblAdminID.Text));
                Label lblAdminName = (Label)e.Row.FindControl("lblAdminName");
                lblAdminName.Text = dtAdmin.Rows[0]["AdminName"].ToString();

                Label lblParentCategoryID = (Label)e.Row.FindControl("lblParentCategoryID");
                DataTable dtCategory = new DataTable();
                dtCategory = LogicKernal.ItemCategory.GetItemCategoryByID(Convert.ToInt32(lblParentCategoryID.Text));
                Label lblCategoryName = (Label)e.Row.FindControl("lblCategoryName");
                if (dtCategory.Rows.Count > 0)
                    lblCategoryName.Text ="Sub Category of = " + dtCategory.Rows[0]["CategoryName"].ToString();
                else
                    lblCategoryName.Text = "Master Category";
            }

        }

        protected void GridItemCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCategory")
            {
                Response.Redirect("AddItemCategory.aspx?CategoryID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeleteCategory")
            {
                LogicKernal.ItemCategory.DeleteItemCategory(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("AdminDefault.aspx");
            }
        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItems.aspx");
        }

        public void AllItems()
        {
            DataTable dtItems = LogicKernal.Items.GetAllItems();
            gdvItems.DataSource = dtItems;
            gdvItems.DataBind();
        }

        protected void gdvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAdminID = (Label)e.Row.FindControl("lblAdminID");
                DataTable dtAdmin = new DataTable();
                dtAdmin = LogicKernal.LaundryAdmin.GetLaundryAdminByID(Convert.ToInt32(lblAdminID.Text));
                Label lblAdminName = (Label)e.Row.FindControl("lblAdminName");
                lblAdminName.Text = dtAdmin.Rows[0]["AdminName"].ToString();

                Label lblCategoryID = (Label)e.Row.FindControl("lblCategoryID");
                DataTable dtCategory = new DataTable();
                dtCategory = LogicKernal.ItemCategory.GetItemCategoryByID(Convert.ToInt32(lblCategoryID.Text));
                Label lblCategoryName = (Label)e.Row.FindControl("lblCategoryName");
                    lblCategoryName.Text = dtCategory.Rows[0]["CategoryName"].ToString();
            }
        }

        protected void gdvItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditItem")
            {
                Response.Redirect("AddItems.aspx?ItemID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeleteItem")
            {
                LogicKernal.Items.DeleteItems(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("AdminDefault.aspx");
            }
        }
    }
}