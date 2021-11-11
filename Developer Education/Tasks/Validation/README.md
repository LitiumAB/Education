# Validation

> To do this task you first need to complete the task [Author field](../Author%20field)

During testing of [Author field](../Author%20field) it became obvious that any page type can be set as author for a book,we need to validate that only author pages can be selected.

Additional documentation on validation is avaliable on [docs](https://docs.litium.com/documentation/architecture/validation)

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
1. Verify that the template id is **"Author"**, otherwise call the method `AddError("AuthorField", "Only Author-pages can be selected as author")` on the `ValidationResult` returned from the method. 
    
1. A finished example is avaliable in the [_Resources_-folder](Resources/ValidateBookAuthor.cs)

## Try it out

1. Edit a product and try to save it when you have selected a non-author page as author
1. You should get a validation error preventing you to save
1. Your errormessage should be visible in Litium Event Log
