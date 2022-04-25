# Validation

> To do this task you first need to complete the task [Author field](../Author%20field)

During testing of [Author field](../Author%20field) it became obvious that any page type can be set as author for a book, you need to validate that only author pages can be selected.

Additional documentation on validation is avaliable on [docs](https://docs.litium.com/documentation/architecture/validation)

1. Create the class `ValidateBookAuthor` in namespace `Litium.Accelerator.ValidationRules` that inherit from
`Litium.Validations.ValidationRuleBase<BaseProduct>` and implement the `Validate`-method that the inheritance requires and make it return a new `ValidationResult`
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

## Optional extra task: Localize the validation message

In backoffice Litium uses [ASP.NET standard localization](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization) with translations kept in resource (.resx) files. Read more about translations in [Litium docs](https://docs.litium.com/documentation/litium-platform/back-office/translations).

### Add the validation message

The first step is to create a new resource file to keep your project specific translations separated from other translations.

1. Create a copy of the file `\Src\Litium.Accelerator\Resources\Common.resx` called `Bookstore.resx` in the same folder

1. Delete all strings from `Bookstore.resx` and then add two new ones:
    |Name|Value|
    |--|--|
    |ValidationProductAuthorField|A page using author template is required|
    |ValidationProductAuthorGlobal|Author page validation failed|

### Make your resource file available

In [ASP.NET standard localization](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization) a resource file has be named as the class using it, but with Litium we can make all resource files in a project shared with all classes just by setting an assembly attribute, this will also make the strings available to the client Angular UI.

Do the changes below in the file `Litium.Accelerator.csproj`:

1. Modify the `LitiumLocalization`-tag to include all resource files in the _Resources_-folder (not only the _Common_-file):

    ```XML
    <!--Replace:-->
    <LitiumLocalization Include="Resources\Common*.resx" />
    <!--With:-->
    <LitiumLocalization Include="Resources\*.resx" />
    ```

1. Add the assembly attribute below to instruct Litium to include all resource file strings defined by the `LitiumLocalization`-tag when creating a `IStringLocalizer` for any class in the current project:

    ```XML
    <ItemGroup>
        <AssemblyAttribute Include="Litium.Localization.UseAdministrationResourceAttribute" />
    </ItemGroup>
    ```

### Read the resources in your validation class

1. Inject `IStringLocalizer<ValidateBookAuthor>` in the constructor of your `ValidateBookAuthor`-class.

1. Use the injected localizer to get and use the translated errors

    ```C#
    result.AddError("AuthorField", _stringLocalizer["ValidationProductAuthorField"]);
    result.AddError("*", _stringLocalizer["ValidationProductAuthorGlobal"]);
    ```

1. Set an invalid author page and verify that the message displayed comes from your resource file.

### Add another language

1. Create a copy of the file `Bookstore.resx` called `Bookstore.sv-se.resx` and translate the texts in the new file to swedish.

1. Click your username in the top-right corner in backoffice UI to change language to swedish, then reload the page.

1. Verify that the swedish error message is now showing for the validation error.

### Troubleshooting localization

If your translations are not read from the resource files, check your `.csproj`-file, if Visual Studio has generated any of the lines below, delete them:

```XML
<LitiumLocalization Remove="Resources\Bookstore.resx" />
<LitiumLocalization Remove="Resources\Bookstore.sv-se.resx" />
```
