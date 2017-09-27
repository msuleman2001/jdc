using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AddPreferecnes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                if(Request.QueryString["PreferanceID"] !=null)
                {
                    DataTable dtPreferances = LogicKernal.Preferances.GetPreferancesByID(Convert.ToInt32(Request.QueryString["PreferanceID"]));
                    txtName.Text= dtPreferances.Rows[0]["PreferanceName"].ToString();
                    txtRemarks.Text= dtPreferances.Rows[0]["Remarks"].ToString();
                    chkIsEnabled.Checked = Convert.ToBoolean(dtPreferances.Rows[0]["IsEnabled"]);
                }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {

            BusinessEntities.Preferances objPreferances = new BusinessEntities.Preferances();
            if (Request.QueryString["PreferanceID"] != null)
            {
                DataTable dtPreferances = LogicKernal.Preferances.GetPreferancesByID(Convert.ToInt32(Request.QueryString["PreferanceID"]));
                objPreferances.PreferanceID = Convert.ToInt32(Request.QueryString["PreferanceID"]);
                objPreferances.DateCreated = Convert.ToDateTime(dtPreferances.Rows[0]["DateCreated"]);
            }
            else
            {
                objPreferances.PreferanceID = 0;
                objPreferances.DateCreated = System.DateTime.Now;
            }  
            objPreferances.PreferanceName = txtName.Text;
            objPreferances.Remarks = txtRemarks.Text;
            objPreferances.IsEnabled = chkIsEnabled.Checked;
            if(LogicKernal.Preferances.InsertUpdatePreferances(objPreferances).Rows.Count>0)
            {
                Response.Redirect("AdminDefault.aspx");
            }
            else
            {
                lblerror.Text = "Can Not Be Added Try Again";
            }
        }
    }
}