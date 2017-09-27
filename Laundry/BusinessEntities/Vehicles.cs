using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Vehicles
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intVehicleID;
string strVehicleMake;
string strVehicleColor;
string strVehicleRegNO;
Int64 intAgentID;
Int64 intDriverID;
string strVehicalImage;
Int64 intAdminID;
DateTime datDateCreated;
bool blnIsEnabled;
string strRemarks;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 VehicleID
{
	get
	{
		return intVehicleID;
	}
	set
	{
		intVehicleID = value;
	}
}
public string VehicleMake
{
	get
	{
		return strVehicleMake;
	}
	set
	{
		strVehicleMake = value;
	}
}
public string VehicleColor
{
	get
	{
		return strVehicleColor;
	}
	set
	{
		strVehicleColor = value;
	}
}
public string VehicleRegNO
{
	get
	{
		return strVehicleRegNO;
	}
	set
	{
		strVehicleRegNO = value;
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
public Int64 DriverID
{
	get
	{
		return intDriverID;
	}
	set
	{
		intDriverID = value;
	}
}
public string VehicalImage
{
	get
	{
		return strVehicalImage;
	}
	set
	{
		strVehicalImage = value;
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