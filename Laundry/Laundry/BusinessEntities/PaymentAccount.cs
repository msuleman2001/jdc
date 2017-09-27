using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class PaymentAccount
    {
        //Private Variables////////////////////////////////////////////////////////////////////////
        Int64 intPaymentAccID;
        string strBankName;
        string strCreditCardNo;
        DateTime datDateExp;
        Int64 intClientID;
        bool blnIsDefault;
        string strAccountRemarks;
        DateTime datDateCreated;
        bool blnIsEnabled;
        Int64 intCVV;
        string strNameOnCard;

        ///////////////////////////////////////////////////////////////////////////////////////////

        //Public Properties////////////////////////////////////////////////////////////////////////

        public Int64 PaymentAccID
        {
            get
            {
                return intPaymentAccID;
            }
            set
            {
                intPaymentAccID = value;
            }
        }
        public string BankName
        {
            get
            {
                return strBankName;
            }
            set
            {
                strBankName = value;
            }
        }
        public string CreditCardNo
        {
            get
            {
                return strCreditCardNo;
            }
            set
            {
                strCreditCardNo = value;
            }
        }
        public DateTime DateExp
        {
            get
            {
                return datDateExp;
            }
            set
            {
                datDateExp = value;
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
        public bool IsDefault
        {
            get
            {
                return blnIsDefault;
            }
            set
            {
                blnIsDefault = value;
            }
        }
        public string AccountRemarks
        {
            get
            {
                return strAccountRemarks;
            }
            set
            {
                strAccountRemarks = value;
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
        public Int64 CVV
        {
            get
            {
                return intCVV;
            }
            set
            {
                intCVV = value;
            }
        }
        public string NameOnCard
        {
            get
            {
                return strNameOnCard;
            }
            set
            {
                strNameOnCard = value;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}