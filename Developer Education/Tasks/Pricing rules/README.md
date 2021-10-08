# Replace Litium listprice with custom price

> To do this task you first need to complete the task [Installation](../Installation)

Our client has a complex price model, so you need to replace Litium's price lists with a solution that fetches prices from the custumer's ERP.

1. Create the class `Litium.Accelerator.Utilities.ERPPriceCalculatorImpl` that implements
`Litium.Products.PriceCalculator.IPriceCalculator`
    1. The interface-method `GetPriceLists()` can be implemented so that it only returns `new List<ProductPriceList>();`
1. Add logic to method `GetListPrices()`
    1. Create a `new Dictionary<Guid, PriceCalculatorResult>()` that the method should return
    1. For each item in `itemArgs` add an item to the returned dictionary with price set to 100
1. A finished example is avaliable in the [_Resources_-folder](Resources/ERPPriceCalculatorImpl.cs)

### Try it out

1. Browse products on your public site, all of them should now cost 100 

## Optional extra task

Only logged in B2B-customers should get their prices from ERP, add a check so Litium's standard price logic is still used for all anonymous users.

1. Convert your `ERPPriceCalculatorImpl` into a [decorator](https://docs.litium.com/documentation/architecture/dependency-injection/service-decorator).
1. Inject `IHttpContextAccessor` and use `_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated` to check if current user is logged in, if user is not logged in return Litium list price, otherwise your custom price.
1. A finished example is avaliable in the [_Resources_-folder](Resources/ERPPriceCalculatorDecorator.cs)
