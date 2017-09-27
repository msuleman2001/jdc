using System.Data;

namespace LogicKernal
{
    public class PaymentAccount
    {
        public static DataTable GetAllPaymentAccount()
        {
            try
            {
                DataKernal.PaymentAccount objPaymentAccount = new DataKernal.PaymentAccount();
                return objPaymentAccount.SelectPaymentAccount().Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static DataTable CreditCradByClientID(int ClientID)
        {
            DataTable DtCards = GetAllPaymentAccount();

            DataRow[] rows = DtCards.Select("ClientID = " + ClientID.ToString());
            DataTable dtorder = DtCards.Clone();
            foreach (DataRow row in rows)
            {
                dtorder.Rows.Add(row.ItemArray);
            }
            return dtorder;


        }

        public static DataTable GetPaymentAccountByID(int intPaymentAccID)
        {
            try
            {
                DataKernal.PaymentAccount objPaymentAccount = new DataKernal.PaymentAccount();
                return objPaymentAccount.SelectPaymentAccount(intPaymentAccID).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static DataTable InsertUpdatePaymentAccount(BusinessEntities.PaymentAccount objPaymentAccount)
        {
            try
            {
                DataKernal.PaymentAccount objDPaymentAccount = new DataKernal.PaymentAccount();
                return objDPaymentAccount.InsertUpdatePaymentAccount(objPaymentAccount.PaymentAccID, objPaymentAccount.BankName, objPaymentAccount.CreditCardNo, objPaymentAccount.DateExp, objPaymentAccount.ClientID, objPaymentAccount.IsDefault, objPaymentAccount.AccountRemarks, objPaymentAccount.DateCreated, objPaymentAccount.IsEnabled, objPaymentAccount.CVV, objPaymentAccount.NameOnCard).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static DataTable DeletePaymentAccount(int intPaymentAccID)
        {
            try
            {
                DataKernal.PaymentAccount objPaymentAccount = new DataKernal.PaymentAccount();
                return objPaymentAccount.DeletePaymentAccount(intPaymentAccID).Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static DataTable DeletePaymentAccount()
        {
            try
            {
                DataKernal.PaymentAccount objPaymentAccount = new DataKernal.PaymentAccount();
                return objPaymentAccount.DeletePaymentAccount().Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static DataTable TruncatePaymentAccount()
        {
            try
            {
                DataKernal.PaymentAccount objPaymentAccount = new DataKernal.PaymentAccount();
                return objPaymentAccount.PaymentAccountTruncate().Tables[0];
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}
