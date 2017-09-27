using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class CustomerAddress
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intAddressID;
string strCompleteAddress;
string strLatLong;
Int64 intClientID;
bool blnIsDefault;
string strRemarks;
DateTime datDateJoind;
string strIsEnabled;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 AddressID
{
	get
	{
		return intAddressID;
	}
	set
	{
		intAddressID = value;
	}
}
public string CompleteAddress
{
	get
	{
		return strCompleteAddress;
	}
	set
	{
		strCompleteAddress = value;
	}
}
public string LatLong
{
	get
	{
		return strLatLong;
	}
	set
	{
		strLatLong = value;
	}
}
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
public bool IsDefault
{
	get
	{
		return blnIsDefault;
	}
	set
	{
		blnIsDefault = value;
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
public string IsEnabled
{
	get
	{
		return strIsEnabled;
	}
	set
	{
		strIsEnabled = value;
	}
}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}