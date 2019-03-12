using System;
using System.Collections.Generic;
using Litium.Products;
using Litium.Products.PriceCalculator;

namespace Litium.Accelerator.Utilities
{
	public class ERPPriceCalculator : IPriceCalculator
	{
		public IDictionary<Guid, PriceCalculatorResult> GetListPrices(PriceCalculatorArgs calculatorArgs, params PriceCalculatorItemArgs[] itemArgs)
		{
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
			return new List<PriceList>();
		}
	}
}