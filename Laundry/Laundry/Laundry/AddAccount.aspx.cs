using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Laundry
{
    public partial class AddAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                if (Convert.ToInt16(Request.QueryString["PaymentAccID"]) != 0)
                {
                    DataTable dtAccount = LogicKernal.PaymentAccount.GetPaymentAccountByID(Convert.ToInt16(Request.QueryString["PaymentAccID"]));
                    txtBankName.Text = dtAccount.Rows[0]["BankName"].ToString();
                    txtCardNO.Text = dtAccount.Rows[0]["CreditCardNo"].ToString();
                    txtexpdate.Text = dtAccount.Rows[0]["DateExp"].ToString();
                    chkDefault.Checked=Convert.ToBoolean (dtAccount.Rows[0]["IsDefault"]);
                    TxtRemarks.Text = dtAccount.Rows[0]["AccountRemarks"].ToString();
                    chkEnabled.Checked = Convert.ToBoolean(dtAccount.Rows[0]["IsEnabled"]);
                    txtCVV.Text = dtAccount.Rows[0]["CVV"].ToString();
                    txtNameoncard.Text = dtAccount.Rows[0]["NameOnCard"].ToString();
                }   
    }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BusinessEntities.PaymentAccount objPayment = new BusinessEntities.PaymentAccount();
            if (Convert.ToInt16(Request.QueryString["PaymentAccID"]) != 0)
            {
                DataTable dtAccount = LogicKernal.PaymentAccount.GetPaymentAccountByID(Convert.ToInt16(Request.QueryString["PaymentAccID"]));
                objPayment.PaymentAccID = Convert.ToInt16(Request.QueryString["PaymentAccID"]);
                objPayment.DateCreated =Convert.ToDateTime( dtAccount.Rows[0]["DateExp"]) ;
            }
            else
            {
                objPayment.PaymentAccID = 0;
                objPayment.DateCreated = System.DateTime.Now;
            }
                
            objPayment.BankName = txtBankName.Text;
            objPayment.CreditCardNo = txtCardNO.Text;
            objPayment.DateExp = Convert.ToDateTime(txtexpdate.Text);
            objPayment.ClientID = Convert.ToInt32(Session["ClientID"]);
            objPayment.IsDefault = chkDefault.Checked;
            objPayment.AccountRemarks = TxtRemarks.Text;
            
            objPayment.IsEnabled = chkEnabled.Checked;
            objPayment.CVV =Convert.ToInt32( txtCVV.Text);
            objPayment.NameOnCard = txtNameoncard.Text;
            if(LogicKernal.PaymentAccount.InsertUpdatePaymentAccount(objPayment).Rows.Count>0)
            {
                Response.Redirect("Profile.aspx");
            }
            else
            {
                lblerror.Text = "Please Enter Correct Data";
            }


        }
    }
}