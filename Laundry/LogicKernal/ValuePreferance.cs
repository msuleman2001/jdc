using System.Data;

namespace LogicKernal
{
	public class ValuePreferance
	{
		public static DataTable GetAllValuePreferance()
		{
			try
			{
				DataKernal.ValuePreferance objValuePreferance =  new DataKernal.ValuePreferance();
				return objValuePreferance.SelectValuePreferance().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
        public static DataTable PrefecanceValueByID(int intPreferanceID)
        {
            DataTable dtCards = GetAllValuePreferance();

            DataRow[] rows = dtCards.Select("PreferanceID = " + intPreferanceID.ToString());
            dtCards = new DataTable();
            if(rows.Length>0)
                dtCards = rows.CopyToDataTable();
            return dtCards;


        }
        public static DataTable PrefecanceValueByPrefrenceID(int intPreferanceID)
        {
            DataTable dtCards = GetAllValuePreferance();

            DataRow[] rows = dtCards.Select("PreferanceID = " + intPreferanceID.ToString());
            dtCards = new DataTable();
            if (rows.Length > 0)
                dtCards = rows.CopyToDataTable();
            return dtCards;


        }

        public static DataTable PrefecanceValueByintPreferanceID(int intPreferanceID , int ClientID)
        {
            DataTable dtvalue = LogicKernal.ClientPreferance.ClientPreferancesByClientID(ClientID);
            int ValueID;
            DataTable dtSelectedValues = new DataTable();
            foreach (DataRow dr in dtvalue.Rows)
            {
                 ValueID =int.Parse(dr["ValueID"].ToString());

                DataTable dtValues = LogicKernal.ValuePreferance.GetValuePreferanceByID(ValueID);
                
                DataRow[] rowss = dtValues.Select("PreferanceID = " + intPreferanceID.ToString());
                
                if (rowss.Length > 0)
                    if(dtSelectedValues.Rows.Count>0)
                    {


                        dtSelectedValues = rowss.CopyToDataTable();

                    }
                else
                dtSelectedValues =rowss.CopyToDataTable();
            }
           
            
            return dtSelectedValues;
           


        }

        public static DataTable GetValuePreferanceByID(int intValueID)
		{
			try
			{
				DataKernal.ValuePreferance objValuePreferance = new DataKernal.ValuePreferance();
				return objValuePreferance.SelectValuePreferance(intValueID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

    
		public static DataTable InsertUpdateValuePreferance(BusinessEntities.ValuePreferance objValuePreferance)
		{
			try
			{
				DataKernal.ValuePreferance objDValuePreferance = new DataKernal.ValuePreferance();
				return objDValuePreferance.InsertUpdateValuePreferance(objValuePreferance.ValueID,objValuePreferance.ValueName,objValuePreferance.PreferanceID,objValuePreferance.Remarks,objValuePreferance.DateCreated,objValuePreferance.IsEnabled).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteValuePreferance(int intValueID)
		{
			try
			{
				DataKernal.ValuePreferance objValuePreferance = new DataKernal.ValuePreferance();
				return objValuePreferance.DeleteValuePreferance(intValueID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteValuePreferance()
		{
			try
			{
				DataKernal.ValuePreferance objValuePreferance = new DataKernal.ValuePreferance();
				return objValuePreferance.DeleteValuePreferance().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateValuePreferance()
		{
			try
			{
				DataKernal.ValuePreferance objValuePreferance = new DataKernal.ValuePreferance();
				return objValuePreferance.ValuePreferanceTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}