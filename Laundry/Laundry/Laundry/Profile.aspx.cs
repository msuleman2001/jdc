using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

namespace Laundry
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClientID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            ViewState["PrefrencesString"] = "";
            if (!Page.IsPostBack)
            {
                ClientProfile();
                CardDetail();
                LoadPreferances();
            }
                

        }
        public void ClientProfile()
        {
            DataTable dtClient = LogicKernal.CustomerProfile.GetCustomerProfileByID(Convert.ToInt16(Session["ClientID"]));
            lblname.Text = dtClient.Rows[0]["CustomerName"].ToString();
            lblAddress.Text = dtClient.Rows[0]["CustomerAddress"].ToString();
            lblEmail.Text = dtClient.Rows[0]["CustomerEmail"].ToString();
            lbljoind.Text = dtClient.Rows[0]["DateJoind"].ToString();
            lblphone.Text = dtClient.Rows[0]["CustomerPhoneNo"].ToString();
            lblPassword.Text = dtClient.Rows[0]["CustomerPassword"].ToString();
            
        }
        public void CardDetail()
        {
            DataTable dtCard = LogicKernal.PaymentAccount.CreditCradByClientID(Convert.ToInt32( Session["ClientID"]));
            GdvCards.DataSource = dtCard;
            GdvCards.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAccount.aspx");
        }

        protected void GdvCards_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCard")
            {
                Response.Redirect("AddAccount.aspx?PaymentAccID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeleteCard")
            {
                LogicKernal.PaymentAccount.DeletePaymentAccount(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("Profile.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        public void LoadPreferances()
        {
            DataTable dtPreferance = LogicKernal.ClientPreferance.ClientPreferancesByClientID(Convert.ToInt32(Session["ClientID"]));
            DataTable dtPreferances = LogicKernal.Preferances.GetAllPreferances();
            lstPreferences.DataSource = dtPreferances;
            lstPreferences.DataBind();

            

            //gdvPreferances.DataSource = dtPreferance;
            //gdvPreferances.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //remove all values from client pref by client id
            //get new values from session
            LogicKernal.ClientPreferance.DeleteClientPreferancesByClientID(Convert.ToInt16(Session["ClientID"]));
            string prefrences_values = (string)(HttpContext.Current.Session["Preferances"]);
            string[] value_ids = prefrences_values.Split(',');
            for (int i = 1; i < value_ids.Length; i++)
            {
                int ValueID = Convert.ToInt32(value_ids[i]);
                BusinessEntities.ClientPreferance objClientPrefrences = new BusinessEntities.ClientPreferance();
                objClientPrefrences.ClientPreferanceID = 0;
                objClientPrefrences.ValueID = ValueID;
                objClientPrefrences.ClientID = Convert.ToInt32(Session["ClientID"]);
                objClientPrefrences.DateCreated = System.DateTime.Now;
                objClientPrefrences.IsEnabled = true;
                objClientPrefrences.Remarks = "";
                if(LogicKernal.ClientPreferance.InsertUpdateClientPreferance(objClientPrefrences).Rows.Count>0)
                    lblError.Text = "Added";
                else
                    lblError.Text = "NOt Added";

                
            }
            HttpContext.Current.Session["Preferances"] = null;
            Response.Redirect("Profile.aspx");
        }

        protected void gdvPreferances_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPreferance")
            {
                Response.Redirect("SelectPreferances.aspx?ClientPreferanceID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "DeletePreferance")
            {
                LogicKernal.ClientPreferance.DeleteClientPreferance(Convert.ToInt32(e.CommandArgument));
                Response.Redirect("Profile.aspx");
            }
        }

        protected void gdvPreferances_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(Session["ClientID"]) != 0)
                {
                    System.Web.UI.WebControls.Label lblValueId = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblValueID");
                    DataTable dtstudents = new DataTable();
                    dtstudents = LogicKernal.ValuePreferance.GetValuePreferanceByID(Convert.ToInt32(lblValueId.Text));
                    System.Web.UI.WebControls.Label lblPresefarnceValue = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblPresefarnceValue");
                    lblPresefarnceValue.Text = dtstudents.Rows[0]["ValueName"].ToString();
                    int PreferanceID =Convert.ToInt32( dtstudents.Rows[0]["PreferanceID"]);
                    DataTable dtPreferance = LogicKernal.Preferances.GetPreferancesByID(PreferanceID);
                    System.Web.UI.WebControls.Label lblPresefarnceName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblPresefarnceName");
                    lblPresefarnceName.Text = dtPreferance.Rows[0]["PreferanceName"].ToString();


                }
            }
        }

        protected void lstPreferences_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DataList lstPrefrenceValue = (DataList)e.Item.FindControl("lstPreferenceValues");
            System.Web.UI.WebControls.Label lblPreferenceID =  (System.Web.UI.WebControls.Label)e.Item.FindControl("lblPreferenceID");

            lstPrefrenceValue.ItemDataBound += new DataListItemEventHandler(this.lstPrefrenceValue_ItemDataBound);
            DataTable dtPrefrenceValues = LogicKernal.ValuePreferance.PrefecanceValueByPrefrenceID(Convert.ToInt16(lblPreferenceID.Text));
            lstPrefrenceValue.DataSource = dtPrefrenceValues;
            lstPrefrenceValue.DataBind();
        }

        protected void lstPrefrenceValue_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lblInside = (Label)e.Item.FindControl("lblInside");
            HiddenField hidValueID = (HiddenField)e.Item.FindControl("hidValueID");
            string client_prefrences="";
            if (HttpContext.Current.Session["Preferances"] != null)
                client_prefrences = HttpContext.Current.Session["Preferances"].ToString();
            if (lblInside != null)
            {
                int client_id = Convert.ToInt32(Session["ClientID"]);
                int prefrence_value_id = Convert.ToInt32(hidValueID.Value);
                bool is_prefrence_exists = LogicKernal.ClientPreferance.GetAllClientPreferanceByValueID(client_id, prefrence_value_id);
                if (is_prefrence_exists)
                {
                    client_prefrences += "," + prefrence_value_id;
                    lblInside.BackColor = System.Drawing.Color.Green;
                }
                HttpContext.Current.Session["Preferances"] = client_prefrences;
            }
        }

        protected void lstPreferenceValues_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "call")
            {
                DataListItem item = (DataListItem)(((Button)(e.CommandSource)).NamingContainer);
                string Referanceid = ((Label)item.FindControl("lblPreferenceID")).Text;
                string text = ((Label)item.FindControl("lblValueID")).Text;

                BusinessEntities.ClientPreferance objPreferances = new BusinessEntities.ClientPreferance();
        
              
                    objPreferances.ClientPreferanceID = 0;
                    objPreferances.DateCreated = System.DateTime.Now;
               
                objPreferances.ValueID = Convert.ToInt16(text);
                objPreferances.Remarks = "";

                objPreferances.ClientID = Convert.ToInt16(Session["ClientID"]);
                objPreferances.IsEnabled = true;
                if (LogicKernal.ClientPreferance.InsertUpdateClientPreferance(objPreferances).Rows.Count > 0)
                {
                    
                    lblError.Text = "Updated";
                }
                else
                    lblError.Text = "Try Again";
            }

        }

        [WebMethod]
        public static string GetInputPreferences(string prefrence_value_id, string status)
        {
             string prefrences_values = "";
             if (HttpContext.Current.Session["Preferances"] != null)
                 prefrences_values = (string)(HttpContext.Current.Session["Preferances"]);

            if (status == "0")
                prefrences_values = prefrences_values.Replace("," + prefrence_value_id, "");
            else
            {
                string[] prefrence_ids = prefrences_values.Split(',');
                for (int i = 0; i < prefrence_ids.Length; i++)
                {
                    if (prefrence_ids[i] == prefrence_value_id)
                        return "1";
                }
                prefrences_values += "," + prefrence_value_id.ToString();
            }

             HttpContext.Current.Session["Preferances"] = prefrences_values;
             return "1";
             
            //JavaScriptSerializer json = new JavaScriptSerializer();

            //String Preferances;
            //if (HttpContext.Current.Session["Preferances"] != null)
            //{
            //    Preferances = (string)(HttpContext.Current.Session["Preferances"]);
            //    Preferances += "," + prefrence_value_id;
            //}
            //else
            //    Preferances = prefrence_value_id;

            //if (HttpContext.Current.Session["Preferances"] != null)
            //{
            //    // Getting the value out of Session
            //    var superSecretValue = HttpContext.Current.Session["Preferances"].ToString();

            //}

            // Storing the value in Session
            //HttpContext.Current.Session["Preferances"] = prefrences_values;

            //return "1";
        }
    }
}