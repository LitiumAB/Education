# Create Author Block

Our client needs a block to present an author with some books in a block on the startpage.

Creating a block is very similar to the previous task of creating the Author page

It is recommended that all steps are completed before the solution is built and run to prevent that the template gets generated incomplete. If this happens you will find steps to re-generate the template at the bottom.

To simplify we will copy and modify files for the _Products and banner_ block.

### Create block

1. Copy `\Src\Litium.Accelerator\ViewModels\Block\ProductsAndBannerBlockViewModel.cs` to `AuthorBlockViewModel.cs` in the same folder
    1. Replace all occurances of _ProductsAndBanner_ in the file with _author_
    1. `AuthorBlockViewModel` should have the properties: `Author` (`string`), `Description` (`string`), `Image` (`ImageModel`), `Books` (`List<string>`)
    1. A finished example is avaliable in the _Resources_-folder
1. Copy `\Src\Litium.Accelerator\Builders\Block\ProductsAndBannerBlockViewModelBuilder.cs` to `AuthorBlockViewModelBuilder.cs` in the same folder
    1. Replace all occurances of _ProductsAndBanner_ in the file with _author_
    1. Get the value from the author field: `
    var authorPagePointer = blockModel.Block.Fields.GetValue<PointerPageItem>("LinkToPage");
    `
    1. Map the field value to the `AuthorViewModel` by first mapping it to `PageModel` : `var authorPageViewModel = authorPagePointer.EntitySystemId.MapTo<PageModel>()?.MapTo<AuthorViewModel>();`
    1. Map values of the authorpage to the the `AuthorBlockViewModel`
    1. Set `Books` to a new List with a few hard-coded book titles for now
    1. A finished example is avaliable in the _Resources_-folder
1. Copy `\Src\Litium.Accelerator.Mvc\Controllers\Blocks\ProductsAndBannerBlockController.cs` to `AuthorBlockController.cs` in the same folder
    1. Replace all occurances of _ProductsAndBanner_ in the file with _author_
1. Copy `\Src\Litium.Accelerator.Mvc\Views\Block\ProductsAndBanner.cshtml` to `Author.cshtml` in the same folder
    1. Replace all occurances of _ProductsAndBanner_ in the file with _author_
    1. Modify the template so that it shows the fields _Author_, _Image_, _Description_ and a listing of the _Books_-field
    1. A finished example is avaliable in the _Resources_-folder

### Register the controller

1. Add _Author_ to `Litium.Accelerator.Constants.BlockTemplateNameConstants`
1. Add _Author_ to the `_controllerMapping`-list in `Litium.Accelerator.Mvc.Definitions.FieldTemplateSetupDecorator`, set type to `Blocks.BlockArea` and reference your previously created `AuthorBlockController` 

### Create definitions that will generate the template on startup

1. Copy `\Src\Litium.Accelerator\Definitions\Blocks\ProductsAndBannerBlockTemplateSetup.cs` to `AuthorBlockTemplateSetup.cs` in the same folder
    1. Replace all occurances of _ProductsAndBanner_ in the file with _author_
    1. Remove the _Banner_ FieldTemplateFieldGroup (we will instead get info from the author page)
    1. Remove the method `GetProductBlock()` (we will instead get products connected to the author)
    1. Add `BlockFieldNameConstants.LinkToPage` to the `General` FieldTemplateFieldGroup
    1. A finished example is avaliable in the _Resources_-folder
1. Add translations for the block in `Src\Litium.Accelerator.Mvc\Site\Resources\Administration\Administration.resx`:
    1. **key=**`fieldtemplate.blockarea.author.name` **value=**`Author block`
    1. **key=**`fieldtemplate.blockarea.author.fieldgroup.general.name` **value=**`General author block settings`

### Try it out

1. Build your solution and open Litium backoffice
1. Select _Websites_ in top menu, select _Home page_ in left menu and select _Blocks_ from the "..."-menu in the top right corner
1. Drag an instance of your Author-block out to the block area
1. In the "Link to page"-property select your previously created Author-page
1. Quick publish the page from the "..."-menu in the top right corner
1. Go to the start page of the public site and review your block

## If your template is incorrect and needs to be re-generated

Se the [_Author page_ task](../Author%20page) for instructions on how to re-generate your template.