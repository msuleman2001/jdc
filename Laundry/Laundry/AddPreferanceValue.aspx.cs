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
                if (Request.QueryString["ValueID"] != null)
                {
                    DataTable dtValue = LogicKernal.ValuePreferance.GetValuePreferanceByID(Convert.ToInt32(Request.QueryString["ValueID"]));
                    txtValue.Text = dtValue.Rows[0]["ValueName"].ToString();
                    txtRemarks.Text = dtValue.Rows[0]["Remarks"].ToString();
                    drpPreferances.SelectedValue = dtValue.Rows[0]["PreferanceID"].ToString();
                    chkIsEnabled.Checked = Convert.ToBoolean(dtValue.Rows[0]["IsEnabled"]);
                }
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
            if (Request.QueryString["ValueID"] != null)
            {
                DataTable dtValue = LogicKernal.ValuePreferance.GetValuePreferanceByID(Convert.ToInt32(Request.QueryString["ValueID"]));
                objvalue.ValueID = Convert.ToInt32(Request.QueryString["ValueID"]);
                objvalue.DateCreated =Convert.ToDateTime (dtValue.Rows[0]["DateCreated"]);
                
            }
            else
            {
                objvalue.ValueID = 0;
                objvalue.DateCreated = System.DateTime.Now;
            }
            objvalue.ValueName = txtValue.Text;
            objvalue.PreferanceID =Convert.ToInt32( drpPreferances.SelectedValue);
            objvalue.Remarks = txtRemarks.Text;            
            objvalue.IsEnabled = chkIsEnabled.Checked;
            if(LogicKernal.ValuePreferance.InsertUpdateValuePreferance(objvalue).Rows.Count>0)
            {
                Response.Redirect("AdminDefault.aspx");
            }
            else
            {
                lblerror.Text = "Try Again";
            }
        }
    }
}