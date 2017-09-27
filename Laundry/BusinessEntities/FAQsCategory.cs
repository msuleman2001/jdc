using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class FAQsCategory
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intFAQsCategoryID;
string strFAQsCategoryName;
Int64 intAdminID;
bool blnIsEnabled;
DateTime datDateCreated;
string strFAQRemarks;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 FAQsCategoryID
{
	get
	{
		return intFAQsCategoryID;
	}
	set
	{
		intFAQsCategoryID = value;
	}
}
public string FAQsCategoryName
{
	get
	{
		return strFAQsCategoryName;
	}
	set
	{
		strFAQsCategoryName = value;
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
public string FAQRemarks
{
	get
	{
		return strFAQRemarks;
	}
	set
	{
		strFAQRemarks = value;
	}
}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}