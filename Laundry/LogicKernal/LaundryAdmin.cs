using System.Data;

namespace LogicKernal
{
	public class LaundryAdmin
	{
		public static DataTable GetAllLaundryAdmin()
		{
			try
			{
				DataKernal.LaundryAdmin objLaundryAdmin =  new DataKernal.LaundryAdmin();
				return objLaundryAdmin.SelectLaundryAdmin().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetLaundryAdminByID(int intAdminID)
		{
			try
			{
				DataKernal.LaundryAdmin objLaundryAdmin = new DataKernal.LaundryAdmin();
				return objLaundryAdmin.SelectLaundryAdmin(intAdminID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateLaundryAdmin(BusinessEntities.LaundryAdmin objLaundryAdmin)
		{
			try
			{
				DataKernal.LaundryAdmin objDLaundryAdmin = new DataKernal.LaundryAdmin();
                return objDLaundryAdmin.InsertUpdateLaundryAdmin(objLaundryAdmin.AdminID, objLaundryAdmin.AdminName, objLaundryAdmin.AdminEmail, objLaundryAdmin.AdminPassword, objLaundryAdmin.PhoneNo, objLaundryAdmin.Address, objLaundryAdmin.AdminImage, objLaundryAdmin.AdminType, objLaundryAdmin.AdmindateJoind, objLaundryAdmin.IsEnabled, objLaundryAdmin.AdminRemarks).Tables[0];
            }
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteLaundryAdmin(int intAdminID)
		{
			try
			{
				DataKernal.LaundryAdmin objLaundryAdmin = new DataKernal.LaundryAdmin();
				return objLaundryAdmin.DeleteLaundryAdmin(intAdminID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteLaundryAdmin()
		{
			try
			{
				DataKernal.LaundryAdmin objLaundryAdmin = new DataKernal.LaundryAdmin();
				return objLaundryAdmin.DeleteLaundryAdmin().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateLaundryAdmin()
		{
			try
			{
				DataKernal.LaundryAdmin objLaundryAdmin = new DataKernal.LaundryAdmin();
				return objLaundryAdmin.LaundryAdminTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
        public static int Login(string UserEmail, string UserPassword)
        {
            DataTable dtAdmin = new DataTable();
            DataKernal.LaundryAdmin da = new DataKernal.LaundryAdmin();
            dtAdmin = da.SelectLaundryAdmin().Tables[0];
            foreach (DataRow dr in dtAdmin.Rows)
            {
                if (dr["AdminEmail"].ToString() == UserEmail)
                {
                    if (dr["AdminPassword"].ToString() == UserPassword)
                        return int.Parse(dr["AdminID"].ToString());
                }
            }

            return 0;
        }
    }
}