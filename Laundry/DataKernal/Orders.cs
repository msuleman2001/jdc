using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class Orders
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conOrders;
		SqlCommand comOrders;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daOrders;
		DataSet dsOrders;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Orders(string strConnString)
        {
			strConnectionString = strConnString;
			conOrders = new SqlConnection(strConnectionString);
			comOrders = new SqlCommand();
			daOrders = new SqlDataAdapter();
			dsOrders = new DataSet();
		}//end constructor
    
		public Orders()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conOrders = new SqlConnection(strConnectionString);
			comOrders = new SqlCommand();
			daOrders = new SqlDataAdapter();
			dsOrders = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conOrders.Open();
			comOrders.Connection = conOrders;
			comOrders.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comOrders.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comOrders.CommandType = CommandType.StoredProcedure;
			daOrders.SelectCommand = comOrders;
			daOrders.Fill(dsOrders);
			conOrders.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsOrders.Tables.Add(dtErrorTable);
		}

		public DataSet SelectOrders()
		{
			try
			{
				ConnectAndExecute("OrdersSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsOrders;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsOrders;
			}//end try
		}//end function

		public DataSet SelectOrders(int intOrderID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@OrderID";
				objParameter.Value = intOrderID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetOrdersByID", objParameterList);
				return dsOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrders;
			}
		}
		
		public DataSet InsertUpdateOrders(Int64 intOrderID, Int64 intClientID, Int64 intAdminID, Int64 intAgentID, DateTime datDateCreation, DateTime datRequestPickupDate, string strPickupTimeSlot, DateTime datRequestDropOffDate, string strDropOffTimeSlot, DateTime datPickupDateTime, DateTime datDropOfDateTime, string strStatus, bool blnIsEbabled, string strRemarks, string strOrderNumber)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@OrderID";
objParameter.Value = intOrderID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@ClientID";
objParameter.Value = intClientID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminID";
objParameter.Value = intAdminID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentID";
objParameter.Value = intAgentID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DateCreation";
objParameter.Value = datDateCreation;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@RequestPickupDate";
objParameter.Value = datRequestPickupDate;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@PickupTimeSlot";
objParameter.Value = strPickupTimeSlot;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@RequestDropOffDate";
objParameter.Value = datRequestDropOffDate;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DropOffTimeSlot";
objParameter.Value = strDropOffTimeSlot;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@PickupDateTime";
objParameter.Value = datPickupDateTime;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DropOfDateTime";
objParameter.Value = datDropOfDateTime;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@Status";
objParameter.Value = strStatus;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@IsEbabled";
objParameter.Value = blnIsEbabled;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@Remarks";
objParameter.Value = strRemarks;
objParameterList.Add(objParameter);
                objParameter = new SqlParameter();
                objParameter.ParameterName = "@OrderNumber";
                objParameter.Value = strOrderNumber;
                objParameterList.Add(objParameter);
                

                //end parameter setting

                ConnectAndExecute("InsertUpdateOrders", objParameterList);
				return dsOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrders;
			}
		}

		public DataSet DeleteOrders(int intOrderID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@OrderID";
				objParameter.Value = intOrderID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDOrders", objParameterList);
				return dsOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrders;
			}
		}
    
		public DataSet DeleteOrders()
		{
			try
			{
				ConnectAndExecute("DeleteAllOrders", new ArrayList()); //no parameter will send to stored procedure
				return dsOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrders;
			}
		}
    
		public DataSet OrdersTruncate()
        {
			try
			{
				ConnectAndExecute("OrdersTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrders;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
