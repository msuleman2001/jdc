using System.Data;

namespace LogicKernal
{
	public class CustomerAddress
	{
		public static DataTable GetAllCustomerAddress()
		{
			try
			{
				DataKernal.CustomerAddress objCustomerAddress =  new DataKernal.CustomerAddress();
				return objCustomerAddress.SelectCustomerAddress().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetCustomerAddressByID(int intAddressID)
		{
			try
			{
				DataKernal.CustomerAddress objCustomerAddress = new DataKernal.CustomerAddress();
				return objCustomerAddress.SelectCustomerAddress(intAddressID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateCustomerAddress(BusinessEntities.CustomerAddress objCustomerAddress)
		{
			try
			{
				DataKernal.CustomerAddress objDCustomerAddress = new DataKernal.CustomerAddress();
				return objDCustomerAddress.InsertUpdateCustomerAddress(objCustomerAddress.AddressID,objCustomerAddress.CompleteAddress,objCustomerAddress.LatLong,objCustomerAddress.ClientID,objCustomerAddress.IsDefault,objCustomerAddress.Remarks,objCustomerAddress.DateJoind,objCustomerAddress.IsEnabled).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteCustomerAddress(int intAddressID)
		{
			try
			{
				DataKernal.CustomerAddress objCustomerAddress = new DataKernal.CustomerAddress();
				return objCustomerAddress.DeleteCustomerAddress(intAddressID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteCustomerAddress()
		{
			try
			{
				DataKernal.CustomerAddress objCustomerAddress = new DataKernal.CustomerAddress();
				return objCustomerAddress.DeleteCustomerAddress().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateCustomerAddress()
		{
			try
			{
				DataKernal.CustomerAddress objCustomerAddress = new DataKernal.CustomerAddress();
				return objCustomerAddress.CustomerAddressTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}