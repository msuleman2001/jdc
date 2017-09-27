using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laundry
{
    public partial class AgentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string agentEmail = txtLoginEmail.Text;
            string agentPassword = txtloginPassword.Text;
            int agent_id = LogicKernal.LaundryAgent.Login(agentEmail, agentPassword);
            if (agent_id > 0)
            {
                Session["AgentID"] = agent_id;
                Response.Redirect("AgentDefault.aspx");
            }
            else
                lblError.Text = "Enter Correct User Name Password";


        }
    }
}