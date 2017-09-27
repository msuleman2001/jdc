using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AddPreferanceValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                databind();
            }
           
        }

        private void databind()
        {
            DataTable dtpreferance = LogicKernal.Preferances.GetAllPreferances();
            drpPreferances.DataSource = dtpreferance;
            drpPreferances.DataBind();
            drpPreferances.DataTextField = "PreferanceName";
            drpPreferances.DataValueField = "PreferanceID";
            drpPreferances.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            BusinessEntities.ValuePreferance objvalue = new BusinessEntities.ValuePreferance();
            objvalue.ValueID = 0;
            objvalue.ValueName = txtValue.Text;
            objvalue.PreferanceID =Convert.ToInt32( drpPreferances.SelectedValue);
            objvalue.Remarks = txtRemarks.Text;
            objvalue.DateCreated = System.DateTime.Now;
            objvalue.IsEnabled = chkIsEnabled.Checked;
            if(LogicKernal.ValuePreferance.InsertUpdateValuePreferance(objvalue).Rows.Count>0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblerror.Text = "Try Again";
            }
        }
    }
}