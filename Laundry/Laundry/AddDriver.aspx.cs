using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AddDriver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Agents();

                if (Convert.ToInt16(Request.QueryString["DriverID"]) != 0)
                {
                    DataTable dtDriver = LogicKernal.LaundryDrivers.GetLaundryDriversByID(Convert.ToInt16(Request.QueryString["DriverID"]));
                    txtName.Text = dtDriver.Rows[0]["DriverName"].ToString();
                    txtEmail.Text = dtDriver.Rows[0]["DriverEmail"].ToString();
                    txtPassword.Text = dtDriver.Rows[0]["DriverPassword"].ToString();
                    txtPhoneNO.Text = dtDriver.Rows[0]["DriverPhoneNO"].ToString();
                    imgAgent.ImageUrl = dtDriver.Rows[0]["DriverImage"].ToString();
                    txtLicenceNo.Text = dtDriver.Rows[0]["DriverlicenceNO"].ToString();
                    txtDateissue.Text = dtDriver.Rows[0]["LicenceIssueDate"].ToString();
                    txtexpdate.Text = dtDriver.Rows[0]["LicenceExpDate"].ToString();
                    txtAdress.Text = dtDriver.Rows[0]["DriverAddress"].ToString();
                    TxtRemarks.Text = dtDriver.Rows[0]["Remarks"].ToString();
                    chkEnabled.Checked = Convert.ToBoolean(dtDriver.Rows[0]["IsEnable"].ToString());
                    ddlAgent.SelectedValue = dtDriver.Rows[0]["AgentID"].ToString();
                }
            }
        }

        public void Agents()
        {
            DataTable dtAgent = LogicKernal.LaundryAgent.GetAllLaundryAgent();
            ddlAgent.DataSource = dtAgent;
            ddlAgent.DataBind();
            ddlAgent.DataTextField = "AgentName";
            ddlAgent.DataValueField = "AgentID";
            ddlAgent.DataBind();
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileImage.HasFile)
            {
                string file_path = Server.MapPath("CustomerImages") + "/" + fileImage.FileName;
                fileImage.SaveAs(file_path);
                imgAgent.ImageUrl = "CustomerImages//" + fileImage.FileName;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BusinessEntities.LaundryDrivers objDriver = new BusinessEntities.LaundryDrivers();
            if (Convert.ToInt16(Request.QueryString["DriverID"]) != 0)
            {
                objDriver.DriverID = Convert.ToInt16(Request.QueryString["DriverID"]);
                DataTable dtDriver = LogicKernal.LaundryDrivers.GetLaundryDriversByID(Convert.ToInt16(Request.QueryString["DriverID"]));
                objDriver.DateCreated = Convert.ToDateTime(dtDriver.Rows[0]["DateCreated"]);
            }
            else
            {
                objDriver.DriverID = 0;
                objDriver.DateCreated = System.DateTime.Now;
            }
            objDriver.DriverName = txtName.Text;
            objDriver.DriverEmail = txtEmail.Text;
            objDriver.DriverPassword = txtPassword.Text;
            objDriver.DriverPhoneNO = txtPhoneNO.Text;
            objDriver.DriverImage = imgAgent.ImageUrl;
            objDriver.DriverlicenceNO = txtLicenceNo.Text;
            objDriver.LicenceIssueDate = Convert.ToDateTime(txtDateissue.Text);
            objDriver.LicenceExpDate = Convert.ToDateTime(txtexpdate.Text);
            objDriver.DriverAddress = txtAdress.Text;
            objDriver.AgentID =Convert.ToInt32( ddlAgent.SelectedValue);
            objDriver.AdminID = Convert.ToInt32(Session["AdminID"]);
            objDriver.IsEnable = chkEnabled.Checked;
            objDriver.Remarks = TxtRemarks.Text;
            if(LogicKernal.LaundryDrivers.InsertUpdateLaundryDrivers(objDriver).Rows.Count>0)
                Response.Redirect("Drivers.aspx");
            else
                lblerror.Text = "Try Again";

        }
    }
}