using System.Data;

namespace LogicKernal
{
	public class LaundryAgent
	{
		public static DataTable GetAllLaundryAgent()
		{
			try
			{
				DataKernal.LaundryAgent objLaundryAgent =  new DataKernal.LaundryAgent();
				return objLaundryAgent.SelectLaundryAgent().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetLaundryAgentByID(int intAgentID)
		{
			try
			{
				DataKernal.LaundryAgent objLaundryAgent = new DataKernal.LaundryAgent();
				return objLaundryAgent.SelectLaundryAgent(intAgentID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdateLaundryAgent(BusinessEntities.LaundryAgent objLaundryAgent)
		{
			try
			{
				DataKernal.LaundryAgent objDLaundryAgent = new DataKernal.LaundryAgent();
				return objDLaundryAgent.InsertUpdateLaundryAgent(objLaundryAgent.AgentID,objLaundryAgent.AgentName,objLaundryAgent.AgentEmail,objLaundryAgent.AgentPassword,objLaundryAgent.AgentPhoneNO,objLaundryAgent.AgentImage,objLaundryAgent.AgentAddress,objLaundryAgent.AdminID,objLaundryAgent.DateCreated,objLaundryAgent.IsEnabled,objLaundryAgent.Remarks).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeleteLaundryAgent(int intAgentID)
		{
			try
			{
				DataKernal.LaundryAgent objLaundryAgent = new DataKernal.LaundryAgent();
				return objLaundryAgent.DeleteLaundryAgent(intAgentID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeleteLaundryAgent()
		{
			try
			{
				DataKernal.LaundryAgent objLaundryAgent = new DataKernal.LaundryAgent();
				return objLaundryAgent.DeleteLaundryAgent().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncateLaundryAgent()
		{
			try
			{
				DataKernal.LaundryAgent objLaundryAgent = new DataKernal.LaundryAgent();
				return objLaundryAgent.LaundryAgentTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

        public static int Login(string UserEmail, string UserPassword)
        {
            DataTable dtAgent = new DataTable();
            DataKernal.LaundryAgent da = new DataKernal.LaundryAgent();
            dtAgent = da.SelectLaundryAgent().Tables[0];
            foreach (DataRow dr in dtAgent.Rows)
            {
                if (dr["AgentEmail"].ToString() == UserEmail)
                {
                    if (dr["AgentPassword"].ToString() == UserPassword)
                        return int.Parse(dr["AgentID"].ToString());
                }
            }

            return 0;
        }
    }
}