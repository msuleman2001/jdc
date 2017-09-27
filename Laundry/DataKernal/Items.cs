using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class Items
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conItems;
		SqlCommand comItems;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daItems;
		DataSet dsItems;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Items(string strConnString)
        {
			strConnectionString = strConnString;
			conItems = new SqlConnection(strConnectionString);
			comItems = new SqlCommand();
			daItems = new SqlDataAdapter();
			dsItems = new DataSet();
		}//end constructor
    
		public Items()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conItems = new SqlConnection(strConnectionString);
			comItems = new SqlCommand();
			daItems = new SqlDataAdapter();
			dsItems = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conItems.Open();
			comItems.Connection = conItems;
			comItems.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comItems.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comItems.CommandType = CommandType.StoredProcedure;
			daItems.SelectCommand = comItems;
			daItems.Fill(dsItems);
			conItems.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsItems.Tables.Add(dtErrorTable);
		}

		public DataSet SelectItems()
		{
			try
			{
				ConnectAndExecute("ItemsSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsItems;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsItems;
			}//end try
		}//end function

		public DataSet SelectItems(int intItemID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@ItemID";
				objParameter.Value = intItemID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetItemsByID", objParameterList);
				return dsItems;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItems;
			}
		}
		
		public DataSet InsertUpdateItems(Int64 intItemID, string strItemName, Int64 intCategoryID, string strItemImage, string strUnitPrice, Int64 intAdminID, DateTime datDateCreated, bool blnIsEnabled, string strRemarks)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@ItemID";
objParameter.Value = intItemID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@ItemName";
objParameter.Value = strItemName;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CategoryID";
objParameter.Value = intCategoryID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@ItemImage";
objParameter.Value = strItemImage;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@UnitPrice";
objParameter.Value = strUnitPrice;
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
			
				ConnectAndExecute("InsertUpdateItems", objParameterList);
				return dsItems;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItems;
			}
		}

		public DataSet DeleteItems(int intItemID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@ItemID";
				objParameter.Value = intItemID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDItems", objParameterList);
				return dsItems;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItems;
			}
		}
    
		public DataSet DeleteItems()
		{
			try
			{
				ConnectAndExecute("DeleteAllItems", new ArrayList()); //no parameter will send to stored procedure
				return dsItems;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItems;
			}
		}
    
		public DataSet ItemsTruncate()
        {
			try
			{
				ConnectAndExecute("ItemsTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsItems;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItems;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
