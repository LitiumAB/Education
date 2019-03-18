# Validation

During testing of the [Author field](../Author%20field) it became obvious that not only pages of type _Author_ could be set as author for a book. 

We need to add a validation to prevent that a non author page can be set.

Additional documentation is avaliable on [docs](https://docs.litium.com/documentation/architecture/validation)

1. Create the class `ValidateBookAuthor` in namespace `Litium.Accelerator.ValidationRules` that inherit from
`Litium.Validations.ValidationRuleBase<BaseProduct>` and implement the `Validate`-method that the interitance requires and make it return a new `ValidationResult`
1. Inject `Litium.Websites.PageService` and `Litium.FieldFramework.FieldTemplateService` and use these to validate that if a page is selected it has to be a page using the _Author_-template
1. If it is using the wrong template then call AddError()
on the returned ValidationResult, set **Key**=_Author_ and any errormessage
1. A finished example is avaliable in the _Resources_-folder

### Try it out

1. Edit a product and try to save it when you have selected a non-author page as author
1. You should get a validation error preventing you to save
1. Your errormessage should be visible in Litium Event Log

## Optional extra task

The customers current distribution is rather expensive so we need to set a lower limit for all orders placed so that no order below 300 is allowed.

1. Create the class  `Litium.Accelerator.ValidationRules.OrderGrandTotalOverLimitValidator` and make it implement `Litium.Foundation.Modules.ECommerce.Plugins.Orders.IPreOrderValidationRule`
1. Assert that no order placed has a grand total below 300, if not a `PreOrderValidationException` should be thrown (see the other validation classes in the same namespace for examples)
1. Optionally make the error message language dependent:
    1. Add a website text for the error message in _Litium backoffice > Control panel > Websites_, edit the websites and add a new translation on the _Texts_-tab.
    1. Get the translation with the extension method for string found in `Litium.Studio.Extenssions`, example: `"error".AsWebSiteString()`
1. A finished example is avaliable in the _Resources_-folder

### Try it out

1. Go to the public site and add items for less than 300 to cart
1. Fill out all mandatory fields in checkout and try to place the order
1. Below the confirm button in checkout your error should show