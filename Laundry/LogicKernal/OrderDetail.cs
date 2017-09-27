using System.Data;

namespace LogicKernal
{
	public class OrderDetail
	{
		public static DataTable GetAllOrderDetail()
		{
			try
			{
				DataKernal.OrderDetail objOrderDetail =  new DataKernal.OrderDetail();
				return objOrderDetail.SelectOrderDetail().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable GetOrderDetailbyOrderID(int OrderID)
        {
            DataTable dtOrders = GetAllOrderDetail();
            DataRow[] rows = dtOrders.Select("OrderID = " + OrderID.ToString());
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();
            return dtOrders;
        }

        public static DataTable GetItemPrice(int ItemID , int OrderID)
        {

            DataTable dtOrders = GetAllOrderDetail();
            DataRow[] rows = dtOrders.Select("OrderID = " + OrderID.ToString());
            dtOrders = new DataTable();
            if (rows.Length > 0)
                dtOrders = rows.CopyToDataTable();
            if(dtOrders.Rows.Count>0)
            {
                DataRow[] row = dtOrders.Select("ItemID = " + ItemID.ToString());
                dtOrders = new DataTable();
                if (rows.Length > 0)
                    dtOrders = rows.CopyToDataTable();
            }
            

            return dtOrders;
        }

        

        public static DataTable GetAllDetails(int OrderID)
        {

            DataTable dtOrderDetail = GetAllOrderDetail();
            DataRow[] rows = dtOrderDetail.Select("OrderID = " + OrderID.ToString());
            dtOrderDetail = new DataTable();
            if (rows.Length > 0)
            {
                
                dtOrderDetail = rows.CopyToDataTable();
                DataView view = new DataView(dtOrderDetail);
                DataTable distinctValues = view.ToTable(true, "ItemID");
                return distinctValues;
            }
            else
            {
                return dtOrderDetail;
            }
        }

        public static int getitemcountbyItemIdOrderID(int ItemID,int OrderID )
        {

            DataTable dtOrderDetail = GetAllOrderDetail();
            DataRow[] rows = dtOrderDetail.Select("OrderID = " + OrderID.ToString());
            dtOrderDetail = new DataTable();
            dtOrderDetail = rows.CopyToDataTable();


            DataRow[] row = dtOrderDetail.Select("ItemID= " + ItemID.ToString());
            dtOrderDetail = new DataTable();
            dtOrderDetail = row.CopyToDataTable();
            int qty = dtOrderDetail.Rows.Count;
            return qty;

        }

        public static DataTable DeleteOrderDetailBYItemIDOrderID(int ItemID, int OrderID)
        {

            DataTable dtOrderDetail = GetAllOrderDetail();
            DataRow[] rows = dtOrderDetail.Select("OrderID = " + OrderID.ToString());
            dtOrderDetail = new DataTable();
            dtOrderDetail = rows.CopyToDataTable();


            DataRow[] row = dtOrderDetail.Select("ItemID= " + ItemID.ToString());
            dtOrderDetail = new DataTable();
            dtOrderDetail = row.CopyToDataTable();
            int qty = dtOrderDetail.Rows.Count;

            for (int i = 0; i < qty; i++)
            {
                int OrderDetailID = System.Convert.ToInt32(dtOrderDetail.Rows[i]["OrderDetailID"]);

                DeleteOrderDetail(OrderDetailID);

            }
            return null;
            
        }

        public static DataTable GetOrderDetailByID(int intOrderDetailID)
		{
			try
			{
				DataKernal.OrderDetail objOrderDetail = new DataKernal.OrderDetail();
				return objOrderDetail.SelectOrderDetail(intOrderDetailID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateOrderDetail(BusinessEntities.OrderDetail objOrderDetail)
		{
			try
			{
				DataKernal.OrderDetail objDOrderDetail = new DataKernal.OrderDetail();
				return objDOrderDetail.InsertUpdateOrderDetail(objOrderDetail.OrderDetailID,objOrderDetail.OrderID,objOrderDetail.ItemID,objOrderDetail.AgentID,objOrderDetail.Quantity, objOrderDetail.UnitPrice,objOrderDetail.DateTimeCreated,objOrderDetail.IsEnabled,objOrderDetail.Remarks).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteOrderDetail(int intOrderDetailID)
		{
			try
			{
				DataKernal.OrderDetail objOrderDetail = new DataKernal.OrderDetail();
				return objOrderDetail.DeleteOrderDetail(intOrderDetailID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteOrderDetail()
		{
			try
			{
				DataKernal.OrderDetail objOrderDetail = new DataKernal.OrderDetail();
				return objOrderDetail.DeleteOrderDetail().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateOrderDetail()
		{
			try
			{
				DataKernal.OrderDetail objOrderDetail = new DataKernal.OrderDetail();
				return objOrderDetail.OrderDetailTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}