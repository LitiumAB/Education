using System;
using System.Collections.Generic;
using Litium.Products;
using Litium.Products.PriceCalculator;

namespace Litium.Accelerator.Utilities
{
	public class ERPPriceCalculatorImpl : IPriceCalculator
	{
		public IDictionary<Guid, PriceCalculatorResult> GetListPrices(PriceCalculatorArgs calculatorArgs, params PriceCalculatorItemArgs[] itemArgs)
		{
			var result = new Dictionary<Guid, PriceCalculatorResult>();

			foreach (var variantItem in itemArgs) {
                		result.Add(variantItem.VariantSystemId, GetPriceFromErp(variantItem.VariantSystemId));
			}

            		return result;
		}

		public ICollection<PriceList> GetPriceLists(PriceCalculatorArgs calculatorArgs)
		{
			return new List<PriceList>();
		}

		private PriceCalculatorResult GetPriceFromErp(Guid variantSystemId)
        	{
            		return new PriceCalculatorResult
            		{
                		ListPrice = 100,
                		VatPercentage = (decimal) 0.25
            		};
        	}
	}
}
