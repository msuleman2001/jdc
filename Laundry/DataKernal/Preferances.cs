using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class Preferances
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conPreferances;
		SqlCommand comPreferances;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daPreferances;
		DataSet dsPreferances;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Preferances(string strConnString)
        {
			strConnectionString = strConnString;
			conPreferances = new SqlConnection(strConnectionString);
			comPreferances = new SqlCommand();
			daPreferances = new SqlDataAdapter();
			dsPreferances = new DataSet();
		}//end constructor
    
		public Preferances()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conPreferances = new SqlConnection(strConnectionString);
			comPreferances = new SqlCommand();
			daPreferances = new SqlDataAdapter();
			dsPreferances = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conPreferances.Open();
			comPreferances.Connection = conPreferances;
			comPreferances.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comPreferances.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comPreferances.CommandType = CommandType.StoredProcedure;
			daPreferances.SelectCommand = comPreferances;
			daPreferances.Fill(dsPreferances);
			conPreferances.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsPreferances.Tables.Add(dtErrorTable);
		}

		public DataSet SelectPreferances()
		{
			try
			{
				ConnectAndExecute("PreferancesSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsPreferances;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsPreferances;
			}//end try
		}//end function

		public DataSet SelectPreferances(int intPreferanceID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@PreferanceID";
				objParameter.Value = intPreferanceID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetPreferancesByID", objParameterList);
				return dsPreferances;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPreferances;
			}
		}
		
		public DataSet InsertUpdatePreferances(Int64 intPreferanceID, string strPreferanceName, string strRemarks, DateTime datDateCreated, bool blnIsEnabled)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@PreferanceID";
objParameter.Value = intPreferanceID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@PreferanceName";
objParameter.Value = strPreferanceName;
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
			
				ConnectAndExecute("InsertUpdatePreferances", objParameterList);
				return dsPreferances;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPreferances;
			}
		}

		public DataSet DeletePreferances(int intPreferanceID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@PreferanceID";
				objParameter.Value = intPreferanceID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDPreferances", objParameterList);
				return dsPreferances;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPreferances;
			}
		}
    
		public DataSet DeletePreferances()
		{
			try
			{
				ConnectAndExecute("DeleteAllPreferances", new ArrayList()); //no parameter will send to stored procedure
				return dsPreferances;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPreferances;
			}
		}
    
		public DataSet PreferancesTruncate()
        {
			try
			{
				ConnectAndExecute("PreferancesTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsPreferances;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsPreferances;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
