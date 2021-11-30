# Create Author Block

> To do this task you first need to complete the task [Author page](../Author%20page)

Our client needs a block to present authors as blocks on the startpage.

Creating a block is very similar to creating a page

## 1. Allow automated template updates from code

Templates are only created/updated from code the first time the application starts. Follow the instructions in [Author page task](../Author%20page) to make Litium update templates from their coded definition on _every_ startup.

## 2. Create a definition that will generate the template on startup

1. Add _Author_ to `Litium.Accelerator.Constants.BlockTemplateNameConstants`
1. Create the file  `\Src\Litium.Accelerator\Definitions\Blocks\AuthorBlockTemplateSetup.cs`, copy content for the file from the [_Resources_-folder](Resources/AuthorBlockTemplateSetup.cs). 
   > The block only has a Name property and a LinkToPage property, the LinkToPage will be used to select an author page that the block will display content from.
1. Add translations for the block in `\Src\Litium.Accelerator.Administration.Extensions\Resources\Administration.resx`:
    |Key|Value|
    |--|--|
    |`fieldtemplate.blockarea.author.name`|Author block|
    |`fieldtemplate.blockarea.author.fieldgroup.general.name`|General author block settings|

## 3. Create Controller, ViewModel and View needed to display the block

1. Create the file  `\Src\Litium.Accelerator\Builders\Block\AuthorBlockViewModelBuilder.cs`, copy content for the file from the [_Resources_-folder](Resources/AuthorBlockViewModelBuilder.cs)
    > The Author block will contain the same information as the Author page created earlier so we can re-use the AuthorViewModel instead of creating a new one
1. Create the file `\Src\Litium.Accelerator.Mvc\Controllers\Blocks\AuthorBlockController.cs`, copy content for the file from the [_Resources_-folder](Resources/AuthorBlockController.cs)
1. Create the file `\Src\Litium.Accelerator.Mvc\Views\Blocks\Author.cshtml`, copy content for the file from the [_Resources_-folder](Resources/Author.cshtml)

##  4. Link the definition to the controller

The link will tell Litium which controller to use to render blocks using the Author template definition.

1. Add _Author_ to the `_controllerMapping`-dictionary in `Litium.Accelerator.Mvc.Definitions.FieldTemplateSetupDecorator`:
    ```C#
    [(typeof(Blocks.BlockArea), BlockTemplateNameConstants.Author)] = (typeof(AuthorBlockController), nameof(AuthorBlockController.Invoke))
    ```

## 5. Try it out

1. Build your solution and open Litium backoffice
1. Select _Websites_ in top menu, select _Home page_ in left menu and select _Blocks_ from the "..."-menu in the top right corner
1. Click **Add blocks**
1. Drag an instance of your Author-block out to the block area
1. In the "Link to page"-property select your previously created Author-page
1. Quick publish the page from the "..."-menu in the top right corner
1. Go to the start page of the public site and review your block

## 6. Optional extra task - Validate page template

To prevent other pages than those using the Author-template to be selected you can implement validation as described in the **[Validation task](../Validation)**