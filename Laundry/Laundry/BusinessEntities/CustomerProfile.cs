using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class CustomerProfile
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intClientID;
string strCustomerName;
string strCustomerAddress;
string strCustomerPhoneNo;
string strCustomerEmail;
string strCustomerPassword;
DateTime datDateJoind;
string strCustomerRemarks;
bool blnIsEnabled;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 ClientID
{
	get
	{
		return intClientID;
	}
	set
	{
		intClientID = value;
	}
}
public string CustomerName
{
	get
	{
		return strCustomerName;
	}
	set
	{
		strCustomerName = value;
	}
}
public string CustomerAddress
{
	get
	{
		return strCustomerAddress;
	}
	set
	{
		strCustomerAddress = value;
	}
}
public string CustomerPhoneNo
{
	get
	{
		return strCustomerPhoneNo;
	}
	set
	{
		strCustomerPhoneNo = value;
	}
}
public string CustomerEmail
{
	get
	{
		return strCustomerEmail;
	}
	set
	{
		strCustomerEmail = value;
	}
}
public string CustomerPassword
{
	get
	{
		return strCustomerPassword;
	}
	set
	{
		strCustomerPassword = value;
	}
}
public DateTime DateJoind
{
	get
	{
		return datDateJoind;
	}
	set
	{
		datDateJoind = value;
	}
}
public string CustomerRemarks
{
	get
	{
		return strCustomerRemarks;
	}
	set
	{
		strCustomerRemarks = value;
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
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}