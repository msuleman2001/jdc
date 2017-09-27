using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Preferances
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intPreferanceID;
string strPreferanceName;
string strRemarks;
DateTime datDateCreated;
bool blnIsEnabled;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
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
public string PreferanceName
{
	get
	{
		return strPreferanceName;
	}
	set
	{
		strPreferanceName = value;
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