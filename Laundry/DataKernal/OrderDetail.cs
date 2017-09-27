using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class OrderDetail
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conOrderDetail;
		SqlCommand comOrderDetail;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daOrderDetail;
		DataSet dsOrderDetail;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public OrderDetail(string strConnString)
        {
			strConnectionString = strConnString;
			conOrderDetail = new SqlConnection(strConnectionString);
			comOrderDetail = new SqlCommand();
			daOrderDetail = new SqlDataAdapter();
			dsOrderDetail = new DataSet();
		}//end constructor
    
		public OrderDetail()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conOrderDetail = new SqlConnection(strConnectionString);
			comOrderDetail = new SqlCommand();
			daOrderDetail = new SqlDataAdapter();
			dsOrderDetail = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conOrderDetail.Open();
			comOrderDetail.Connection = conOrderDetail;
			comOrderDetail.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comOrderDetail.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comOrderDetail.CommandType = CommandType.StoredProcedure;
			daOrderDetail.SelectCommand = comOrderDetail;
			daOrderDetail.Fill(dsOrderDetail);
			conOrderDetail.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsOrderDetail.Tables.Add(dtErrorTable);
		}

		public DataSet SelectOrderDetail()
		{
			try
			{
				ConnectAndExecute("OrderDetailSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsOrderDetail;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsOrderDetail;
			}//end try
		}//end function

		public DataSet SelectOrderDetail(int intOrderDetailID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@OrderDetailID";
				objParameter.Value = intOrderDetailID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetOrderDetailByID", objParameterList);
				return dsOrderDetail;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrderDetail;
			}
		}
		
		public DataSet InsertUpdateOrderDetail(Int64 intOrderDetailID, Int64 intOrderID, Int64 intItemID, Int64 intAgentID, Int64 intQuantity, string strUnitPrice, DateTime datDateTimeCreated, bool blnIsEnabled, string strRemarks)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@OrderDetailID";
objParameter.Value = intOrderDetailID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@OrderID";
objParameter.Value = intOrderID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@ItemID";
objParameter.Value = intItemID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentID";
objParameter.Value = intAgentID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@Quantity";
objParameter.Value = intQuantity;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@UnitPrice";
objParameter.Value = strUnitPrice;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DateTimeCreated";
objParameter.Value = datDateTimeCreated;
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
			
				ConnectAndExecute("InsertUpdateOrderDetail", objParameterList);
				return dsOrderDetail;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrderDetail;
			}
		}

		public DataSet DeleteOrderDetail(int intOrderDetailID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@OrderDetailID";
				objParameter.Value = intOrderDetailID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDOrderDetail", objParameterList);
				return dsOrderDetail;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrderDetail;
			}
		}
    
		public DataSet DeleteOrderDetail()
		{
			try
			{
				ConnectAndExecute("DeleteAllOrderDetail", new ArrayList()); //no parameter will send to stored procedure
				return dsOrderDetail;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrderDetail;
			}
		}
    
		public DataSet OrderDetailTruncate()
        {
			try
			{
				ConnectAndExecute("OrderDetailTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsOrderDetail;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsOrderDetail;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
