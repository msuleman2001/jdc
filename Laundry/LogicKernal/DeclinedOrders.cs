using System.Data;

namespace LogicKernal
{
	public class DeclinedOrders
	{
		public static DataTable GetAllDeclinedOrders()
		{
			try
			{
				DataKernal.DeclinedOrders objDeclinedOrders =  new DataKernal.DeclinedOrders();
				return objDeclinedOrders.SelectDeclinedOrders().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable GetOrderByorderID(int OrderID)
        {

            DataTable dtOrders = GetAllDeclinedOrders();
            DataRow[] rows = dtOrders.Select("OrderID = " + OrderID.ToString());
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }

        public static DataTable GetOrderByAgentID(int AgentID)
        {

            DataTable dtOrders = GetAllDeclinedOrders();
            DataRow[] rows = dtOrders.Select("AgentID = " + AgentID.ToString());
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }

        public static DataTable GetOrderenabled()
        {

            DataTable dtOrders = GetAllDeclinedOrders();
            DataRow[] rows = dtOrders.Select("IsEnabled = 'True'");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }

        public static DataTable GetDeclinedOrdersByID(int intOrderDeclinedID)
		{
			try
			{
				DataKernal.DeclinedOrders objDeclinedOrders = new DataKernal.DeclinedOrders();
				return objDeclinedOrders.SelectDeclinedOrders(intOrderDeclinedID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateDeclinedOrders(BusinessEntities.DeclinedOrders objDeclinedOrders)
		{
			try
			{
				DataKernal.DeclinedOrders objDDeclinedOrders = new DataKernal.DeclinedOrders();
				return objDDeclinedOrders.InsertUpdateDeclinedOrders(objDeclinedOrders.OrderDeclinedID,objDeclinedOrders.OrderID,objDeclinedOrders.AgentID,objDeclinedOrders.AdminID,objDeclinedOrders.DateCreated,objDeclinedOrders.IsEnabled,objDeclinedOrders.DeclinedRemarks).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteDeclinedOrders(int intOrderDeclinedID)
		{
			try
			{
				DataKernal.DeclinedOrders objDeclinedOrders = new DataKernal.DeclinedOrders();
				return objDeclinedOrders.DeleteDeclinedOrders(intOrderDeclinedID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteDeclinedOrders()
		{
			try
			{
				DataKernal.DeclinedOrders objDeclinedOrders = new DataKernal.DeclinedOrders();
				return objDeclinedOrders.DeleteDeclinedOrders().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateDeclinedOrders()
		{
			try
			{
				DataKernal.DeclinedOrders objDeclinedOrders = new DataKernal.DeclinedOrders();
				return objDeclinedOrders.DeclinedOrdersTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}