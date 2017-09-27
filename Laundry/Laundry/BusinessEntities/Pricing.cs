using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class Pricing
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intPricingID;
string strPriceingTitle;
string strPricingValue;
Int64 intPricingCategoryID;
string strRemarks;
DateTime datDateCreated;
bool blnIsEnbled;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 PricingID
{
	get
	{
		return intPricingID;
	}
	set
	{
		intPricingID = value;
	}
}
public string PriceingTitle
{
	get
	{
		return strPriceingTitle;
	}
	set
	{
		strPriceingTitle = value;
	}
}
public string PricingValue
{
	get
	{
		return strPricingValue;
	}
	set
	{
		strPricingValue = value;
	}
}
public Int64 PricingCategoryID
{
	get
	{
		return intPricingCategoryID;
	}
	set
	{
		intPricingCategoryID = value;
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
public bool IsEnbled
{
	get
	{
		return blnIsEnbled;
	}
	set
	{
		blnIsEnbled = value;
	}
}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}