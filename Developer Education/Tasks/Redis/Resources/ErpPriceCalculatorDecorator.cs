using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Litium.Caching;
using Litium.Products;
using Litium.Products.PriceCalculator;
using Litium.Runtime.DependencyInjection;
using Litium.Runtime.DistributedLock;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Litium.Accelerator.Utilities
{
    [ServiceDecorator(typeof(IPriceCalculator))]
    public class ErpPriceCalculatorDecorator : IPriceCalculator
    {
        private readonly DistributedLockService _distributedLockService;
        private readonly ILogger<ErpPriceCalculatorDecorator> _logger;
        private readonly DistributedMemoryCacheService _distributedMemoryCacheService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPriceCalculator _parent;

        public ErpPriceCalculatorDecorator(IPriceCalculator parent, IHttpContextAccessor httpContextAccessor,
            DistributedMemoryCacheService distributedMemoryCacheService, DistributedLockService distributedLockService,
            ILogger<ErpPriceCalculatorDecorator> logger)
        {
            _parent = parent;
            _httpContextAccessor = httpContextAccessor;
            _distributedMemoryCacheService = distributedMemoryCacheService;
            _distributedLockService = distributedLockService;
            _logger = logger;
        }

        public IDictionary<Guid, PriceCalculatorResult> GetListPrices(PriceCalculatorArgs calculatorArgs, params PriceCalculatorItemArgs[] itemArgs)
        {
            var isAuthenticated = _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
            if (!isAuthenticated)
                return _parent.GetListPrices(calculatorArgs, itemArgs);

            return itemArgs
                .ToDictionary(
                    variantItem => variantItem.VariantSystemId,
                    variantItem => GetPriceFromErp(variantItem.VariantSystemId)
                );
        }

        public ICollection<ProductPriceList> GetPriceLists(PriceCalculatorArgs calculatorArgs)
        {
            return _parent.GetPriceLists(calculatorArgs);
        }

        private PriceCalculatorResult GetPriceFromErp(Guid variantSystemId)
        {
            var cacheKey = $"{nameof(ErpPriceCalculatorDecorator)}:{variantSystemId}";
            if (_distributedMemoryCacheService.TryGet<PriceCalculatorResult>(cacheKey, out var price))
            {
                _logger.LogDebug("Getting price from CACHE for variant {VariantSystemId}", variantSystemId);
                return price;
            }
            
            using (_distributedLockService.AcquireLock(cacheKey, TimeSpan.FromSeconds(10)))
            {
                // Try getting value from cache again since it may have been added
                // from another thread/app while you were waiting for the lock
                if (_distributedMemoryCacheService.TryGet(cacheKey, out price))
                {
                    _logger.LogDebug("Getting price from CACHE for variant {VariantSystemId}", variantSystemId);
                    return price;
                }
                
                _logger.LogDebug("Getting price from ERP for variant {VariantSystemId}", variantSystemId);

                // Test the effect of the cache by faking a slow API:
                Thread.Sleep(500);

                price = new PriceCalculatorResult
                {
                    PriceExcludingVat = 100,
                    PriceIncludesVat = false,
                    VatRate = (decimal)0.25
                };

                _distributedMemoryCacheService.Set(cacheKey, price);
            }

            return price;
        }
    }
}