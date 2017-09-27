using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry
{
    public partial class AddPreferecnes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            BusinessEntities.Preferances objPreferances = new BusinessEntities.Preferances();
            objPreferances.PreferanceID = 0;
            objPreferances.PreferanceName = txtName.Text;
            objPreferances.Remarks = txtRemarks.Text;
            objPreferances.DateCreated = System.DateTime.Now;
            objPreferances.IsEnabled = chkIsEnabled.Checked;
            if(LogicKernal.Preferances.InsertUpdatePreferances(objPreferances).Rows.Count>0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblerror.Text = "Can Not Be Added Try Again";
            }
        }
    }
}