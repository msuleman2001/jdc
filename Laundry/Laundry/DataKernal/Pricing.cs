using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class Pricing
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conPricing;
		SqlCommand comPricing;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daPricing;
		DataSet dsPricing;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Pricing(string strConnString)
        {
			strConnectionString = strConnString;
			conPricing = new SqlConnection(strConnectionString);
			comPricing = new SqlCommand();
			daPricing = new SqlDataAdapter();
			dsPricing = new DataSet();
		}//end constructor
    
		public Pricing()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conPricing = new SqlConnection(strConnectionString);
			comPricing = new SqlCommand();
			daPricing = new SqlDataAdapter();
			dsPricing = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conPricing.Open();
			comPricing.Connection = conPricing;
			comPricing.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comPricing.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comPricing.CommandType = CommandType.StoredProcedure;
			daPricing.SelectCommand = comPricing;
			daPricing.Fill(dsPricing);
			conPricing.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsPricing.Tables.Add(dtErrorTable);
		}

		public DataSet SelectPricing()
		{
			try
			{
				ConnectAndExecute("PricingSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsPricing;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsPricing;
			}//end try
		}//end function

		public DataSet SelectPricing(int intAddressID)
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
			
				ConnectAndExecute("GetPricingByID", objParameterList);
				return dsPricing;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPricing;
			}
		}
		
		public DataSet InsertUpdatePricing(Int64 intPricingID, string strPriceingTitle, string strPricingValue, Int64 intPricingCategoryID, string strRemarks, DateTime datDateCreated, bool blnIsEnbled)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@PricingID";
objParameter.Value = intPricingID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@PriceingTitle";
objParameter.Value = strPriceingTitle;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@PricingValue";
objParameter.Value = strPricingValue;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@PricingCategoryID";
objParameter.Value = intPricingCategoryID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@Remarks";
objParameter.Value = strRemarks;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DateCreated";
objParameter.Value = datDateCreated;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@IsEnbled";
objParameter.Value = blnIsEnbled;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdatePricing", objParameterList);
				return dsPricing;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPricing;
			}
		}

		public DataSet DeletePricing(int intAddressID)
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
			
				ConnectAndExecute("DeleteByIDPricing", objParameterList);
				return dsPricing;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPricing;
			}
		}
    
		public DataSet DeletePricing()
		{
			try
			{
				ConnectAndExecute("DeleteAllPricing", new ArrayList()); //no parameter will send to stored procedure
				return dsPricing;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPricing;
			}
		}
    
		public DataSet PricingTruncate()
        {
			try
			{
				ConnectAndExecute("PricingTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsPricing;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPricing;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
