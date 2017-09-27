using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AddAgent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                if(Request.QueryString["AgentID"]!=null)
                {
                    DataTable dtAgent = LogicKernal.LaundryAgent.GetLaundryAgentByID(Convert.ToInt32(Request.QueryString["AgentID"]));
                    txtName.Text = dtAgent.Rows[0]["AgentName"].ToString();
                    txtAgentEmail.Text = dtAgent.Rows[0]["AgentEmail"].ToString();
                    txtAgentPassword.Text= dtAgent.Rows[0]["AgentPassword"].ToString();
                    txtAgentPhoneNO.Text = dtAgent.Rows[0]["AgentPhoneNO"].ToString();
                    imgAgent.ImageUrl= dtAgent.Rows[0]["AgentImage"].ToString();
                    txtAdress.Text= dtAgent.Rows[0]["AgentAddress"].ToString();
                    chkEnabled.Checked = Convert.ToBoolean(dtAgent.Rows[0]["IsEnabled"]);
                    TxtRemarks.Text= dtAgent.Rows[0]["Remarks"].ToString();
                }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileAgentImage.HasFile)
            {
                string file_path = Server.MapPath("CustomerImages") + "/" + fileAgentImage.FileName;
                fileAgentImage.SaveAs(file_path);
                imgAgent.ImageUrl = "CustomerImages//" + fileAgentImage.FileName;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            BusinessEntities.LaundryAgent objAgent = new BusinessEntities.LaundryAgent();
            if (Request.QueryString["AgentID"] != null)
            {
                DataTable dtAgent = LogicKernal.LaundryAgent.GetLaundryAgentByID(Convert.ToInt32(Request.QueryString["AgentID"]));
                objAgent.AgentID = Convert.ToInt32(Request.QueryString["AgentID"]);
                objAgent.DateCreated = Convert.ToDateTime(dtAgent.Rows[0]["DateCreated"].ToString());
            }
            else
            {
                objAgent.AgentID = 0;
                objAgent.DateCreated = System.DateTime.Now;
            }
                
            objAgent.AgentName = txtName.Text;
            objAgent.AgentEmail = txtAgentEmail.Text;
            objAgent.AgentPassword = txtAgentPassword.Text;
            objAgent.AgentPhoneNO = txtAgentPhoneNO.Text;
            objAgent.AgentAddress = txtAdress.Text;
            objAgent.AgentImage = imgAgent.ImageUrl;
            
            objAgent.IsEnabled = chkEnabled.Checked;
            objAgent.Remarks = TxtRemarks.Text;
            objAgent.AdminID = Convert.ToInt32(Session["AdminID"]);
            if (LogicKernal.LaundryAgent.InsertUpdateLaundryAgent(objAgent).Rows.Count > 0)
            {
                Response.Redirect("Agents.aspx");
            }
            else
            {
                lblerror.Text = "Try Again";
            }
        }
    }
}