using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Orders
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intOrderID;
Int64 intClientID;
Int64 intAdminID;
Int64 intAgentID;
DateTime datDateCreation;
DateTime datRequestPickupDate;
string strPickupTimeSlot;
DateTime datRequestDropOffDate;
string strDropOffTimeSlot;
DateTime datPickupDateTime;
DateTime datDropOfDateTime;
string strStatus;
bool blnIsEbabled;
string strRemarks;
        string strOrderNumber;


        ///////////////////////////////////////////////////////////////////////////////////////////

        //Public Properties////////////////////////////////////////////////////////////////////////

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
public DateTime DateCreation
{
	get
	{
		return datDateCreation;
	}
	set
	{
		datDateCreation = value;
	}
}
public DateTime RequestPickupDate
{
	get
	{
		return datRequestPickupDate;
	}
	set
	{
		datRequestPickupDate = value;
	}
}
public string PickupTimeSlot
{
	get
	{
		return strPickupTimeSlot;
	}
	set
	{
		strPickupTimeSlot = value;
	}
}
public DateTime RequestDropOffDate
{
	get
	{
		return datRequestDropOffDate;
	}
	set
	{
		datRequestDropOffDate = value;
	}
}
public string DropOffTimeSlot
{
	get
	{
		return strDropOffTimeSlot;
	}
	set
	{
		strDropOffTimeSlot = value;
	}
}
public DateTime PickupDateTime
{
	get
	{
		return datPickupDateTime;
	}
	set
	{
		datPickupDateTime = value;
	}
}
public DateTime DropOfDateTime
{
	get
	{
		return datDropOfDateTime;
	}
	set
	{
		datDropOfDateTime = value;
	}
}
public string Status
{
	get
	{
		return strStatus;
	}
	set
	{
		strStatus = value;
	}
}
public bool IsEbabled
{
	get
	{
		return blnIsEbabled;
	}
	set
	{
		blnIsEbabled = value;
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
        public string OrderNumber
        {
            get
            {
                return strOrderNumber;
            }
            set
            {
                strOrderNumber = value;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
    }
   
}