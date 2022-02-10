﻿using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Accelerator.Utilities;
using Litium.Products.PriceCalculator;
using Litium.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace Litium.Accelerator;

/// <summary>
///     Example XUnit-tests for ERP Price calculator created in the Pricing Rules task
///     https://github.com/LitiumAB/Education/tree/master/Developer%20Education/Tasks/Pricing%20rules
///     Dependencies:
///     https://github.com/Moq/moq4/wiki/Quickstart
///     https://github.com/shouldly/shouldly
/// </summary>
public class ErpPriceCalculatorDecoratorTests : TestBase
{
    private readonly ApplicationFixture _app;
    private readonly SecurityContextService _securityContextService;

    public ErpPriceCalculatorDecoratorTests(ApplicationFixture app)
    {
        _app = app;
        _securityContextService = _app.ServiceProvider.GetService<SecurityContextService>();
    }

    private ErpPriceCalculatorDecorator GetCalculator(Guid variantId)
    {
        var parent = new Mock<IPriceCalculator>();
        parent.Setup(p => p.GetListPrices(It.IsAny<PriceCalculatorArgs>(), It.IsAny<PriceCalculatorItemArgs>()))
            .Returns(new Dictionary<Guid, PriceCalculatorResult>
            {
                {
                    variantId,
                    new PriceCalculatorResult { ListPrice = 999, ListPriceWithVat = 999, VatPercentage = 0 }
                }
            });
        var logger = new Mock<ILogger<ErpPriceCalculatorDecorator>>();
        return new ErpPriceCalculatorDecorator(parent.Object, _securityContextService, logger.Object);
    }

    [Fact]
    public void Returns_price_from_erp_when_logged_in()
    {
        var variantId = new Guid();
        var calculator = GetCalculator(variantId);

        IDictionary<Guid, PriceCalculatorResult> prices;
        using (_securityContextService.ActAsSystem())
        {
            prices = calculator.GetListPrices(null, new PriceCalculatorItemArgs
            {
                Quantity = 1,
                VariantSystemId = variantId
            });
        }

        prices.ShouldNotBeNull();
        prices.Count.ShouldBe(1);
        prices.First().Key.ShouldBe(variantId);
        prices.First().Value.ListPrice.ShouldBe(100);
    }

    [Fact]
    public void Returns_standard_price_for_anonymous()
    {
        var variantId = new Guid();
        var calculator = GetCalculator(variantId);

        IDictionary<Guid, PriceCalculatorResult> prices;
        using (_securityContextService.ActAsEveryone())
        {
            prices = calculator.GetListPrices(null, new PriceCalculatorItemArgs
            {
                Quantity = 1,
                VariantSystemId = variantId
            });
        }

        prices.ShouldNotBeNull();
        prices.Count.ShouldBe(1);
        prices.First().Key.ShouldBe(variantId);
        prices.First().Value.ListPrice.ShouldBe(999);
    }
}