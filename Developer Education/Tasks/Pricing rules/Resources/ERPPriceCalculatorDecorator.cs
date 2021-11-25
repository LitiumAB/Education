using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Products;
using Litium.Products.PriceCalculator;
using Litium.Runtime.DependencyInjection;
using Litium.Security;

namespace Litium.Accelerator.Utilities
{
    [ServiceDecorator(typeof(IPriceCalculator))]
    public class ErpPriceCalculatorDecorator : IPriceCalculator
    {
        private readonly IPriceCalculator _parent;
        private readonly SecurityContextService _securityContextService;

        public ErpPriceCalculatorDecorator(IPriceCalculator parent, SecurityContextService securityContextService)
        {
            _parent = parent;
            _securityContextService = securityContextService;
        }

        public IDictionary<Guid, PriceCalculatorResult> GetListPrices(PriceCalculatorArgs calculatorArgs, params PriceCalculatorItemArgs[] itemArgs)
        {
            var isAuthenticated = _securityContextService.GetIdentityUserSystemId().HasValue;
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
            return new PriceCalculatorResult
            {
                PriceExcludingVat = 100,
                PriceIncludesVat = false,
                VatRate = (decimal)0.25
            };
        }
    }
}