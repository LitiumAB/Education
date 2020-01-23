# Create Author Block

Our client needs a block to present an authors as blocks on the startpage.

Creating a block is very similar to creating a page

It is recommended that all steps are completed before the solution is built and run to prevent that the template gets generated incomplete. If this happens you will find steps to re-generate the template at the bottom.

### Create definitions that will generate the template on startup

1. Create the file  `\Src\Litium.Accelerator\Definitions\Blocks\AuthorBlockTemplateSetup.cs`, copy content for the file from the _Resources_-folder. 
   > The block only has a Name property and a LinkToPage property, the LinkToPage will be used to select an author page that the block will display content from.
1. Add translations for the block in `Src\Litium.Accelerator.Mvc\Site\Resources\Administration\Administration.resx`:
    |Key|Value|
    |--|--|
    |`fieldtemplate.blockarea.author.name`|Author block|
    |`fieldtemplate.blockarea.author.fieldgroup.general.name`|General author block settings|

### Create the ViewModel and View that will render the block

1. Create the file  `\Src\Litium.Accelerator\Builders\Block\AuthorBlockViewModelBuilder.cs`, copy content for the file from the _Resources_-folder
    > The Author block will contain the same information as the Author page created earlier so we can re-use the AuthorViewModel instead of creating a new one
1. Create the file `\Src\Litium.Accelerator.Mvc\Controllers\Blocks\AuthorBlockController.cs`, copy content for the file from the _Resources_-folder
1. Create the file `\Src\Litium.Accelerator.Mvc\Views\Block\Author.cshtml`, copy content for the file from the _Resources_-folder

### Register the controller

1. Add _Author_ to `Litium.Accelerator.Constants.BlockTemplateNameConstants`
1. Add _Author_ to the `_controllerMapping`-list in `Litium.Accelerator.Mvc.Definitions.FieldTemplateSetupDecorator`, set type to `Blocks.BlockArea` and reference your previously created `AuthorBlockController` 

### Try it out

1. Build your solution and open Litium backoffice
1. Select _Websites_ in top menu, select _Home page_ in left menu and select _Blocks_ from the "..."-menu in the top right corner
1. Click **Add blocks**
1. Drag an instance of your Author-block out to the block area
1. In the "Link to page"-property select your previously created Author-page
1. Quick publish the page from the "..."-menu in the top right corner
1. Go to the start page of the public site and review your block

## If your template is incorrect and needs to be re-generated

Se the [_Author page_ task](../Author%20page) for instructions on how to re-generate your template.