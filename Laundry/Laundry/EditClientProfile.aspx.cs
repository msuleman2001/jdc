using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class EditClientProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ClientID"] != null)
                {
                    DataTable dtprofile = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt16(Request.QueryString["ClientID"]));
                    txtName.Text = dtprofile.Rows[0]["CustomerName"].ToString();
                    txtAddress.Text = dtprofile.Rows[0]["CustomerAddress"].ToString();
                    txtphoneno.Text = dtprofile.Rows[0]["CustomerPhoneNo"].ToString();
                    txtmail.Text = dtprofile.Rows[0]["CustomerEmail"].ToString();
                    imgselected.ImageUrl= dtprofile.Rows[0]["CustomerImage"].ToString();
                    chkenable.Checked = Convert.ToBoolean(dtprofile.Rows[0]["IsEnabled"]);
                    txtPassword.Text= dtprofile.Rows[0]["CustomerPassword"].ToString();


                }
            }
        }
        protected void btnsignup_Click(object sender, EventArgs e)
        {
            
                BusinessEntities.CustomerProfile objClient = new BusinessEntities.CustomerProfile();
                
                    DataTable dtprofile = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt16(Request.QueryString["ClientID"]));
                    objClient.ClientID = Convert.ToInt16(Request.QueryString["ClientID"]);
                    objClient.DateJoind = Convert.ToDateTime(dtprofile.Rows[0]["DateJoind"]);
                    objClient.CustomerRemarks = dtprofile.Rows[0]["CustomerRemarks"].ToString();
                objClient.CustomerName = txtName.Text;
                objClient.CustomerAddress = txtAddress.Text;
                objClient.CustomerPhoneNo = txtphoneno.Text;
                objClient.CustomerEmail = txtmail.Text;
                objClient.CustomerImage = imgselected.ImageUrl;
                objClient.CustomerPassword = txtPassword.Text;
                objClient.IsEnabled = true;
                if (LogicKernal.CustomerProfile.InsertUpdateCustomerProfile(objClient).Rows.Count > 0)
                {
                    Response.Redirect("Clients.aspx");
                }

           
        }

        protected void imgUpload_Click(object sender, EventArgs e)
        {
            if (flImage.HasFile)
            {
                string file_path = Server.MapPath("CustomerImages") + "/" + flImage.FileName;
                flImage.SaveAs(file_path);
                imgselected.ImageUrl = "CustomerImages//" + flImage.FileName;
            }
        }

      
    }
}