using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class CustomerAddress
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conCustomerAddress;
		SqlCommand comCustomerAddress;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daCustomerAddress;
		DataSet dsCustomerAddress;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public CustomerAddress(string strConnString)
        {
			strConnectionString = strConnString;
			conCustomerAddress = new SqlConnection(strConnectionString);
			comCustomerAddress = new SqlCommand();
			daCustomerAddress = new SqlDataAdapter();
			dsCustomerAddress = new DataSet();
		}//end constructor
    
		public CustomerAddress()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conCustomerAddress = new SqlConnection(strConnectionString);
			comCustomerAddress = new SqlCommand();
			daCustomerAddress = new SqlDataAdapter();
			dsCustomerAddress = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conCustomerAddress.Open();
			comCustomerAddress.Connection = conCustomerAddress;
			comCustomerAddress.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comCustomerAddress.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comCustomerAddress.CommandType = CommandType.StoredProcedure;
			daCustomerAddress.SelectCommand = comCustomerAddress;
			daCustomerAddress.Fill(dsCustomerAddress);
			conCustomerAddress.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsCustomerAddress.Tables.Add(dtErrorTable);
		}

		public DataSet SelectCustomerAddress()
		{
			try
			{
				ConnectAndExecute("CustomerAddressSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsCustomerAddress;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsCustomerAddress;
			}//end try
		}//end function

		public DataSet SelectCustomerAddress(int intAddressID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@AddressID";
				objParameter.Value = intAddressID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetCustomerAddressByID", objParameterList);
				return dsCustomerAddress;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerAddress;
			}
		}
		
		public DataSet InsertUpdateCustomerAddress(Int64 intAddressID, string strCompleteAddress, string strLatLong, Int64 intClientID, bool blnIsDefault, string strRemarks, DateTime datDateJoind, string strIsEnabled)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@AddressID";
objParameter.Value = intAddressID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CompleteAddress";
objParameter.Value = strCompleteAddress;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@LatLong";
objParameter.Value = strLatLong;
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
objParameter.ParameterName = "@Remarks";
objParameter.Value = strRemarks;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DateJoind";
objParameter.Value = datDateJoind;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@IsEnabled";
objParameter.Value = strIsEnabled;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdateCustomerAddress", objParameterList);
				return dsCustomerAddress;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerAddress;
			}
		}

		public DataSet DeleteCustomerAddress(int intAddressID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@AddressID";
				objParameter.Value = intAddressID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDCustomerAddress", objParameterList);
				return dsCustomerAddress;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerAddress;
			}
		}
    
		public DataSet DeleteCustomerAddress()
		{
			try
			{
				ConnectAndExecute("DeleteAllCustomerAddress", new ArrayList()); //no parameter will send to stored procedure
				return dsCustomerAddress;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerAddress;
			}
		}
    
		public DataSet CustomerAddressTruncate()
        {
			try
			{
				ConnectAndExecute("CustomerAddressTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsCustomerAddress;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerAddress;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
