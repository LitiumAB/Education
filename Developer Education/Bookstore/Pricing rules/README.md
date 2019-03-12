# Replace Litium listprice with custom price

Our client has a complex pricemodel so we need to replace Litiums pricelists with a solution that fetch prices from the custumers ERP.

Documentation for the steps below can be found on [docs](https://docs.litium.com/documentation/litium-documentation/sales/architecture-design/ecommercepluginarchitecture/example-customizing-a-plugin)

1. Create the class `Litium.Accelerator.Utilities.ERPPriceCalculator` that implement
`Litium.Products.PriceCalculator.IPriceCalculator`
1. Implement the interface
    1. The method `GetPriceLists()` can be implemented so that it only returns `new List<PriceList>();`
1. Add logic to method `GetListPrices()`
    1. Create a `new Dictionary<Guid, PriceCalculatorResult>()` that the method should return
    1. For each item in `itemArgs` add an item to the returned dictionary
    1. Prices from ERP is probably cached data fetched from a remote API but in this scenario just set it so that all items are priced to 100
1. A finished example is avaliable in the _Resources_-folder

### Try it out

1. Browse products on your public site, all of them should now cost 100 

### Optional additional task

Only the logged in B2B-customers should get their prices from ERP, add a check so Litiums pricelogic is still used for all anonymous users.

1. Convert your `ERPPriceCalculator` into a [decorator](https://docs.litium.com/documentation/architecture/dependency-injection/service-decorator)
1. Check `Litium.Foundation.Security.SecurityToken.CurrentSecurityToken.IsAnonymousUser` if the user is logged in or not, if user is not logged in return Litium listprice, otherwise return price from ERP.
1. A finished example is avaliable in the _Resources_-folder