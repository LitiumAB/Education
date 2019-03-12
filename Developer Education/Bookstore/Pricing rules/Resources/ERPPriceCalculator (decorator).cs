using System;
using System.Collections.Generic;
using Litium.Foundation.Security;
using Litium.Products;
using Litium.Products.PriceCalculator;
using Litium.Runtime.DependencyInjection;

namespace Litium.Accelerator.Utilities
{
	[ServiceDecorator(typeof(IPriceCalculator))]
	public class ERPPriceCalculator : IPriceCalculator
	{
		private readonly IPriceCalculator _parent;

		public ERPPriceCalculator(IPriceCalculator parent)
		{
			_parent = parent;
		}

		public IDictionary<Guid, PriceCalculatorResult> GetListPrices(PriceCalculatorArgs calculatorArgs, params PriceCalculatorItemArgs[] itemArgs)
		{
			if (SecurityToken.CurrentSecurityToken.IsAnonymousUser)
				return _parent.GetListPrices(calculatorArgs, itemArgs);

			var result = new Dictionary<Guid, PriceCalculatorResult>();

			foreach (var variantItem in itemArgs)
				result.Add(variantItem.VariantSystemId, new PriceCalculatorResult
				{
					ListPrice = 100,
					VatPercentage = (decimal) 0.25
				});

			return result;
		}

		public ICollection<PriceList> GetPriceLists(PriceCalculatorArgs calculatorArgs)
		{
			return _parent.GetPriceLists(calculatorArgs);
		}
	}
}