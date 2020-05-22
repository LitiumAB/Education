# Validation

> To do this task you first need to complete the task [Author field](../Author%20field)

During testing of [Author field](../Author%20field) it became obvious that any page type can be set as author for a book,we need to validate that only author pages can be selected.

Additional documentation is avaliable on [docs](https://docs.litium.com/documentation/architecture/validation)

1. Create the class `ValidateBookAuthor` in namespace `Litium.Accelerator.ValidationRules` that inherit from
`Litium.Validations.ValidationRuleBase<BaseProduct>` and implement the `Validate`-method that the interitance requires and make it return a new `ValidationResult`
1. Get the selected page-id value of the BaseProduct-entity:
    ```C#
    var authorPageId = entity.Fields.GetValue<Guid?>("AuthorField");
    ```
1. Inject `Litium.Websites.PageService` and use it to get the author page instance
1. Inject `Litium.FieldFramework.FieldTemplateService` and use it to get the page template
    ```C#
    _fieldTemplateService.Get<FieldTemplate>(authorPage.FieldTemplateSystemId);
    ```
1. Validate that the template id is **"Author"**, if it is using the wrong template then call `AddError()` of the `ValidationResult` returned from the method.
    > When calling `AddErrror` set _Key=authorfield_ and any errormessage (lowercase on _Key_ is required due to [a bug](https://docs.litium.com/support/bugs/bug_details?id=50049)).
1. A finished example is avaliable in the _Resources_-folder

### Try it out

1. Edit a product and try to save it when you have selected a non-author page as author
1. You should get a validation error preventing you to save
1. Your errormessage should be visible in Litium Event Log

## Optional extra task Pre-order validation

The customers current distribution is rather expensive so we need to set a lower limit for all orders placed so that no order below 300 is allowed.

1. Create the class `Litium.Accelerator.ValidationRules.OrderGrandTotalOverLimitValidator` and make it implement `Litium.Foundation.Modules.ECommerce.Plugins.Orders.IPreOrderValidationRule`
1. Assert that no order placed has a grand total below 300, if not a `PreOrderValidationException` should be thrown (see the other validation classes in the same namespace for examples)
1. Optionally make the error message language dependent:
    1. Add a website text for the error message in _Litium backoffice > Control panel > Websites_, edit the websites and add a new translation on the _Texts_-tab.
    1. Get the translation with the extension method for string found in `Litium.Studio.Extenssions`, example: `"error".AsWebSiteString()`
1. A finished example is avaliable in the _Resources_-folder

### Try it out

1. Go to the public site and add items for less than 300 to cart
1. Fill out all mandatory fields in checkout and try to place the order
1. Below the confirm button in checkout your error should show