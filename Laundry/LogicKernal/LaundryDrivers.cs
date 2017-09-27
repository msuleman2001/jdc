using System.Data;

namespace LogicKernal
{
	public class LaundryDrivers
	{
		public static DataTable GetAllLaundryDrivers()
		{
			try
			{
				DataKernal.LaundryDrivers objLaundryDrivers =  new DataKernal.LaundryDrivers();
				return objLaundryDrivers.SelectLaundryDrivers().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetLaundryDriversByID(int intDriverID)
		{
			try
			{
				DataKernal.LaundryDrivers objLaundryDrivers = new DataKernal.LaundryDrivers();
				return objLaundryDrivers.SelectLaundryDrivers(intDriverID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateLaundryDrivers(BusinessEntities.LaundryDrivers objLaundryDrivers)
		{
			try
			{
				DataKernal.LaundryDrivers objDLaundryDrivers = new DataKernal.LaundryDrivers();
				return objDLaundryDrivers.InsertUpdateLaundryDrivers(objLaundryDrivers.DriverID,objLaundryDrivers.DriverName,objLaundryDrivers.DriverEmail,objLaundryDrivers.DriverPassword,objLaundryDrivers.DriverPhoneNO,objLaundryDrivers.DriverImage,objLaundryDrivers.DriverlicenceNO,objLaundryDrivers.LicenceIssueDate,objLaundryDrivers.LicenceExpDate,objLaundryDrivers.DriverAddress,objLaundryDrivers.AgentID,objLaundryDrivers.AdminID,objLaundryDrivers.DateCreated,objLaundryDrivers.Remarks,objLaundryDrivers.IsEnable).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteLaundryDrivers(int intDriverID)
		{
			try
			{
				DataKernal.LaundryDrivers objLaundryDrivers = new DataKernal.LaundryDrivers();
				return objLaundryDrivers.DeleteLaundryDrivers(intDriverID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteLaundryDrivers()
		{
			try
			{
				DataKernal.LaundryDrivers objLaundryDrivers = new DataKernal.LaundryDrivers();
				return objLaundryDrivers.DeleteLaundryDrivers().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateLaundryDrivers()
		{
			try
			{
				DataKernal.LaundryDrivers objLaundryDrivers = new DataKernal.LaundryDrivers();
				return objLaundryDrivers.LaundryDriversTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}