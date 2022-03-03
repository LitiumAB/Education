# Replace Litium listprice with custom price

> To do this task you first need to complete the task [Installation](../Installation)

Your client has a complex price model, so you need to replace Litium's price lists with a solution that fetches prices from the custumer's ERP.

If needed you can find a finished example in the [_Resources_-folder](Resources/ErpPriceCalculatorDecorator.cs)

1. Create the class `Litium.Accelerator.Utilities.ErpPriceCalculatorImpl` that implements
`Litium.Products.PriceCalculator.IPriceCalculator`
    1. The interface-method `GetPriceLists()` can be implemented so that it returns `new List<ProductPriceList>();`
1. Add the following logic to the `GetListPrices()`-method:
    1. Create a `new Dictionary<Guid, PriceCalculatorResult>()` that the method should return
    1. For each item in `itemArgs` add an item to the dictionary with price set to 100
1. Browse products on your public site, all of them should now cost 100.

## Convert into decorator

Only logged in B2B-customers should get their prices from ERP, add a check so Litium's standard price logic is still used for all anonymous users.

1. Rename `ErpPriceCalculatorImpl` to `ErpPriceCalculatorDecorator` and use the [information on docs](https://docs.litium.com/documentation/architecture/dependency-injection/service-decorator) to convert it into a decorator.
1. Inject `SecurityContextService` and use the code below to check if current user is logged in, if current user is _not_ logged in return Litium list price, otherwise return your custom price.

    ```C#
    var userId = _securityContextService.GetIdentityUserSystemId();
    var isAuthenticated = userId.HasValue && userId != SecurityContextService.Everyone.SystemId;
    ```
