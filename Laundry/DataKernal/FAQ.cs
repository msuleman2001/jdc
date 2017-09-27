using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


namespace DataKernal
{
	public class FAQ
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		SqlConnection conFAQ;
		SqlCommand comFAQ;
		string strConnectionString  = string.Empty;
		SqlDataAdapter daFAQ;
		DataSet dsFAQ;
		int intRecords;
		///////////////////////////////////////////////////////////////////////////////////////////


		//Constructor//////////////////////////////////////////////////////////////////////////////
		public FAQ(string strConnString)
        {
			strConnectionString = strConnString;
			conFAQ = new SqlConnection(strConnectionString);
			comFAQ = new SqlCommand();
			daFAQ = new SqlDataAdapter();
			dsFAQ = new DataSet();
		}//end constructor
    
		public FAQ()
        {
			strConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
			conFAQ = new SqlConnection(strConnectionString);
			comFAQ = new SqlCommand();
			daFAQ = new SqlDataAdapter();
			dsFAQ = new DataSet();
		}
		///////////////////////////////////////////////////////////////////////////////////////////

		//Private Methods///////////////////////////////////////////////////////////////////////////
		private void ConnectAndExecute(string strCommandText, ArrayList objParameterList)
		{
			conFAQ.Open();
			comFAQ.Connection = conFAQ;
			comFAQ.CommandText = strCommandText;
			//Adding parameters if required
			if (objParameterList.Count > 0) 
			{
				for (int intCounter = 0; intCounter < objParameterList.Count; intCounter++)
				{
					SqlParameter objParameter = new SqlParameter();
					objParameter = (SqlParameter) objParameterList[intCounter];
					comFAQ.Parameters.AddWithValue(objParameter.ParameterName, objParameter.Value);
				}
			}
			comFAQ.CommandType = CommandType.StoredProcedure;
			daFAQ.SelectCommand = comFAQ;
			daFAQ.Fill(dsFAQ);
			conFAQ.Close();
		}
		
		private void SetError(string strErrorMessage)
		{
			DataColumn colErrorMessage = new DataColumn("ErrorMessage");
			DataTable dtErrorTable = new DataTable();
			dtErrorTable.Columns.Add(colErrorMessage);
			DataRow drErrorRow = dtErrorTable.NewRow();
			drErrorRow[0] = strErrorMessage;
			dtErrorTable.Rows.Add(drErrorRow);
			dsFAQ.Tables.Add(dtErrorTable);
		}

		public DataSet SelectFAQ()
		{
			try
			{
				ConnectAndExecute("FAQSelectAll", new ArrayList()); //no parameter will send to stored procedure
				return dsFAQ;
			}
			catch (Exception ex) 
			{
				SetError(ex.Message);
				return dsFAQ;
			}//end try
		}//end function

		public DataSet SelectFAQ(int intQuestionID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@QuestionID";
				objParameter.Value = intQuestionID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("GetFAQByID", objParameterList);
				return dsFAQ;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQ;
			}
		}
		
		public DataSet InsertUpdateFAQ(Int64 intQuestionID, string strQuestionDetail, string strAnswerDetail, string strFAQsCategoryID, Int64 intAdminID, DateTime datDateCreated, string strQuestionRemarks, bool blnIsEnabled)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter;
				objParameter = new SqlParameter();
objParameter.ParameterName = "@QuestionID";
objParameter.Value = intQuestionID;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@QuestionDetail";
objParameter.Value = strQuestionDetail;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@AnswerDetail";
objParameter.Value = strAnswerDetail;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@FAQsCategoryID";
objParameter.Value = strFAQsCategoryID;
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
objParameter.ParameterName = "@QuestionRemarks";
objParameter.Value = strQuestionRemarks;
objParameterList.Add(objParameter);
objParameter = new SqlParameter();
objParameter.ParameterName = "@IsEnabled";
objParameter.Value = blnIsEnabled;
objParameterList.Add(objParameter);

				//end parameter setting
			
				ConnectAndExecute("InsertUpdateFAQ", objParameterList);
				return dsFAQ;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQ;
			}
		}

		public DataSet DeleteFAQ(int intQuestionID)
		{
			try
			{
				//parameter setting
				ArrayList objParameterList = new ArrayList();
				SqlParameter objParameter = new SqlParameter();
				objParameter.ParameterName = "@QuestionID";
				objParameter.Value = intQuestionID;
				objParameterList.Add(objParameter);
				//end parameter setting
			
				ConnectAndExecute("DeleteByIDFAQ", objParameterList);
				return dsFAQ;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQ;
			}
		}
    
		public DataSet DeleteFAQ()
		{
			try
			{
				ConnectAndExecute("DeleteAllFAQ", new ArrayList()); //no parameter will send to stored procedure
				return dsFAQ;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQ;
			}
		}
    
		public DataSet FAQTruncate()
        {
			try
			{
				ConnectAndExecute("FAQTruncate", new ArrayList()); //no parameter will send to stored procedure
				return dsFAQ;
			}
			catch (Exception ex)
			{
				SetError(ex.Message);
				return dsFAQ;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}
