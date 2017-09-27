using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
    public class PaymentAccount
    {
        //Private Variables////////////////////////////////////////////////////////////////////////
        SqlConnection conPaymentAccount;
        SqlCommand comPaymentAccount;
        string strConnectionString = string.Empty;
        SqlDataAdapter daPaymentAccount;
        DataSet dsPaymentAccount;
        int intRecords;
        ///////////////////////////////////////////////////////////////////////////////////////////


        //Constructor//////////////////////////////////////////////////////////////////////////////
        public PaymentAccount(string strConnString)
        {
            strConnectionString = strConnString;
            conPaymentAccount = new SqlConnection(strConnectionString);
            comPaymentAccount = new SqlCommand();
            daPaymentAccount = new SqlDataAdapter();
            dsPaymentAccount = new DataSet();
        }//end constructor

        public PaymentAccount()
        {
            strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            conPaymentAccount = new SqlConnection(strConnectionString);
            comPaymentAccount = new SqlCommand();
            daPaymentAccount = new SqlDataAdapter();
            dsPaymentAccount = new DataSet();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////

        //Private Methods///////////////////////////////////////////////////////////////////////////
        private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
        {
            conPaymentAccount.Open();
            comPaymentAccount.Connection = conPaymentAccount;
            comPaymentAccount.CommandText = strCommandText;
            //Adding parameters if required
            if (objParameterList.Count > 0)
            {
                for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
                {
                    SqlParameter objParameter = new SqlParameter();
                    objParameter = (SqlParameter)objParameterList[intCounter];
                    comPaymentAccount.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
                }
            }
            comPaymentAccount.CommandType = CommandType.StoredProcedure;
            daPaymentAccount.SelectCommand = comPaymentAccount;
            daPaymentAccount.Fill(dsPaymentAccount);
            conPaymentAccount.Close();
        }

        private void SetError(string strErrorMessage)
        {
            DataColumn colErrorMessage = new DataColumn("ErrorMessage");
            DataTable dtErrorTable = new DataTable();
            dtErrorTable.Columns.Add(colErrorMessage);
            DataRow drErrorRow = dtErrorTable.NewRow();
            drErrorRow[0] = strErrorMessage;
            dtErrorTable.Rows.Add(drErrorRow);
            dsPaymentAccount.Tables.Add(dtErrorTable);
        }

        public DataSet SelectPaymentAccount()
        {
            try
            {
                ConnectAndExecute("PaymentAccountSelectAll", new ArrayList()); //no parameter will send to stored procedure
                return dsPaymentAccount;
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
                return dsPaymentAccount;
            }//end try
        }//end function

        public DataSet SelectPaymentAccount(int intPaymentAccID)
        {
            try
            {
                //parameter setting
                ArrayList objParameterList = new ArrayList();
                SqlParameter objParameter = new SqlParameter();
                objParameter.ParameterName = "@PaymentAccID";
                objParameter.Value = intPaymentAccID;
                objParameterList.Add(objParameter);
                //end parameter setting

                ConnectAndExecute("GetPaymentAccountByID", objParameterList);
                return dsPaymentAccount;
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
                return dsPaymentAccount;
            }
        }

        public DataSet InsertUpdatePaymentAccount(Int64 intPaymentAccID, string strBankName, string strCreditCardNo, DateTime datDateExp, Int64 intClientID, bool blnIsDefault, string strAccountRemarks, DateTime datDateCreated, bool blnIsEnabled, Int64 intCVV, string strNameOnCard)
        {
            try
            {
                //parameter setting
                ArrayList objParameterList = new ArrayList();
                SqlParameter objParameter;
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@PaymentAccID";
                objParameter.Value = intPaymentAccID;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@BankName";
                objParameter.Value = strBankName;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@CreditCardNo";
                objParameter.Value = strCreditCardNo;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@DateExp";
                objParameter.Value = datDateExp;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@ClientID";
                objParameter.Value = intClientID;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@IsDefault";
                objParameter.Value = blnIsDefault;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@AccountRemarks";
                objParameter.Value = strAccountRemarks;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@DateCreated";
                objParameter.Value = datDateCreated;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@IsEnabled";
                objParameter.Value = blnIsEnabled;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@CVV";
                objParameter.Value = intCVV;
                objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@NameOnCard";
                objParameter.Value = strNameOnCard;
                objParameterList.Add(objParameter);

                //end parameter setting

                ConnectAndExecute("InsertUpdatePaymentAccount", objParameterList);
                return dsPaymentAccount;
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
                return dsPaymentAccount;
            }
        }

        public DataSet DeletePaymentAccount(int intPaymentAccID)
        {
            try
            {
                //parameter setting
                ArrayList objParameterList = new ArrayList();
                SqlParameter objParameter = new SqlParameter();
                objParameter.ParameterName = "@PaymentAccID";
                objParameter.Value = intPaymentAccID;
                objParameterList.Add(objParameter);
                //end parameter setting

                ConnectAndExecute("DeleteByIDPaymentAccount", objParameterList);
                return dsPaymentAccount;
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
                return dsPaymentAccount;
            }
        }

        public DataSet DeletePaymentAccount()
        {
            try
            {
                ConnectAndExecute("DeleteAllPaymentAccount", new ArrayList()); //no parameter will send to stored procedure
                return dsPaymentAccount;
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
                return dsPaymentAccount;
            }
        }

        public DataSet PaymentAccountTruncate()
        {
            try
            {
                ConnectAndExecute("PaymentAccountTruncate", new ArrayList()); //no parameter will send to stored procedure
                return dsPaymentAccount;
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
                return dsPaymentAccount;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}
