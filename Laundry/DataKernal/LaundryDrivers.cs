using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class LaundryDrivers
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conLaundryDrivers;
		SqlCommand comLaundryDrivers;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daLaundryDrivers;
		DataSet dsLaundryDrivers;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public LaundryDrivers(string strConnString)
        {
			strConnectionString = strConnString;
			conLaundryDrivers = new SqlConnection(strConnectionString);
			comLaundryDrivers = new SqlCommand();
			daLaundryDrivers = new SqlDataAdapter();
			dsLaundryDrivers = new DataSet();
		}//end constructor
    
		public LaundryDrivers()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conLaundryDrivers = new SqlConnection(strConnectionString);
			comLaundryDrivers = new SqlCommand();
			daLaundryDrivers = new SqlDataAdapter();
			dsLaundryDrivers = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conLaundryDrivers.Open();
			comLaundryDrivers.Connection = conLaundryDrivers;
			comLaundryDrivers.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comLaundryDrivers.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comLaundryDrivers.CommandType = CommandType.StoredProcedure;
			daLaundryDrivers.SelectCommand = comLaundryDrivers;
			daLaundryDrivers.Fill(dsLaundryDrivers);
			conLaundryDrivers.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsLaundryDrivers.Tables.Add(dtErrorTable);
		}

		public DataSet SelectLaundryDrivers()
		{
			try
			{
				ConnectAndExecute("LaundryDriversSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsLaundryDrivers;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsLaundryDrivers;
			}//end try
		}//end function

		public DataSet SelectLaundryDrivers(int intDriverID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@DriverID";
				objParameter.Value = intDriverID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetLaundryDriversByID", objParameterList);
				return dsLaundryDrivers;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryDrivers;
			}
		}
		
		public DataSet InsertUpdateLaundryDrivers(Int64 intDriverID, string  strDriverName, string strDriverEmail, string strDriverPassword, string strDriverPhoneNO, string strDriverImage, string strDriverlicenceNO, DateTime datLicenceIssueDate, DateTime datLicenceExpDate, string strDriverAddress, Int64 intAgentID, Int64 intAdminID, DateTime datDateCreated, string strRemarks, bool blnIsEnable)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@DriverID";
objParameter.Value = intDriverID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DriverName";
objParameter.Value = strDriverName;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DriverEmail";
objParameter.Value = strDriverEmail;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DriverPassword";
objParameter.Value = strDriverPassword;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DriverPhoneNO";
objParameter.Value = strDriverPhoneNO;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DriverImage";
objParameter.Value = strDriverImage;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DriverlicenceNO";
objParameter.Value = strDriverlicenceNO;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@LicenceIssueDate";
objParameter.Value = datLicenceIssueDate;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@LicenceExpDate";
objParameter.Value = datLicenceExpDate;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DriverAddress";
objParameter.Value = strDriverAddress;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentID";
objParameter.Value = intAgentID;
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
objParameter.ParameterName = "@Remarks";
objParameter.Value = strRemarks;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@IsEnable";
objParameter.Value = blnIsEnable;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdateLaundryDrivers", objParameterList);
				return dsLaundryDrivers;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryDrivers;
			}
		}

		public DataSet DeleteLaundryDrivers(int intDriverID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@DriverID";
				objParameter.Value = intDriverID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDLaundryDrivers", objParameterList);
				return dsLaundryDrivers;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryDrivers;
			}
		}
    
		public DataSet DeleteLaundryDrivers()
		{
			try
			{
				ConnectAndExecute("DeleteAllLaundryDrivers", new ArrayList()); //no parameter will send to stored procedure
				return dsLaundryDrivers;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryDrivers;
			}
		}
    
		public DataSet LaundryDriversTruncate()
        {
			try
			{
				ConnectAndExecute("LaundryDriversTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsLaundryDrivers;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryDrivers;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
