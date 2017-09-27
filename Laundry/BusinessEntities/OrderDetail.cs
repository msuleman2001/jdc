using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class OrderDetail
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intOrderDetailID;
Int64 intOrderID;
Int64 intItemID;
Int64 intAgentID;
Int64 intQuantity;
string strUnitPrice;
DateTime datDateTimeCreated;
bool blnIsEnabled;
string strRemarks;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 OrderDetailID
{
	get
	{
		return intOrderDetailID;
	}
	set
	{
		intOrderDetailID = value;
	}
}
public Int64 OrderID
{
	get
	{
		return intOrderID;
	}
	set
	{
		intOrderID = value;
	}
}
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
public Int64 Quantity
{
	get
	{
		return intQuantity;
	}
	set
	{
		intQuantity = value;
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
public DateTime DateTimeCreated
{
	get
	{
		return datDateTimeCreated;
	}
	set
	{
		datDateTimeCreated = value;
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