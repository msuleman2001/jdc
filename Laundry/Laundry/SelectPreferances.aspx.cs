using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class SelectPreferances : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToInt16(Request.QueryString["ClientPreferanceID"]) != 0)
                {
                    databindPreferance();
                }
                else
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
            ValueBind();
        }
        private void databindPreferance()
        {
            DataTable dtCLientpreferance = LogicKernal.ClientPreferance.GetClientPreferanceByID(Convert.ToInt16(Request.QueryString["ClientPreferanceID"]));
            int intvalueId = Convert.ToInt32(dtCLientpreferance.Rows[0]["ValueID"]);
            DataTable dtpreferancevalue = LogicKernal.ValuePreferance.GetValuePreferanceByID(intvalueId);
            int PreferanceID = Convert.ToInt32(dtpreferancevalue.Rows[0]["PreferanceID"]);
            DataTable preferances = LogicKernal.Preferances.GetPreferancesByID(PreferanceID);


            drpPreferances.DataSource = preferances;
            drpPreferances.DataBind();
            drpPreferances.DataTextField = "PreferanceName";
            drpPreferances.DataValueField = "PreferanceID";
            drpPreferances.DataBind();
            ValueBind();
        }

        private void ValueBind()
        {
            DataTable dtValue = LogicKernal.ValuePreferance.PrefecanceValueByID(Convert.ToInt16(drpPreferances.SelectedValue));
           drpvalue.DataSource = dtValue;
            drpvalue.DataBind();
            drpvalue.DataTextField = "ValueName";
            drpvalue.DataValueField = "ValueID";
            drpvalue.DataBind();
        }


        protected void drpPreferances_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            BusinessEntities.ClientPreferance objPreferances = new BusinessEntities.ClientPreferance();
            if (Convert.ToInt16(Request.QueryString["ClientPreferanceID"]) != 0)
            {
                objPreferances.ClientPreferanceID = Convert.ToInt16(Request.QueryString["ClientPreferanceID"]);
                DataTable dtPreferances = LogicKernal.ClientPreferance.GetClientPreferanceByID(Convert.ToInt16(Request.QueryString["ClientPreferanceID"]));
                objPreferances.DateCreated = Convert.ToDateTime(dtPreferances.Rows[0]["DateCreated"]);
            }
            else
            {
                objPreferances.ClientPreferanceID = 0;
                objPreferances.DateCreated = System.DateTime.Now;
            }
             
            objPreferances.ValueID =Convert.ToInt16( drpvalue.SelectedValue);
            objPreferances.Remarks = txtRemarks.Text;
            
            objPreferances.ClientID = Convert.ToInt16(Session["ClientID"]);
            objPreferances.IsEnabled = chkIsEnabled.Checked;
            if (LogicKernal.ClientPreferance.InsertUpdateClientPreferance(objPreferances).Rows.Count > 0)
                Response.Redirect("Profile.aspx");
            else
                lblerror.Text = "Try Again";
        }
    }
}