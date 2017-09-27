using System.Data;

namespace LogicKernal
{
	public class Preferances
	{
		public static DataTable GetAllPreferances()
		{
			try
			{
				DataKernal.Preferances objPreferances =  new DataKernal.Preferances();
				return objPreferances.SelectPreferances().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetPreferancesByID(int intPreferanceID)
		{
			try
			{
				DataKernal.Preferances objPreferances = new DataKernal.Preferances();
				return objPreferances.SelectPreferances(intPreferanceID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdatePreferances(BusinessEntities.Preferances objPreferances)
		{
			try
			{
				DataKernal.Preferances objDPreferances = new DataKernal.Preferances();
				return objDPreferances.InsertUpdatePreferances(objPreferances.PreferanceID,objPreferances.PreferanceName,objPreferances.Remarks,objPreferances.DateCreated,objPreferances.IsEnabled).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeletePreferances(int intPreferanceID)
		{
			try
			{
				DataKernal.Preferances objPreferances = new DataKernal.Preferances();
				return objPreferances.DeletePreferances(intPreferanceID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeletePreferances()
		{
			try
			{
				DataKernal.Preferances objPreferances = new DataKernal.Preferances();
				return objPreferances.DeletePreferances().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncatePreferances()
		{
			try
			{
				DataKernal.Preferances objPreferances = new DataKernal.Preferances();
				return objPreferances.PreferancesTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}