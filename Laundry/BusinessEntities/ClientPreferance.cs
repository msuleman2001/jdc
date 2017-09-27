using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class ClientPreferance
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intClientPreferanceID;
Int64 intClientID;
Int64 intValueID;
string strRemarks;
DateTime datDateCreated;
bool blnIsEnabled;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 ClientPreferanceID
{
	get
	{
		return intClientPreferanceID;
	}
	set
	{
		intClientPreferanceID = value;
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
public Int64 ValueID
{
	get
	{
		return intValueID;
	}
	set
	{
		intValueID = value;
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
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}