using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class ItemCategory
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conItemCategory;
		SqlCommand comItemCategory;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daItemCategory;
		DataSet dsItemCategory;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public ItemCategory(string strConnString)
        {
			strConnectionString = strConnString;
			conItemCategory = new SqlConnection(strConnectionString);
			comItemCategory = new SqlCommand();
			daItemCategory = new SqlDataAdapter();
			dsItemCategory = new DataSet();
		}//end constructor
    
		public ItemCategory()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conItemCategory = new SqlConnection(strConnectionString);
			comItemCategory = new SqlCommand();
			daItemCategory = new SqlDataAdapter();
			dsItemCategory = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conItemCategory.Open();
			comItemCategory.Connection = conItemCategory;
			comItemCategory.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comItemCategory.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comItemCategory.CommandType = CommandType.StoredProcedure;
			daItemCategory.SelectCommand = comItemCategory;
			daItemCategory.Fill(dsItemCategory);
			conItemCategory.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsItemCategory.Tables.Add(dtErrorTable);
		}

		public DataSet SelectItemCategory()
		{
			try
			{
				ConnectAndExecute("ItemCategorySelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsItemCategory;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsItemCategory;
			}//end try
		}//end function

		public DataSet SelectItemCategory(int intCategoryID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@CategoryID";
				objParameter.Value = intCategoryID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetItemCategoryByID", objParameterList);
				return dsItemCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItemCategory;
			}
		}
		
		public DataSet InsertUpdateItemCategory(Int64 intCategoryID, string strCategoryName, string strCategoryImage, Int64 intParentCategoryID, Int64 intAdminID, DateTime datDateCreated, bool blnIsEnabled, string strRemarks)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@CategoryID";
objParameter.Value = intCategoryID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CategoryName";
objParameter.Value = strCategoryName;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@CategoryImage";
objParameter.Value = strCategoryImage;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@ParentCategoryID";
objParameter.Value = intParentCategoryID;
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
			
				ConnectAndExecute("InsertUpdateItemCategory", objParameterList);
				return dsItemCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItemCategory;
			}
		}

		public DataSet DeleteItemCategory(int intCategoryID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@CategoryID";
				objParameter.Value = intCategoryID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDItemCategory", objParameterList);
				return dsItemCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItemCategory;
			}
		}
    
		public DataSet DeleteItemCategory()
		{
			try
			{
				ConnectAndExecute("DeleteAllItemCategory", new ArrayList()); //no parameter will send to stored procedure
				return dsItemCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItemCategory;
			}
		}
    
		public DataSet ItemCategoryTruncate()
        {
			try
			{
				ConnectAndExecute("ItemCategoryTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsItemCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsItemCategory;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
