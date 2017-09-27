using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AdminRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chkAdmin.Visible = false;
            chkAdmin.Checked = true;
            
            if(!Page.IsPostBack)
            {
                if (Session["AdminID"] != null)
                {
                    DataTable dtAdmin = LogicKernal.LaundryAdmin.GetLaundryAdminByID(Convert.ToInt32(Session["AdminID"]));
                    txtname.Text = dtAdmin.Rows[0]["AdminName"].ToString();
                    txtEmail.Text = dtAdmin.Rows[0]["AdminEmail"].ToString();
                    txtAdress.Text = dtAdmin.Rows[0]["Address"].ToString();
                    txtPhoneNO.Text = dtAdmin.Rows[0]["PhoneNO"].ToString();
                    TxtRemarks.Text = dtAdmin.Rows[0]["AdminRemarks"].ToString();
                    chkEnabled.Checked =Convert.ToBoolean( dtAdmin.Rows[0]["IsEnabled"]);
                    imgAdmin.ImageUrl = dtAdmin.Rows[0]["AdminImage"].ToString();
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileImage.HasFile)
            {
                string file_path = Server.MapPath("CustomerImages") + "/" + fileImage.FileName;
                fileImage.SaveAs(file_path);
                imgAdmin.ImageUrl = "CustomerImages//" + fileImage.FileName;

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtadminpassword.Text != "")
            {
                BusinessEntities.LaundryAdmin objAdmin = new BusinessEntities.LaundryAdmin();
                if (Session["AdminID"] != null)
                {
                    DataTable dtAdmin = LogicKernal.LaundryAdmin.GetLaundryAdminByID(Convert.ToInt32(Session["AdminID"]));

                    objAdmin.AdminID = Convert.ToInt32(Session["AdminID"]);
                    objAdmin.AdmindateJoind = Convert.ToDateTime(dtAdmin.Rows[0]["AdmindateJoind"]);
                }
                else
                {
                    objAdmin.AdminID = 0;
                    objAdmin.AdmindateJoind = System.DateTime.Now;
                }

                objAdmin.AdminName = txtname.Text;
                objAdmin.AdminEmail = txtEmail.Text;
                objAdmin.AdminPassword = txtadminpassword.Text;
                objAdmin.PhoneNo = txtPhoneNO.Text;
                objAdmin.Address = txtAdress.Text;
                objAdmin.AdminImage = imgAdmin.ImageUrl;
                objAdmin.AdminType = chkAdmin.Checked;

                objAdmin.IsEnabled = chkEnabled.Checked;
                objAdmin.AdminRemarks = TxtRemarks.Text;
                if (LogicKernal.LaundryAdmin.InsertUpdateLaundryAdmin(objAdmin).Rows.Count > 0)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                else
                    lblerror.Text = "Cannot SignUp";
            }
            else
                lblerror.Text = "Cannot SignUp";
        }
    }
}