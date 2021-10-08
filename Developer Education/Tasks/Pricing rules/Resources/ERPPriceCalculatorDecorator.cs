using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Products;
using Litium.Products.PriceCalculator;
using Litium.Runtime.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Litium.Accelerator.Utilities
{
    [ServiceDecorator(typeof(IPriceCalculator))]
    public class ERPPriceCalculatorDecorator : IPriceCalculator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPriceCalculator _parent;

        public ERPPriceCalculatorDecorator(IPriceCalculator parent, IHttpContextAccessor httpContextAccessor)
        {
            _parent = parent;
            _httpContextAccessor = httpContextAccessor;
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
            return new PriceCalculatorResult
            {
                PriceExcludingVat = 100,
                PriceIncludesVat = false,
                VatRate = (decimal)0.25
            };
        }
    }
}