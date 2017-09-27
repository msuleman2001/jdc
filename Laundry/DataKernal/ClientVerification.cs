using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class ClientVerification
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conClientVerification;
		SqlCommand comClientVerification;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daClientVerification;
		DataSet dsClientVerification;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public ClientVerification(string strConnString)
        {
			strConnectionString = strConnString;
			conClientVerification = new SqlConnection(strConnectionString);
			comClientVerification = new SqlCommand();
			daClientVerification = new SqlDataAdapter();
			dsClientVerification = new DataSet();
		}//end constructor
    
		public ClientVerification()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conClientVerification = new SqlConnection(strConnectionString);
			comClientVerification = new SqlCommand();
			daClientVerification = new SqlDataAdapter();
			dsClientVerification = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conClientVerification.Open();
			comClientVerification.Connection = conClientVerification;
			comClientVerification.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comClientVerification.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comClientVerification.CommandType = CommandType.StoredProcedure;
			daClientVerification.SelectCommand = comClientVerification;
			daClientVerification.Fill(dsClientVerification);
			conClientVerification.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsClientVerification.Tables.Add(dtErrorTable);
		}

		public DataSet SelectClientVerification()
		{
			try
			{
				ConnectAndExecute("ClientVerificationSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsClientVerification;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsClientVerification;
			}//end try
		}//end function

		public DataSet SelectClientVerification(int intVerifiedID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@VerifiedID";
				objParameter.Value = intVerifiedID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetClientVerificationByID", objParameterList);
				return dsClientVerification;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientVerification;
			}
		}
		
		public DataSet InsertUpdateClientVerification(Int64 intVerifiedID, string strPhoneNO, Int64 intVerificationCode, bool blnIsEnabled, DateTime datVerificationDateTime)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@VerifiedID";
objParameter.Value = intVerifiedID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@PhoneNO";
objParameter.Value = strPhoneNO;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@VerificationCode";
objParameter.Value = intVerificationCode;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@IsEnabled";
objParameter.Value = blnIsEnabled;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@VerificationDateTime";
objParameter.Value = datVerificationDateTime;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdateClientVerification", objParameterList);
				return dsClientVerification;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientVerification;
			}
		}

		public DataSet DeleteClientVerification(int intVerifiedID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@VerifiedID";
				objParameter.Value = intVerifiedID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDClientVerification", objParameterList);
				return dsClientVerification;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientVerification;
			}
		}
    
		public DataSet DeleteClientVerification()
		{
			try
			{
				ConnectAndExecute("DeleteAllClientVerification", new ArrayList()); //no parameter will send to stored procedure
				return dsClientVerification;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientVerification;
			}
		}
    
		public DataSet ClientVerificationTruncate()
        {
			try
			{
				ConnectAndExecute("ClientVerificationTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsClientVerification;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientVerification;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
