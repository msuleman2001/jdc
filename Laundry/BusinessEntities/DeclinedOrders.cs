using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class DeclinedOrders
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intOrderDeclinedID;
Int64 intOrderID;
Int64 intAgentID;
Int64 intAdminID;
DateTime datDateCreated;
bool blnIsEnabled;
string strDeclinedRemarks;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 OrderDeclinedID
{
	get
	{
		return intOrderDeclinedID;
	}
	set
	{
		intOrderDeclinedID = value;
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
public string DeclinedRemarks
{
	get
	{
		return strDeclinedRemarks;
	}
	set
	{
		strDeclinedRemarks = value;
	}
}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}