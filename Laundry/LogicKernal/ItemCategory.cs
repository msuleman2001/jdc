using System.Data;

namespace LogicKernal
{
	public class ItemCategory
	{
		public static DataTable GetAllItemCategory()
		{
			try
			{
				DataKernal.ItemCategory objItemCategory =  new DataKernal.ItemCategory();
				return objItemCategory.SelectItemCategory().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetItemCategoryByID(int intCategoryID)
		{
			try
			{
				DataKernal.ItemCategory objItemCategory = new DataKernal.ItemCategory();
				return objItemCategory.SelectItemCategory(intCategoryID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateItemCategory(BusinessEntities.ItemCategory objItemCategory)
		{
			try
			{
				DataKernal.ItemCategory objDItemCategory = new DataKernal.ItemCategory();
				return objDItemCategory.InsertUpdateItemCategory(objItemCategory.CategoryID,objItemCategory.CategoryName,objItemCategory.CategoryImage,objItemCategory.ParentCategoryID,objItemCategory.AdminID,objItemCategory.DateCreated,objItemCategory.IsEnabled,objItemCategory.Remarks).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteItemCategory(int intCategoryID)
		{
			try
			{
				DataKernal.ItemCategory objItemCategory = new DataKernal.ItemCategory();
				return objItemCategory.DeleteItemCategory(intCategoryID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteItemCategory()
		{
			try
			{
				DataKernal.ItemCategory objItemCategory = new DataKernal.ItemCategory();
				return objItemCategory.DeleteItemCategory().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateItemCategory()
		{
			try
			{
				DataKernal.ItemCategory objItemCategory = new DataKernal.ItemCategory();
				return objItemCategory.ItemCategoryTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}