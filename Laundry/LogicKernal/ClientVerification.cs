using System.Data;

namespace LogicKernal
{
	public class ClientVerification
	{
		public static DataTable GetAllClientVerification()
		{
			try
			{
				DataKernal.ClientVerification objClientVerification =  new DataKernal.ClientVerification();
				return objClientVerification.SelectClientVerification().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static int  GetIsVerificationCodeValid(string PhoneNo , string code, double time_span)
        {
            DataTable dtverification = GetAllClientVerification();
            DataRow[] rows = dtverification.Select("PhoneNO = " + PhoneNo);
            dtverification = new DataTable();
            if (rows.Length > 0)
                dtverification = rows.CopyToDataTable();

            foreach (DataRow dr in dtverification.Rows)
            {
                if (dr["VerificationCode"].ToString() == code)
                {
                    System.DateTime submit_time = System.Convert.ToDateTime(dr["VerificationDateTime"]);
                    if (submit_time < System.DateTime.Now.AddHours(time_span))
                        return System.Convert.ToInt32(dr["VerifiedID"]);
                    else
                        return 0;
                }
            }

            return 0;

        }

        public static DataTable GetClientVerificationByID(int intVerifiedID)
		{
			try
			{
				DataKernal.ClientVerification objClientVerification = new DataKernal.ClientVerification();
				return objClientVerification.SelectClientVerification(intVerifiedID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateClientVerification(BusinessEntities.ClientVerification objClientVerification)
		{
			try
			{
				DataKernal.ClientVerification objDClientVerification = new DataKernal.ClientVerification();
				return objDClientVerification.InsertUpdateClientVerification(objClientVerification.VerifiedID,objClientVerification.PhoneNO,objClientVerification.VerificationCode,objClientVerification.IsEnabled,objClientVerification.VerificationDateTime).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteClientVerification(int intVerifiedID)
		{
			try
			{
				DataKernal.ClientVerification objClientVerification = new DataKernal.ClientVerification();
				return objClientVerification.DeleteClientVerification(intVerifiedID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteClientVerification()
		{
			try
			{
				DataKernal.ClientVerification objClientVerification = new DataKernal.ClientVerification();
				return objClientVerification.DeleteClientVerification().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateClientVerification()
		{
			try
			{
				DataKernal.ClientVerification objClientVerification = new DataKernal.ClientVerification();
				return objClientVerification.ClientVerificationTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}