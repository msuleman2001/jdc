using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sinch;
using Sinch.ServerSdk;

namespace Laundry
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["ClientID"] != null)
                {
                    DataTable dtprofile = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt16(Session["ClientID"]));
                    txtName.Text = dtprofile.Rows[0]["CustomerName"].ToString();
                    txtAddress.Text = dtprofile.Rows[0]["CustomerAddress"].ToString();
                    txtphoneno.Text = dtprofile.Rows[0]["CustomerPhoneNo"].ToString();
                    txtmail.Text = dtprofile.Rows[0]["CustomerEmail"].ToString();


                }
            }

        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            if (lblMessage.Text == "Verified")
            {
                BusinessEntities.CustomerProfile objClient = new BusinessEntities.CustomerProfile();
                if (Session["ClientID"] != null)
                {
                    DataTable dtprofile = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt16(Session["ClientID"]));
                    objClient.ClientID = Convert.ToInt16(Session["ClientID"]);
                    objClient.DateJoind = Convert.ToDateTime(dtprofile.Rows[0]["DateJoind"]);
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
                objClient.CustomerImage = imgselected.ImageUrl;
                objClient.CustomerPassword = txtPassword.Text;
                objClient.DateJoind = System.DateTime.Now;
                objClient.CustomerRemarks = "";
                objClient.IsEnabled = true;
                if (LogicKernal.CustomerProfile.InsertUpdateCustomerProfile(objClient).Rows.Count > 0)
                {
                    Response.Redirect("Login.aspx");
                }

            }
            else
                lblerror.Text = "* Verify Your Phone NO";
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

        protected async void  btnSendCode_Click(object sender, EventArgs e)
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            int Number = _rdm.Next(_min, _max);
            string phoneno = txtphoneno.Text;

            string Codeline = Number.ToString(); // Get string from user


            var smsApi = Sinch.ServerSdk.SinchFactory.CreateApiFactory("866f3c93-2d96-47af-b03a-ffc6c863a894", "UVFqhvqinEmUGSzxfjvllQ==").CreateSmsApi();
            var sendSmsResponse = await smsApi.Sms(phoneno, Codeline).Send();
            int messageID = Convert.ToInt32(sendSmsResponse.MessageId);

            if (messageID > 0)
            {
                lblMessage.Text = "Sent";
                lblMessage.Visible = true;
                txtCode.Visible = true;

                BusinessEntities.ClientVerification objVerification = new BusinessEntities.ClientVerification();
                objVerification.VerifiedID = 0;
                objVerification.PhoneNO = txtphoneno.Text;
                objVerification.VerificationCode =Convert.ToInt32( Codeline);
                objVerification.VerificationDateTime = System.DateTime.Now;
                objVerification.IsEnabled = true;
                LogicKernal.ClientVerification.InsertUpdateClientVerification(objVerification);


            }
            else
            {
                lblMessage.Text = "Try Again Later";
                lblMessage.Visible = true;
                txtCode.Visible = false;
            }
        }

        protected void btnverify_Click(object sender, EventArgs e)
        {
            string phoneno = txtphoneno.Text;
            string Code = txtCode.Text;
            double time_span = 2.3;
            int IsValid = LogicKernal.ClientVerification.GetIsVerificationCodeValid(phoneno,Code,time_span);
            if(IsValid>0)
            {
                DataTable dtVerified = LogicKernal.ClientVerification.GetClientVerificationByID(IsValid);
                BusinessEntities.ClientVerification objVerification = new BusinessEntities.ClientVerification();
                objVerification.VerifiedID = IsValid;
                objVerification.PhoneNO = txtphoneno.Text;
                objVerification.VerificationCode = Convert.ToInt32(dtVerified.Rows[0]["VerificationCode"]);
                objVerification.VerificationDateTime = Convert.ToDateTime(dtVerified.Rows[0]["VerificationDateTime"]);
                objVerification.IsEnabled = false;
                LogicKernal.ClientVerification.InsertUpdateClientVerification(objVerification);
                lblMessage.Text="Verified";
                lblMessage.Visible = true;
                
            }
            else
            {
                lblMessage.Text = "Code Does Not Match...";
                lblMessage.Visible = true;
            }
        }
    }
}