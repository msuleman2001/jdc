using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class LaundryAdmin
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intAdminID;
string strAdminName;
string strAdminEmail;
string strAdminPassword;
string strPhoneNo;
string strAddress;
string strAdminImage;
bool blnAdminType;
DateTime datAdmindateJoind;
bool blnIsEnabled;
string strAdminRemarks;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
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
public string AdminName
{
	get
	{
		return strAdminName;
	}
	set
	{
		strAdminName = value;
	}
}
public string AdminEmail
{
	get
	{
		return strAdminEmail;
	}
	set
	{
		strAdminEmail = value;
	}
}
public string AdminPassword
{
	get
	{
		return strAdminPassword;
	}
	set
	{
		strAdminPassword = value;
	}
}
public string PhoneNo
{
	get
	{
		return strPhoneNo;
	}
	set
	{
		strPhoneNo = value;
	}
}
public string Address
{
	get
	{
		return strAddress;
	}
	set
	{
		strAddress = value;
	}
}
public string AdminImage
{
	get
	{
		return strAdminImage;
	}
	set
	{
		strAdminImage = value;
	}
}
public bool AdminType
{
	get
	{
		return blnAdminType;
	}
	set
	{
		blnAdminType = value;
	}
}
public DateTime AdmindateJoind
{
	get
	{
		return datAdmindateJoind;
	}
	set
	{
		datAdmindateJoind = value;
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
public string AdminRemarks
{
	get
	{
		return strAdminRemarks;
	}
	set
	{
		strAdminRemarks = value;
	}
}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}