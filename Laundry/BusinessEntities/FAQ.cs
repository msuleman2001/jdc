using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
	public class FAQ
	{
		//Private Variables////////////////////////////////////////////////////////////////////////
		Int64 intQuestionID;
string strQuestionDetail;
string strAnswerDetail;
string strFAQsCategoryID;
Int64 intAdminID;
DateTime datDateCreated;
string strQuestionRemarks;
bool blnIsEnabled;

		///////////////////////////////////////////////////////////////////////////////////////////
		
		//Public Properties////////////////////////////////////////////////////////////////////////
		
public Int64 QuestionID
{
	get
	{
		return intQuestionID;
	}
	set
	{
		intQuestionID = value;
	}
}
public string QuestionDetail
{
	get
	{
		return strQuestionDetail;
	}
	set
	{
		strQuestionDetail = value;
	}
}
public string AnswerDetail
{
	get
	{
		return strAnswerDetail;
	}
	set
	{
		strAnswerDetail = value;
	}
}
public string FAQsCategoryID
{
	get
	{
		return strFAQsCategoryID;
	}
	set
	{
		strFAQsCategoryID = value;
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
public string QuestionRemarks
{
	get
	{
		return strQuestionRemarks;
	}
	set
	{
		strQuestionRemarks = value;
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