using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class FAQsCategory
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conFAQsCategory;
		SqlCommand comFAQsCategory;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daFAQsCategory;
		DataSet dsFAQsCategory;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public FAQsCategory(string strConnString)
        {
			strConnectionString = strConnString;
			conFAQsCategory = new SqlConnection(strConnectionString);
			comFAQsCategory = new SqlCommand();
			daFAQsCategory = new SqlDataAdapter();
			dsFAQsCategory = new DataSet();
		}//end constructor
    
		public FAQsCategory()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conFAQsCategory = new SqlConnection(strConnectionString);
			comFAQsCategory = new SqlCommand();
			daFAQsCategory = new SqlDataAdapter();
			dsFAQsCategory = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conFAQsCategory.Open();
			comFAQsCategory.Connection = conFAQsCategory;
			comFAQsCategory.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comFAQsCategory.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comFAQsCategory.CommandType = CommandType.StoredProcedure;
			daFAQsCategory.SelectCommand = comFAQsCategory;
			daFAQsCategory.Fill(dsFAQsCategory);
			conFAQsCategory.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsFAQsCategory.Tables.Add(dtErrorTable);
		}

		public DataSet SelectFAQsCategory()
		{
			try
			{
				ConnectAndExecute("FAQsCategorySelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsFAQsCategory;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsFAQsCategory;
			}//end try
		}//end function

		public DataSet SelectFAQsCategory(int intFAQsCategoryID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@FAQsCategoryID";
				objParameter.Value = intFAQsCategoryID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetFAQsCategoryByID", objParameterList);
				return dsFAQsCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQsCategory;
			}
		}
		
		public DataSet InsertUpdateFAQsCategory(Int64 intFAQsCategoryID, string strFAQsCategoryName, Int64 intAdminID, bool blnIsEnabled, DateTime datDateCreated, string strFAQRemarks)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@FAQsCategoryID";
objParameter.Value = intFAQsCategoryID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@FAQsCategoryName";
objParameter.Value = strFAQsCategoryName;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AdminID";
objParameter.Value = intAdminID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@IsEnabled";
objParameter.Value = blnIsEnabled;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DateCreated";
objParameter.Value = datDateCreated;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@FAQRemarks";
objParameter.Value = strFAQRemarks;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdateFAQsCategory", objParameterList);
				return dsFAQsCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQsCategory;
			}
		}

		public DataSet DeleteFAQsCategory(int intFAQsCategoryID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@FAQsCategoryID";
				objParameter.Value = intFAQsCategoryID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDFAQsCategory", objParameterList);
				return dsFAQsCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQsCategory;
			}
		}
    
		public DataSet DeleteFAQsCategory()
		{
			try
			{
				ConnectAndExecute("DeleteAllFAQsCategory", new ArrayList()); //no parameter will send to stored procedure
				return dsFAQsCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQsCategory;
			}
		}
    
		public DataSet FAQsCategoryTruncate()
        {
			try
			{
				ConnectAndExecute("FAQsCategoryTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsFAQsCategory;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQsCategory;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
