using System.Data;

namespace LogicKernal
{
	public class Vehicles
	{
		public static DataTable GetAllVehicles()
		{
			try
			{
				DataKernal.Vehicles objVehicles =  new DataKernal.Vehicles();
				return objVehicles.SelectVehicles().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetVehiclesByID(int intVehicleID)
		{
			try
			{
				DataKernal.Vehicles objVehicles = new DataKernal.Vehicles();
				return objVehicles.SelectVehicles(intVehicleID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateVehicles(BusinessEntities.Vehicles objVehicles)
		{
			try
			{
				DataKernal.Vehicles objDVehicles = new DataKernal.Vehicles();
				return objDVehicles.InsertUpdateVehicles(objVehicles.VehicleID,objVehicles.VehicleMake,objVehicles.VehicleColor,objVehicles.VehicleRegNO,objVehicles.AgentID,objVehicles.DriverID,objVehicles.VehicalImage,objVehicles.AdminID,objVehicles.DateCreated,objVehicles.IsEnabled,objVehicles.Remarks).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteVehicles(int intVehicleID)
		{
			try
			{
				DataKernal.Vehicles objVehicles = new DataKernal.Vehicles();
				return objVehicles.DeleteVehicles(intVehicleID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteVehicles()
		{
			try
			{
				DataKernal.Vehicles objVehicles = new DataKernal.Vehicles();
				return objVehicles.DeleteVehicles().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateVehicles()
		{
			try
			{
				DataKernal.Vehicles objVehicles = new DataKernal.Vehicles();
				return objVehicles.VehiclesTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}