using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class LaundryDrivers
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intDriverID;
string strDriverName;
        string strDriverEmail;
        string strDriverPassword;
        string strDriverPhoneNO;
        string strDriverImage;
        string strDriverlicenceNO;
DateTime datLicenceIssueDate;
DateTime datLicenceExpDate;
        string strDriverAddress;
Int64 intAgentID;
Int64 intAdminID;
DateTime datDateCreated;
        string strRemarks;
bool blnIsEnable;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 DriverID
{
	get
	{
		return intDriverID;
	}
	set
	{
		intDriverID = value;
	}
}
public string DriverName
{
	get
	{
		return strDriverName;
	}
	set
	{
		strDriverName = value;
	}
}
public string DriverEmail
{
	get
	{
		return strDriverEmail;
	}
	set
	{
		strDriverEmail = value;
	}
}
public string DriverPassword
{
	get
	{
		return strDriverPassword;
	}
	set
	{
		strDriverPassword = value;
	}
}
public string DriverPhoneNO
{
	get
	{
		return strDriverPhoneNO;
	}
	set
	{
		strDriverPhoneNO = value;
	}
}
public string DriverImage
{
	get
	{
		return strDriverImage;
	}
	set
	{
		strDriverImage = value;
	}
}
public string DriverlicenceNO
{
	get
	{
		return strDriverlicenceNO;
	}
	set
	{
		strDriverlicenceNO = value;
	}
}
public DateTime LicenceIssueDate
{
	get
	{
		return datLicenceIssueDate;
	}
	set
	{
		datLicenceIssueDate = value;
	}
}
public DateTime LicenceExpDate
{
	get
	{
		return datLicenceExpDate;
	}
	set
	{
		datLicenceExpDate = value;
	}
}
public string DriverAddress
{
	get
	{
		return strDriverAddress;
	}
	set
	{
		strDriverAddress = value;
	}
}
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
public bool IsEnable
{
	get
	{
		return blnIsEnable;
	}
	set
	{
		blnIsEnable = value;
	}
}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}