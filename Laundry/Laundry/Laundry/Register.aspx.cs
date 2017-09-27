using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Session["ClientID"]!=null)
                {
                   DataTable dtprofile= LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt16(Session["ClientID"]));
                    txtName.Text = dtprofile.Rows[0]["CustomerName"].ToString();
                    txtAddress.Text = dtprofile.Rows[0]["CustomerAddress"].ToString();
                    txtphoneno.Text = dtprofile.Rows[0]["CustomerPhoneNo"].ToString();
                    txtmail.Text = dtprofile.Rows[0]["CustomerEmail"].ToString();
                    chkIsEnabled.Checked =Convert.ToBoolean( dtprofile.Rows[0]["IsEnabled"]);

                }
            }

        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            BusinessEntities.CustomerProfile objClient = new BusinessEntities.CustomerProfile();
            if (Session["ClientID"] != null)
            {
                DataTable dtprofile = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt16(Session["ClientID"]));
                objClient.ClientID = Convert.ToInt16(Session["ClientID"]);
                objClient.DateJoind =Convert.ToDateTime( dtprofile.Rows[0]["DateJoind"] );
                objClient.CustomerRemarks = dtprofile.Rows[0]["CustomerRemarks"].ToString();
            }
            else
            {
                objClient.ClientID = 0;
                objClient.DateJoind = System.DateTime.Now;
                objClient.CustomerRemarks = "";
            }
                
            objClient.CustomerName = txtName.Text;
            objClient.CustomerAddress = txtAddress.Text;
            objClient.CustomerPhoneNo = txtphoneno.Text;
            objClient.CustomerEmail = txtmail.Text;
            objClient.CustomerPassword = txtPassword.Text;
            objClient.DateJoind = System.DateTime.Now;
            objClient.CustomerRemarks = "";
            objClient.IsEnabled = chkIsEnabled.Checked;
            if (LogicKernal.CustomerProfile.InsertUpdateCustomerProfile(objClient).Rows.Count > 0)
            {
                Response.Redirect("Login.aspx");
            }
        }

    }
}