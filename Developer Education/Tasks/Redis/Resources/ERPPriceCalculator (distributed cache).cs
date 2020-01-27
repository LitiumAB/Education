using System;
using System.Collections.Generic;
using System.Threading;
using Litium.Caching;
using Litium.Products;
using Litium.Products.PriceCalculator;

namespace Litium.Accelerator.Utilities
{
    public class ERPPriceCalculator : IPriceCalculator
    {
        private readonly DistributedMemoryCacheService _distributedMemoryCacheService;

        public ERPPriceCalculator(DistributedMemoryCacheService distributedMemoryCacheService)
        {
            _distributedMemoryCacheService = distributedMemoryCacheService;
        }

        public IDictionary<Guid, PriceCalculatorResult> GetListPrices(PriceCalculatorArgs calculatorArgs, params PriceCalculatorItemArgs[] itemArgs)
        {
            var result = new Dictionary<Guid, PriceCalculatorResult>();

            foreach (var variantItem in itemArgs)
                result.Add(variantItem.VariantSystemId, GetPriceFromErp(variantItem.VariantSystemId));

            return result;
        }

        public ICollection<PriceList> GetPriceLists(PriceCalculatorArgs calculatorArgs)
        {
            return new List<PriceList>();
        }

        private PriceCalculatorResult GetPriceFromErp(Guid variantSystemId)
        {
            var cacheKey = $"{nameof(ERPPriceCalculator)}:{variantSystemId}";
            if (_distributedMemoryCacheService.TryGet<PriceCalculatorResult>(cacheKey, out var price))
                return price;

            // Test the effect of the cache by faking a slow ERP API taking one second to get a variants price:
            Thread.Sleep(800);

            price = new PriceCalculatorResult
            {
                ListPrice = 100,
                VatPercentage = (decimal)0.25
            };

            _distributedMemoryCacheService.Set(cacheKey, price);

            return price;
        }
    }
}