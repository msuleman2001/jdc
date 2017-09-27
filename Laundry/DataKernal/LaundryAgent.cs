using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class LaundryAgent
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conLaundryAgent;
		SqlCommand comLaundryAgent;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daLaundryAgent;
		DataSet dsLaundryAgent;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public LaundryAgent(string strConnString)
        {
			strConnectionString = strConnString;
			conLaundryAgent = new SqlConnection(strConnectionString);
			comLaundryAgent = new SqlCommand();
			daLaundryAgent = new SqlDataAdapter();
			dsLaundryAgent = new DataSet();
		}//end constructor
    
		public LaundryAgent()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conLaundryAgent = new SqlConnection(strConnectionString);
			comLaundryAgent = new SqlCommand();
			daLaundryAgent = new SqlDataAdapter();
			dsLaundryAgent = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conLaundryAgent.Open();
			comLaundryAgent.Connection = conLaundryAgent;
			comLaundryAgent.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comLaundryAgent.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comLaundryAgent.CommandType = CommandType.StoredProcedure;
			daLaundryAgent.SelectCommand = comLaundryAgent;
			daLaundryAgent.Fill(dsLaundryAgent);
			conLaundryAgent.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsLaundryAgent.Tables.Add(dtErrorTable);
		}

		public DataSet SelectLaundryAgent()
		{
			try
			{
				ConnectAndExecute("LaundryAgentSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsLaundryAgent;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsLaundryAgent;
			}//end try
		}//end function

		public DataSet SelectLaundryAgent(int intAgentID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@AgentID";
				objParameter.Value = intAgentID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetLaundryAgentByID", objParameterList);
				return dsLaundryAgent;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAgent;
			}
		}
		
		public DataSet InsertUpdateLaundryAgent(Int64 intAgentID, string strAgentName, string strAgentEmail, string strAgentPassword, string strAgentPhoneNO, string strAgentImage, string strAgentAddress, Int64 intAdminID, DateTime datDateCreated, bool blnIsEnabled, string strRemarks)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentID";
objParameter.Value = intAgentID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentName";
objParameter.Value = strAgentName;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentEmail";
objParameter.Value = strAgentEmail;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentPassword";
objParameter.Value = strAgentPassword;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentPhoneNO";
objParameter.Value = strAgentPhoneNO;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentImage";
objParameter.Value = strAgentImage;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentAddress";
objParameter.Value = strAgentAddress;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminID";
objParameter.Value = intAdminID;
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
objParameter.ParameterName = "@Remarks";
objParameter.Value = strRemarks;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdateLaundryAgent", objParameterList);
				return dsLaundryAgent;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAgent;
			}
		}

		public DataSet DeleteLaundryAgent(int intAgentID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@AgentID";
				objParameter.Value = intAgentID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDLaundryAgent", objParameterList);
				return dsLaundryAgent;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAgent;
			}
		}
    
		public DataSet DeleteLaundryAgent()
		{
			try
			{
				ConnectAndExecute("DeleteAllLaundryAgent", new ArrayList()); //no parameter will send to stored procedure
				return dsLaundryAgent;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAgent;
			}
		}
    
		public DataSet LaundryAgentTruncate()
        {
			try
			{
				ConnectAndExecute("LaundryAgentTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsLaundryAgent;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAgent;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
