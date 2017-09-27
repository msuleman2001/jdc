using System.Data;

namespace LogicKernal
{
	public class FAQ
	{
		public static DataTable GetAllFAQ()
		{
			try
			{
				DataKernal.FAQ objFAQ =  new DataKernal.FAQ();
				return objFAQ.SelectFAQ().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetFAQByID(int intQuestionID)
		{
			try
			{
				DataKernal.FAQ objFAQ = new DataKernal.FAQ();
				return objFAQ.SelectFAQ(intQuestionID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateFAQ(BusinessEntities.FAQ objFAQ)
		{
			try
			{
				DataKernal.FAQ objDFAQ = new DataKernal.FAQ();
				return objDFAQ.InsertUpdateFAQ(objFAQ.QuestionID,objFAQ.QuestionDetail,objFAQ.AnswerDetail,objFAQ.FAQsCategoryID,objFAQ.AdminID,objFAQ.DateCreated,objFAQ.QuestionRemarks,objFAQ.IsEnabled).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteFAQ(int intQuestionID)
		{
			try
			{
				DataKernal.FAQ objFAQ = new DataKernal.FAQ();
				return objFAQ.DeleteFAQ(intQuestionID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteFAQ()
		{
			try
			{
				DataKernal.FAQ objFAQ = new DataKernal.FAQ();
				return objFAQ.DeleteFAQ().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateFAQ()
		{
			try
			{
				DataKernal.FAQ objFAQ = new DataKernal.FAQ();
				return objFAQ.FAQTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}