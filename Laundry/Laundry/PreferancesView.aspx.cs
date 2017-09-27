using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class PreferancesView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            if (!Page.IsPostBack)
            {
                LoadPreferances();
                prefereancevalue();
               
            }
        }
        public void LoadPreferances()
        {
            DataTable dtPreferances = LogicKernal.Preferances.GetAllPreferances();
            gdvPreferances.DataSource = dtPreferances;
            gdvPreferances.DataBind();
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


    }
}