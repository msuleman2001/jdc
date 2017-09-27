using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class ValuePreferance
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intValueID;
string strValueName;
Int64 intPreferanceID;
string strRemarks;
DateTime datDateCreated;
bool blnIsEnabled;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
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
public string ValueName
{
	get
	{
		return strValueName;
	}
	set
	{
		strValueName = value;
	}
}
public Int64 PreferanceID
{
	get
	{
		return intPreferanceID;
	}
	set
	{
		intPreferanceID = value;
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