using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Products;
using Litium.Products.PriceCalculator;
using Litium.Runtime.DependencyInjection;
using Litium.Security;
using Microsoft.Extensions.Logging;

namespace Litium.Accelerator.Utilities;

[ServiceDecorator(typeof(IPriceCalculator))]
public class ErpPriceCalculatorDecorator : IPriceCalculator
{
    private readonly ILogger<ErpPriceCalculatorDecorator> _logger;
    private readonly IPriceCalculator _parent;
    private readonly SecurityContextService _securityContextService;

    public ErpPriceCalculatorDecorator(IPriceCalculator parent, SecurityContextService securityContextService, ILogger<ErpPriceCalculatorDecorator> logger)
    {
        _parent = parent;
        _securityContextService = securityContextService;
        _logger = logger;
    }

    public IDictionary<Guid, PriceCalculatorResult> GetListPrices(PriceCalculatorArgs calculatorArgs, params PriceCalculatorItemArgs[] itemArgs)
    {
        var userId = _securityContextService.GetIdentityUserSystemId();
        var isAuthenticated = userId.HasValue && userId != SecurityContextService.Everyone.SystemId;

        if (!isAuthenticated)
            return _parent.GetListPrices(calculatorArgs, itemArgs);

        _logger.LogDebug("Getting custom price!");

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