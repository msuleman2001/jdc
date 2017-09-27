using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class ClientVerification
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intVerifiedID;
string strPhoneNO;
Int64 intVerificationCode;
bool blnIsEnabled;
DateTime datVerificationDateTime;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 VerifiedID
{
	get
	{
		return intVerifiedID;
	}
	set
	{
		intVerifiedID = value;
	}
}
public string PhoneNO
{
	get
	{
		return strPhoneNO;
	}
	set
	{
		strPhoneNO = value;
	}
}
public Int64 VerificationCode
{
	get
	{
		return intVerificationCode;
	}
	set
	{
		intVerificationCode = value;
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
public DateTime VerificationDateTime
{
	get
	{
		return datVerificationDateTime;
	}
	set
	{
		datVerificationDateTime = value;
	}
}
		///////////////////////////////////////////////////////////////////////////////////////////
	}
}