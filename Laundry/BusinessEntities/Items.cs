using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Items
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intItemID;
string strItemName;
Int64 intCategoryID;
string strItemImage;
string strUnitPrice;
Int64 intAdminID;
DateTime datDateCreated;
bool blnIsEnabled;
string strRemarks;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 ItemID
{
	get
	{
		return intItemID;
	}
	set
	{
		intItemID = value;
	}
}
public string ItemName
{
	get
	{
		return strItemName;
	}
	set
	{
		strItemName = value;
	}
}
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
public string ItemImage
{
	get
	{
		return strItemImage;
	}
	set
	{
		strItemImage = value;
	}
}
public string UnitPrice
{
	get
	{
		return strUnitPrice;
	}
	set
	{
		strUnitPrice = value;
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