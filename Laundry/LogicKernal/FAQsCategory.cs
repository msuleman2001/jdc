using System.Data;

namespace LogicKernal
{
	public class FAQsCategory
	{
		public static DataTable GetAllFAQsCategory()
		{
			try
			{
				DataKernal.FAQsCategory objFAQsCategory =  new DataKernal.FAQsCategory();
				return objFAQsCategory.SelectFAQsCategory().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetFAQsCategoryByID(int intFAQsCategoryID)
		{
			try
			{
				DataKernal.FAQsCategory objFAQsCategory = new DataKernal.FAQsCategory();
				return objFAQsCategory.SelectFAQsCategory(intFAQsCategoryID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateFAQsCategory(BusinessEntities.FAQsCategory objFAQsCategory)
		{
			try
			{
				DataKernal.FAQsCategory objDFAQsCategory = new DataKernal.FAQsCategory();
				return objDFAQsCategory.InsertUpdateFAQsCategory(objFAQsCategory.FAQsCategoryID,objFAQsCategory.FAQsCategoryName,objFAQsCategory.AdminID,objFAQsCategory.IsEnabled,objFAQsCategory.DateCreated,objFAQsCategory.FAQRemarks).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteFAQsCategory(int intFAQsCategoryID)
		{
			try
			{
				DataKernal.FAQsCategory objFAQsCategory = new DataKernal.FAQsCategory();
				return objFAQsCategory.DeleteFAQsCategory(intFAQsCategoryID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteFAQsCategory()
		{
			try
			{
				DataKernal.FAQsCategory objFAQsCategory = new DataKernal.FAQsCategory();
				return objFAQsCategory.DeleteFAQsCategory().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateFAQsCategory()
		{
			try
			{
				DataKernal.FAQsCategory objFAQsCategory = new DataKernal.FAQsCategory();
				return objFAQsCategory.FAQsCategoryTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}