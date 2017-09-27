using System.Data;

namespace LogicKernal
{
	public class ClientPreferance
	{
		public static DataTable GetAllClientPreferance()
		{
			try
			{
				DataKernal.ClientPreferance objClientPreferance =  new DataKernal.ClientPreferance();
				return objClientPreferance.SelectClientPreferance().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable ClientPreferancesByClientID(int intClientID)
        {
            DataTable dtpreferances = GetAllClientPreferance();

            DataRow[] rows = dtpreferances.Select("ClientID = " + intClientID.ToString());
            dtpreferances = new DataTable();
            if (rows.Length > 0)
                dtpreferances = rows.CopyToDataTable();
            return dtpreferances;


        }
        public static bool GetAllClientPreferanceByValueID(int client_id, int prefrence_value_id)
        {
            DataTable dtCLientPreferences = ClientPreferance.ClientPreferancesByClientID(client_id);

            if (dtCLientPreferences.Rows.Count > 0)
            {
                DataRow[] rows = dtCLientPreferences.Select("ValueID = " + prefrence_value_id.ToString());

                dtCLientPreferences = new DataTable();

                if (rows.Length > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public static DataTable GetClientPreferanceByID(int intClientPreferanceID)
		{
			try
			{
				DataKernal.ClientPreferance objClientPreferance = new DataKernal.ClientPreferance();
				return objClientPreferance.SelectClientPreferance(intClientPreferanceID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateClientPreferance(BusinessEntities.ClientPreferance objClientPreferance)
		{
			try
			{
				DataKernal.ClientPreferance objDClientPreferance = new DataKernal.ClientPreferance();
				return objDClientPreferance.InsertUpdateClientPreferance(objClientPreferance.ClientPreferanceID,objClientPreferance.ClientID,objClientPreferance.ValueID,objClientPreferance.Remarks,objClientPreferance.DateCreated,objClientPreferance.IsEnabled).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static DataTable DeleteClientPreferancesByClientID(int ClientID )
        {
            DataTable dtClientPreferances = ClientPreferancesByClientID(ClientID);
            foreach (DataRow dr in dtClientPreferances.Rows)
            {
                int ClientPreferanceID = int.Parse(dr["ClientPreferanceID"].ToString());
                DataKernal.ClientPreferance objClientPreferance = new DataKernal.ClientPreferance();
                objClientPreferance.DeleteClientPreferance(ClientPreferanceID);
            }

            return null;
        }

     

        public static DataTable DeleteClientPreferance(int intClientPreferanceID)
		{
			try
			{
				DataKernal.ClientPreferance objClientPreferance = new DataKernal.ClientPreferance();
				return objClientPreferance.DeleteClientPreferance(intClientPreferanceID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteClientPreferance()
		{
			try
			{
				DataKernal.ClientPreferance objClientPreferance = new DataKernal.ClientPreferance();
				return objClientPreferance.DeleteClientPreferance().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateClientPreferance()
		{
			try
			{
				DataKernal.ClientPreferance objClientPreferance = new DataKernal.ClientPreferance();
				return objClientPreferance.ClientPreferanceTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}