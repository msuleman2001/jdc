using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class ClientPreferance
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conClientPreferance;
		SqlCommand comClientPreferance;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daClientPreferance;
		DataSet dsClientPreferance;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public ClientPreferance(string strConnString)
        {
			strConnectionString = strConnString;
			conClientPreferance = new SqlConnection(strConnectionString);
			comClientPreferance = new SqlCommand();
			daClientPreferance = new SqlDataAdapter();
			dsClientPreferance = new DataSet();
		}//end constructor
    
		public ClientPreferance()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conClientPreferance = new SqlConnection(strConnectionString);
			comClientPreferance = new SqlCommand();
			daClientPreferance = new SqlDataAdapter();
			dsClientPreferance = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conClientPreferance.Open();
			comClientPreferance.Connection = conClientPreferance;
			comClientPreferance.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comClientPreferance.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comClientPreferance.CommandType = CommandType.StoredProcedure;
			daClientPreferance.SelectCommand = comClientPreferance;
			daClientPreferance.Fill(dsClientPreferance);
			conClientPreferance.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsClientPreferance.Tables.Add(dtErrorTable);
		}

		public DataSet SelectClientPreferance()
		{
			try
			{
				ConnectAndExecute("ClientPreferanceSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsClientPreferance;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsClientPreferance;
			}//end try
		}//end function

		public DataSet SelectClientPreferance(int intClientPreferanceID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@ClientPreferanceID";
				objParameter.Value = intClientPreferanceID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetClientPreferanceByID", objParameterList);
				return dsClientPreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientPreferance;
			}
		}
		
		public DataSet InsertUpdateClientPreferance(Int64 intClientPreferanceID, Int64 intClientID, Int64 intValueID, string strRemarks, DateTime datDateCreated, bool blnIsEnabled)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@ClientPreferanceID";
objParameter.Value = intClientPreferanceID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@ClientID";
objParameter.Value = intClientID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@ValueID";
objParameter.Value = intValueID;
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
			
				ConnectAndExecute("InsertUpdateClientPreferance", objParameterList);
				return dsClientPreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientPreferance;
			}
		}

		public DataSet DeleteClientPreferance(int intClientPreferanceID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@ClientPreferanceID";
				objParameter.Value = intClientPreferanceID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDClientPreferance", objParameterList);
				return dsClientPreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientPreferance;
			}
		}
    
		public DataSet DeleteClientPreferance()
		{
			try
			{
				ConnectAndExecute("DeleteAllClientPreferance", new ArrayList()); //no parameter will send to stored procedure
				return dsClientPreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientPreferance;
			}
		}
    
		public DataSet ClientPreferanceTruncate()
        {
			try
			{
				ConnectAndExecute("ClientPreferanceTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsClientPreferance;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsClientPreferance;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
