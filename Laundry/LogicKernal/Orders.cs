using System.Data;

namespace LogicKernal
{
	public class Orders
	{
		public static DataTable GetAllOrders()
		{
			try
			{
				DataKernal.Orders objOrders =  new DataKernal.Orders();
				return objOrders.SelectOrders().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
        public static DataTable GettAllCostomerOrder(int ClientID)
        {
         
            DataTable dtOrders = GetAllOrders();
            DataRow[] rows = dtOrders.Select("ClientID = " + ClientID.ToString());
            dtOrders = new DataTable();
            if(rows.Length>0)
                 dtOrders = rows.CopyToDataTable();
           
            return dtOrders;
        }

        public static DataTable GetToBePickOrder()
        {

            DataTable dtOrders = GetAllOrders();
            DataRow[] rows = dtOrders.Select("Status = 'Assigned' ");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }


        public static DataTable PlacedOrders()
        {

            DataTable dtOrders = GetAllOrders();
            DataRow[] rows = dtOrders.Select("Status = 'Placed'");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }


        public static DataTable CancledOrders()
        {

            DataTable dtOrders = GetAllOrders();
            DataRow[] rows = dtOrders.Select("Status = 'Canceled'");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }
        public static DataTable PickedOrders()
        {

            DataTable dtOrders = GetAllOrders();
            DataRow[] rows = dtOrders.Select("Status = 'Picked'");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }
        public static DataTable InProcessOrders()
        {

            DataTable dtOrders = GetAllOrders();
            DataRow[] rows = dtOrders.Select("Status = 'InProcess'");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }

        public static DataTable DeliveredOrders()
        {

            DataTable dtOrders = GetAllOrders();
            DataRow[] rows = dtOrders.Select("Status = 'DELIVERED'");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }

        public static DataTable GettAllAgentOrder(int AgentID)
        {

            DataTable dtOrders = GetAllOrders();
            DataRow[] rows = dtOrders.Select("AgentID = " + AgentID.ToString());
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }

        public static DataTable AgentToBePickOrder(int AgentID)
        {

            DataTable dtOrders = GettAllAgentOrder(AgentID);
            DataRow[] rows = dtOrders.Select("Status = 'Assigned' ");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }


        public static DataTable AgentPickedOrders(int AgentID)
        {

            DataTable dtOrders = GettAllAgentOrder(AgentID);
            DataRow[] rows = dtOrders.Select("Status = 'Picked'");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }
        public static DataTable AgentInProcessOrders(int AgentID)
        {

            DataTable dtOrders = GettAllAgentOrder(AgentID);
            DataRow[] rows = dtOrders.Select("Status = 'InProcess'");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }

        public static DataTable AgentDeliveredOrders(int AgentID)
        {

            DataTable dtOrders = GettAllAgentOrder(AgentID);
            DataRow[] rows = dtOrders.Select("Status = 'DELIVERED'");
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();

            return dtOrders;
        }

        public static DataTable GetOrdersByID(int intOrderID)
		{
			try
			{
				DataKernal.Orders objOrders = new DataKernal.Orders();
				return objOrders.SelectOrders(intOrderID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateOrders(BusinessEntities.Orders objOrders)
		{
			try
			{
				DataKernal.Orders objDOrders = new DataKernal.Orders();
				return objDOrders.InsertUpdateOrders(objOrders.OrderID,objOrders.ClientID,objOrders.AdminID,objOrders.AgentID,objOrders.DateCreation,objOrders.RequestPickupDate,objOrders.PickupTimeSlot,objOrders.RequestDropOffDate,objOrders.DropOffTimeSlot,objOrders.PickupDateTime,objOrders.DropOfDateTime,objOrders.Status,objOrders.IsEbabled,objOrders.Remarks, objOrders.OrderNumber).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteOrders(int intOrderID)
		{
			try
			{
				DataKernal.Orders objOrders = new DataKernal.Orders();
				return objOrders.DeleteOrders(intOrderID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteOrders()
		{
			try
			{
				DataKernal.Orders objOrders = new DataKernal.Orders();
				return objOrders.DeleteOrders().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateOrders()
		{
			try
			{
				DataKernal.Orders objOrders = new DataKernal.Orders();
				return objOrders.OrdersTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}