using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class ItemCategory
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intCategoryID;
string strCategoryName;
string strCategoryImage;
Int64 intParentCategoryID;
Int64 intAdminID;
DateTime datDateCreated;
bool blnIsEnabled;
string strRemarks;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 CategoryID
{
	get
	{
		return intCategoryID;
	}
	set
	{
		intCategoryID = value;
	}
}
public string CategoryName
{
	get
	{
		return strCategoryName;
	}
	set
	{
		strCategoryName = value;
	}
}
public string CategoryImage
{
	get
	{
		return strCategoryImage;
	}
	set
	{
		strCategoryImage = value;
	}
}
public Int64 ParentCategoryID
{
	get
	{
		return intParentCategoryID;
	}
	set
	{
		intParentCategoryID = value;
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