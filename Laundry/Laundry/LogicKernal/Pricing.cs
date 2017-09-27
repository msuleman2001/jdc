using System.Data;

namespace LogicKernal
{
	public class Pricing
	{
		public static DataTable GetAllPricing()
		{
			try
			{
				DataKernal.Pricing objPricing =  new DataKernal.Pricing();
				return objPricing.SelectPricing().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable GetPricingByID(int intAddressID)
		{
			try
			{
				DataKernal.Pricing objPricing = new DataKernal.Pricing();
				return objPricing.SelectPricing(intAddressID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable InsertUpdatePricing(BusinessEntities.Pricing objPricing)
		{
			try
			{
				DataKernal.Pricing objDPricing = new DataKernal.Pricing();
				return objDPricing.InsertUpdatePricing(objPricing.PricingID,objPricing.PriceingTitle,objPricing.PricingValue,objPricing.PricingCategoryID,objPricing.Remarks,objPricing.DateCreated,objPricing.IsEnbled).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}

		public static DataTable DeletePricing(int intAddressID)
		{
			try
			{
				DataKernal.Pricing objPricing = new DataKernal.Pricing();
				return objPricing.DeletePricing(intAddressID).Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
		public static DataTable DeletePricing()
		{
			try
			{
				DataKernal.Pricing objPricing = new DataKernal.Pricing();
				return objPricing.DeletePricing().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
    
		public static DataTable TruncatePricing()
		{
			try
			{
				DataKernal.Pricing objPricing = new DataKernal.Pricing();
				return objPricing.PricingTruncate().Tables[0];
			}
			catch (System.Exception ex)
			{
				return null;
			}
		}
	}
}