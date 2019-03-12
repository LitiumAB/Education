using Litium.Foundation.Modules.ECommerce.Carriers;
using Litium.Foundation.Modules.ECommerce.Plugins.Checkout;
using Litium.Foundation.Modules.ECommerce.Plugins.Orders;
using Litium.Studio.Extenssions;

namespace Litium.Accelerator.ValidationRules
{
	public class OrderGrandTotalOverLimitValidator : IPreOrderValidationRule
	{
		public void Validate(OrderCarrier orderCarrier, CheckoutFlowInfo checkoutFlowInfo)
		{
			if (orderCarrier.GrandTotal < 300)
				throw new PreOrderValidationException("OrderGrandTotalOverLimitValidatorErrorMessage".AsWebSiteString());
		}
	}
}