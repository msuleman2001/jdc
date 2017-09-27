using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class ValuePreferance
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conValuePreferance;
		SqlCommand comValuePreferance;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daValuePreferance;
		DataSet dsValuePreferance;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public ValuePreferance(string strConnString)
        {
			strConnectionString = strConnString;
			conValuePreferance = new SqlConnection(strConnectionString);
			comValuePreferance = new SqlCommand();
			daValuePreferance = new SqlDataAdapter();
			dsValuePreferance = new DataSet();
		}//end constructor
    
		public ValuePreferance()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conValuePreferance = new SqlConnection(strConnectionString);
			comValuePreferance = new SqlCommand();
			daValuePreferance = new SqlDataAdapter();
			dsValuePreferance = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conValuePreferance.Open();
			comValuePreferance.Connection = conValuePreferance;
			comValuePreferance.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comValuePreferance.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comValuePreferance.CommandType = CommandType.StoredProcedure;
			daValuePreferance.SelectCommand = comValuePreferance;
			daValuePreferance.Fill(dsValuePreferance);
			conValuePreferance.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsValuePreferance.Tables.Add(dtErrorTable);
		}

		public DataSet SelectValuePreferance()
		{
			try
			{
				ConnectAndExecute("ValuePreferanceSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsValuePreferance;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsValuePreferance;
			}//end try
		}//end function

		public DataSet SelectValuePreferance(int intValueID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@ValueID";
				objParameter.Value = intValueID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetValuePreferanceByID", objParameterList);
				return dsValuePreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsValuePreferance;
			}
		}
		
		public DataSet InsertUpdateValuePreferance(Int64 intValueID, string strValueName, Int64 intPreferanceID, string strRemarks, DateTime datDateCreated, bool blnIsEnabled)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@ValueID";
objParameter.Value = intValueID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@ValueName";
objParameter.Value = strValueName;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@PreferanceID";
objParameter.Value = intPreferanceID;
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
objParameter.ParameterName = "@IsEnabled";
objParameter.Value = blnIsEnabled;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdateValuePreferance", objParameterList);
				return dsValuePreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsValuePreferance;
			}
		}

		public DataSet DeleteValuePreferance(int intValueID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@ValueID";
				objParameter.Value = intValueID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDValuePreferance", objParameterList);
				return dsValuePreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsValuePreferance;
			}
		}
    
		public DataSet DeleteValuePreferance()
		{
			try
			{
				ConnectAndExecute("DeleteAllValuePreferance", new ArrayList()); //no parameter will send to stored procedure
				return dsValuePreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsValuePreferance;
			}
		}
    
		public DataSet ValuePreferanceTruncate()
        {
			try
			{
				ConnectAndExecute("ValuePreferanceTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsValuePreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsValuePreferance;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
