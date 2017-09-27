using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class LaundryAgent
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intAgentID;
string strAgentName;
string strAgentEmail;
string strAgentPassword;
string strAgentPhoneNO;
string strAgentImage;
string strAgentAddress;
Int64 intAdminID;
DateTime datDateCreated;
bool blnIsEnabled;
string strRemarks;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 AgentID
{
	get
	{
		return intAgentID;
	}
	set
	{
		intAgentID = value;
	}
}
public string AgentName
{
	get
	{
		return strAgentName;
	}
	set
	{
		strAgentName = value;
	}
}
public string AgentEmail
{
	get
	{
		return strAgentEmail;
	}
	set
	{
		strAgentEmail = value;
	}
}
public string AgentPassword
{
	get
	{
		return strAgentPassword;
	}
	set
	{
		strAgentPassword = value;
	}
}
public string AgentPhoneNO
{
	get
	{
		return strAgentPhoneNO;
	}
	set
	{
		strAgentPhoneNO = value;
	}
}
public string AgentImage
{
	get
	{
		return strAgentImage;
	}
	set
	{
		strAgentImage = value;
	}
}
public string AgentAddress
{
	get
	{
		return strAgentAddress;
	}
	set
	{
		strAgentAddress = value;
	}
}
public Int64 AdminID
{
	get
	{
		return intAdminID;
	}
	set
	{
		intAdminID = value;
	}
}
public DateTime DateCreated
{
	get
	{
		return datDateCreated;
	}
	set
	{
		datDateCreated = value;
	}
}
public bool IsEnabled
{
	get
	{
		return blnIsEnabled;
	}
	set
	{
		blnIsEnabled = value;
	}
}
public string Remarks
{
	get
	{
		return strRemarks;
	}
	set
	{
		strRemarks = value;
	}
}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}