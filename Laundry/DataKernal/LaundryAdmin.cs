using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class LaundryAdmin
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conLaundryAdmin;
		SqlCommand comLaundryAdmin;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daLaundryAdmin;
		DataSet dsLaundryAdmin;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public LaundryAdmin(string strConnString)
        {
			strConnectionString = strConnString;
			conLaundryAdmin = new SqlConnection(strConnectionString);
			comLaundryAdmin = new SqlCommand();
			daLaundryAdmin = new SqlDataAdapter();
			dsLaundryAdmin = new DataSet();
		}//end constructor
    
		public LaundryAdmin()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conLaundryAdmin = new SqlConnection(strConnectionString);
			comLaundryAdmin = new SqlCommand();
			daLaundryAdmin = new SqlDataAdapter();
			dsLaundryAdmin = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conLaundryAdmin.Open();
			comLaundryAdmin.Connection = conLaundryAdmin;
			comLaundryAdmin.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comLaundryAdmin.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comLaundryAdmin.CommandType = CommandType.StoredProcedure;
			daLaundryAdmin.SelectCommand = comLaundryAdmin;
			daLaundryAdmin.Fill(dsLaundryAdmin);
			conLaundryAdmin.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsLaundryAdmin.Tables.Add(dtErrorTable);
		}

		public DataSet SelectLaundryAdmin()
		{
			try
			{
				ConnectAndExecute("LaundryAdminSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsLaundryAdmin;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsLaundryAdmin;
			}//end try
		}//end function

		public DataSet SelectLaundryAdmin(int intAdminID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@AdminID";
				objParameter.Value = intAdminID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetLaundryAdminByID", objParameterList);
				return dsLaundryAdmin;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAdmin;
			}
		}
		
		public DataSet InsertUpdateLaundryAdmin(Int64 intAdminID, string strAdminName, string strAdminEmail, string strAdminPassword, string strPhoneNo, string strAddress, string strAdminImage, bool blnAdminType, DateTime datAdmindateJoind, bool blnIsEnabled, string strAdminRemarks)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminID";
objParameter.Value = intAdminID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminName";
objParameter.Value = strAdminName;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminEmail";
objParameter.Value = strAdminEmail;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminPassword";
objParameter.Value = strAdminPassword;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@PhoneNo";
objParameter.Value = strPhoneNo;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@Address";
objParameter.Value = strAddress;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminImage";
objParameter.Value = strAdminImage;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminType";
objParameter.Value = blnAdminType;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdmindateJoind";
objParameter.Value = datAdmindateJoind;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@IsEnabled";
objParameter.Value = blnIsEnabled;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminRemarks";
objParameter.Value = strAdminRemarks;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdateLaundryAdmin", objParameterList);
				return dsLaundryAdmin;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAdmin;
			}
		}

		public DataSet DeleteLaundryAdmin(int intAdminID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@AdminID";
				objParameter.Value = intAdminID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDLaundryAdmin", objParameterList);
				return dsLaundryAdmin;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAdmin;
			}
		}
    
		public DataSet DeleteLaundryAdmin()
		{
			try
			{
				ConnectAndExecute("DeleteAllLaundryAdmin", new ArrayList()); //no parameter will send to stored procedure
				return dsLaundryAdmin;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAdmin;
			}
		}
    
		public DataSet LaundryAdminTruncate()
        {
			try
			{
				ConnectAndExecute("LaundryAdminTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsLaundryAdmin;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsLaundryAdmin;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
