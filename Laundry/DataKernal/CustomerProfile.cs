using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class CustomerProfile
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conCustomerProfile;
		SqlCommand comCustomerProfile;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daCustomerProfile;
		DataSet dsCustomerProfile;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public CustomerProfile(string strConnString)
        {
			strConnectionString = strConnString;
			conCustomerProfile = new SqlConnection(strConnectionString);
			comCustomerProfile = new SqlCommand();
			daCustomerProfile = new SqlDataAdapter();
			dsCustomerProfile = new DataSet();
		}//end constructor
    
		public CustomerProfile()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conCustomerProfile = new SqlConnection(strConnectionString);
			comCustomerProfile = new SqlCommand();
			daCustomerProfile = new SqlDataAdapter();
			dsCustomerProfile = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conCustomerProfile.Open();
			comCustomerProfile.Connection = conCustomerProfile;
			comCustomerProfile.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comCustomerProfile.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comCustomerProfile.CommandType = CommandType.StoredProcedure;
			daCustomerProfile.SelectCommand = comCustomerProfile;
			daCustomerProfile.Fill(dsCustomerProfile);
			conCustomerProfile.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsCustomerProfile.Tables.Add(dtErrorTable);
		}

		public DataSet SelectCustomerProfile()
		{
			try
			{
				ConnectAndExecute("CustomerProfileSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsCustomerProfile;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsCustomerProfile;
			}//end try
		}//end function

		public DataSet SelectCustomerProfile(int intAddressID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@ClientID";
				objParameter.Value = intAddressID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetCustomerProfileByID", objParameterList);
				return dsCustomerProfile;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerProfile;
			}
		}
		
		public DataSet InsertUpdateCustomerProfile(Int64 intClientID, string strCustomerName, string strCustomerAddress, string strCustomerPhoneNo, string strCustomerEmail, string strCustomerPassword, DateTime datDateJoind, string strCustomerRemarks, bool blnIsEnabled, string strCustomerImage)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@ClientID";
objParameter.Value = intClientID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CustomerName";
objParameter.Value = strCustomerName;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CustomerAddress";
objParameter.Value = strCustomerAddress;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CustomerPhoneNo";
objParameter.Value = strCustomerPhoneNo;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CustomerEmail";
objParameter.Value = strCustomerEmail;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CustomerPassword";
objParameter.Value = strCustomerPassword;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DateJoind";
objParameter.Value = datDateJoind;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CustomerRemarks";
objParameter.Value = strCustomerRemarks;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@IsEnabled";
objParameter.Value = blnIsEnabled;
objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@CustomerImage";
                objParameter.Value = strCustomerImage;
                objParameterList.Add(objParameter);

                //end parameter setting

                ConnectAndExecute("InsertUpdateCustomerProfile", objParameterList);
				return dsCustomerProfile;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerProfile;
			}
		}

		public DataSet DeleteCustomerProfile(int intAddressID)
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
			
				ConnectAndExecute("DeleteByIDCustomerProfile", objParameterList);
				return dsCustomerProfile;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerProfile;
			}
		}
    
		public DataSet DeleteCustomerProfile()
		{
			try
			{
				ConnectAndExecute("DeleteAllCustomerProfile", new ArrayList()); //no parameter will send to stored procedure
				return dsCustomerProfile;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerProfile;
			}
		}
    
		public DataSet CustomerProfileTruncate()
        {
			try
			{
				ConnectAndExecute("CustomerProfileTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsCustomerProfile;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsCustomerProfile;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
