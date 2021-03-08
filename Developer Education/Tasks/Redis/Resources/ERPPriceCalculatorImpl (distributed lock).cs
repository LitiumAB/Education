using System;
using System.Collections.Generic;
using System.Threading;
using Litium.Caching;
using Litium.Products;
using Litium.Products.PriceCalculator;
using Litium.Runtime.DistributedLock;

namespace Litium.Accelerator.Utilities
{
    public class ERPPriceCalculatorImpl : IPriceCalculator
    {
        private readonly DistributedMemoryCacheService _distributedMemoryCacheService;
        private readonly DistributedLockService _distributedLockService;

        public ERPPriceCalculatorImpl(DistributedMemoryCacheService distributedMemoryCacheService, DistributedLockService distributedLockService)
        {
            _distributedMemoryCacheService = distributedMemoryCacheService;
            _distributedLockService = distributedLockService;
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
            var cacheKey = $"{nameof(ERPPriceCalculatorImpl)}:{variantSystemId}";
            if (_distributedMemoryCacheService.TryGet<PriceCalculatorResult>(cacheKey, out var price))
                return price;

            using (_distributedLockService.AcquireLock(cacheKey, TimeSpan.FromSeconds(10)))
            {
                // Try getting value from cache again since it was likely added while we were waiting for the lock
                if (_distributedMemoryCacheService.TryGet<PriceCalculatorResult>(cacheKey, out price))
                    return price;

                // Test the effect of the cache by faking a slow ERP API taking one second to get a variants price:
                Thread.Sleep(800);

                price = new PriceCalculatorResult
                {
                    ListPrice = 100,
                    VatPercentage = (decimal)0.25
                };

                _distributedMemoryCacheService.Set(cacheKey, price);
            }

            return price;
        }
    }
}