using System.Data;

namespace LogicKernal
{
	public class CustomerProfile
	{
		public static DataTable GetAllCustomerProfile()
		{
			try
			{
				DataKernal.CustomerProfile objCustomerProfile =  new DataKernal.CustomerProfile();
				return objCustomerProfile.SelectCustomerProfile().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetCustomerProfileByID(int intAddressID)
		{
			try
			{
				DataKernal.CustomerProfile objCustomerProfile = new DataKernal.CustomerProfile();
				return objCustomerProfile.SelectCustomerProfile(intAddressID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateCustomerProfile(BusinessEntities.CustomerProfile objCustomerProfile)
		{
			try
			{
				DataKernal.CustomerProfile objDCustomerProfile = new DataKernal.CustomerProfile();
				return objDCustomerProfile.InsertUpdateCustomerProfile(objCustomerProfile.ClientID,objCustomerProfile.CustomerName,objCustomerProfile.CustomerAddress,objCustomerProfile.CustomerPhoneNo,objCustomerProfile.CustomerEmail,objCustomerProfile.CustomerPassword,objCustomerProfile.DateJoind,objCustomerProfile.CustomerRemarks,objCustomerProfile.IsEnabled, objCustomerProfile.CustomerImage).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteCustomerProfile(int intAddressID)
		{
			try
			{
				DataKernal.CustomerProfile objCustomerProfile = new DataKernal.CustomerProfile();
				return objCustomerProfile.DeleteCustomerProfile(intAddressID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteCustomerProfile()
		{
			try
			{
				DataKernal.CustomerProfile objCustomerProfile = new DataKernal.CustomerProfile();
				return objCustomerProfile.DeleteCustomerProfile().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateCustomerProfile()
		{
			try
			{
				DataKernal.CustomerProfile objCustomerProfile = new DataKernal.CustomerProfile();
				return objCustomerProfile.CustomerProfileTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
        
        public static int Login(string UserEmail,string UserPassword)
        {
            DataTable dtCustomer = new DataTable();
            DataKernal.CustomerProfile da = new DataKernal.CustomerProfile();
            dtCustomer = da.SelectCustomerProfile().Tables[0];
            foreach (DataRow dr in dtCustomer.Rows)
            {
                if (dr["CustomerEmail"].ToString() == UserEmail || dr["CustomerPhoneNo"].ToString()== UserEmail)
                {
                    if (dr["CustomerPassword"].ToString() == UserPassword)
                        return int.Parse(dr["ClientID"].ToString());
                }
            }

            return 0;
        }
	}
}