using System.Data;

namespace LogicKernal
{
	public class Items
	{
		public static DataTable GetAllItems()
		{
			try
			{
				DataKernal.Items objItems =  new DataKernal.Items();
				return objItems.SelectItems().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetItemsByID(int intItemID)
		{
			try
			{
				DataKernal.Items objItems = new DataKernal.Items();
				return objItems.SelectItems(intItemID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateItems(BusinessEntities.Items objItems)
		{
			try
			{
				DataKernal.Items objDItems = new DataKernal.Items();
				return objDItems.InsertUpdateItems(objItems.ItemID,objItems.ItemName,objItems.CategoryID,objItems.ItemImage,objItems.UnitPrice,objItems.AdminID,objItems.DateCreated,objItems.IsEnabled,objItems.Remarks).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteItems(int intItemID)
		{
			try
			{
				DataKernal.Items objItems = new DataKernal.Items();
				return objItems.DeleteItems(intItemID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteItems()
		{
			try
			{
				DataKernal.Items objItems = new DataKernal.Items();
				return objItems.DeleteItems().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateItems()
		{
			try
			{
				DataKernal.Items objItems = new DataKernal.Items();
				return objItems.ItemsTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}