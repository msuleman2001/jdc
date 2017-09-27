using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class Vehicles
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conVehicles;
		SqlCommand comVehicles;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daVehicles;
		DataSet dsVehicles;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public Vehicles(string strConnString)
        {
			strConnectionString = strConnString;
			conVehicles = new SqlConnection(strConnectionString);
			comVehicles = new SqlCommand();
			daVehicles = new SqlDataAdapter();
			dsVehicles = new DataSet();
		}//end constructor
    
		public Vehicles()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conVehicles = new SqlConnection(strConnectionString);
			comVehicles = new SqlCommand();
			daVehicles = new SqlDataAdapter();
			dsVehicles = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conVehicles.Open();
			comVehicles.Connection = conVehicles;
			comVehicles.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comVehicles.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comVehicles.CommandType = CommandType.StoredProcedure;
			daVehicles.SelectCommand = comVehicles;
			daVehicles.Fill(dsVehicles);
			conVehicles.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsVehicles.Tables.Add(dtErrorTable);
		}

		public DataSet SelectVehicles()
		{
			try
			{
				ConnectAndExecute("VehiclesSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsVehicles;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsVehicles;
			}//end try
		}//end function

		public DataSet SelectVehicles(int intVehicleID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@VehicleID";
				objParameter.Value = intVehicleID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetVehiclesByID", objParameterList);
				return dsVehicles;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsVehicles;
			}
		}
		
		public DataSet InsertUpdateVehicles(Int64 intVehicleID, string strVehicleMake, string strVehicleColor, string strVehicleRegNO, Int64 intAgentID, Int64 intDriverID, string strVehicalImage, Int64 intAdminID, DateTime datDateCreated, bool blnIsEnabled, string strRemarks)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@VehicleID";
objParameter.Value = intVehicleID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@VehicleMake";
objParameter.Value = strVehicleMake;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@VehicleColor";
objParameter.Value = strVehicleColor;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@VehicleRegNO";
objParameter.Value = strVehicleRegNO;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AgentID";
objParameter.Value = intAgentID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@DriverID";
objParameter.Value = intDriverID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@VehicalImage";
objParameter.Value = strVehicalImage;
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
			
				ConnectAndExecute("InsertUpdateVehicles", objParameterList);
				return dsVehicles;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsVehicles;
			}
		}

		public DataSet DeleteVehicles(int intVehicleID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@VehicleID";
				objParameter.Value = intVehicleID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDVehicles", objParameterList);
				return dsVehicles;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsVehicles;
			}
		}
    
		public DataSet DeleteVehicles()
		{
			try
			{
				ConnectAndExecute("DeleteAllVehicles", new ArrayList()); //no parameter will send to stored procedure
				return dsVehicles;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsVehicles;
			}
		}
    
		public DataSet VehiclesTruncate()
        {
			try
			{
				ConnectAndExecute("VehiclesTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsVehicles;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsVehicles;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
