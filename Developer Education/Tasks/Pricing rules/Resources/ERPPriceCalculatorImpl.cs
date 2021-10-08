using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Products;
using Litium.Products.PriceCalculator;

namespace Litium.Accelerator.Utilities
{
    public class ERPPriceCalculatorImpl : IPriceCalculator
    {
        public IDictionary<Guid, PriceCalculatorResult> GetListPrices(PriceCalculatorArgs calculatorArgs, params PriceCalculatorItemArgs[] itemArgs)
        {
            return itemArgs
                .ToDictionary(
                    variantItem => variantItem.VariantSystemId,
                    variantItem => GetPriceFromErp(variantItem.VariantSystemId)
                );
        }

        public ICollection<ProductPriceList> GetPriceLists(PriceCalculatorArgs calculatorArgs)
        {
            return new List<ProductPriceList>();
        }

        private PriceCalculatorResult GetPriceFromErp(Guid variantSystemId)
        {
            return new PriceCalculatorResult
            {
                PriceExcludingVat = 100,
                PriceIncludesVat = false,
                VatRate = (decimal)0.25
            };
        }
    }
}
