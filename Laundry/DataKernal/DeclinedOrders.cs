using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class DeclinedOrders
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conDeclinedOrders;
		SqlCommand comDeclinedOrders;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daDeclinedOrders;
		DataSet dsDeclinedOrders;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public DeclinedOrders(string strConnString)
        {
			strConnectionString = strConnString;
			conDeclinedOrders = new SqlConnection(strConnectionString);
			comDeclinedOrders = new SqlCommand();
			daDeclinedOrders = new SqlDataAdapter();
			dsDeclinedOrders = new DataSet();
		}//end constructor
    
		public DeclinedOrders()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conDeclinedOrders = new SqlConnection(strConnectionString);
			comDeclinedOrders = new SqlCommand();
			daDeclinedOrders = new SqlDataAdapter();
			dsDeclinedOrders = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conDeclinedOrders.Open();
			comDeclinedOrders.Connection = conDeclinedOrders;
			comDeclinedOrders.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comDeclinedOrders.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comDeclinedOrders.CommandType = CommandType.StoredProcedure;
			daDeclinedOrders.SelectCommand = comDeclinedOrders;
			daDeclinedOrders.Fill(dsDeclinedOrders);
			conDeclinedOrders.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsDeclinedOrders.Tables.Add(dtErrorTable);
		}

		public DataSet SelectDeclinedOrders()
		{
			try
			{
				ConnectAndExecute("DeclinedOrdersSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsDeclinedOrders;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsDeclinedOrders;
			}//end try
		}//end function

		public DataSet SelectDeclinedOrders(int intOrderDeclinedID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@OrderDeclinedID";
				objParameter.Value = intOrderDeclinedID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetDeclinedOrdersByID", objParameterList);
				return dsDeclinedOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsDeclinedOrders;
			}
		}
		
		public DataSet InsertUpdateDeclinedOrders(Int64 intOrderDeclinedID, Int64 intOrderID, Int64 intAgentID, Int64 intAdminID, DateTime datDateCreated, bool blnIsEnabled, string strDeclinedRemarks)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@OrderDeclinedID";
objParameter.Value = intOrderDeclinedID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@OrderID";
objParameter.Value = intOrderID;
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
objParameter.ParameterName = "@IsEnabled";
objParameter.Value = blnIsEnabled;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DeclinedRemarks";
objParameter.Value = strDeclinedRemarks;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdateDeclinedOrders", objParameterList);
				return dsDeclinedOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsDeclinedOrders;
			}
		}

		public DataSet DeleteDeclinedOrders(int intOrderDeclinedID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@OrderDeclinedID";
				objParameter.Value = intOrderDeclinedID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDDeclinedOrders", objParameterList);
				return dsDeclinedOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsDeclinedOrders;
			}
		}
    
		public DataSet DeleteDeclinedOrders()
		{
			try
			{
				ConnectAndExecute("DeleteAllDeclinedOrders", new ArrayList()); //no parameter will send to stored procedure
				return dsDeclinedOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsDeclinedOrders;
			}
		}
    
		public DataSet DeclinedOrdersTruncate()
        {
			try
			{
				ConnectAndExecute("DeclinedOrdersTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsDeclinedOrders;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsDeclinedOrders;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
