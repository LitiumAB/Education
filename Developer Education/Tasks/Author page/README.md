# Create Author Page

> To do this task you first need to complete the task [Installation](../Installation)

In this task you will create a new page template that will be used to present information about a specific author.

You will copy and modify the files of the _Article page template_ to create a new _Author page template_.

## 1. Allow automated template updates from code

Templates are only created/updated from code the first time the application starts. To make Litium update templates from their coded definition on _every_ startup adjust the check that is done in `DefinitionSetup`.

1. Open `\Src\Litium.Accelerator\Definitions\DefinitionSetup.cs`
1. In the method `InitTemplates()` locate the `IsAlreadyExecutedCheck` and just comment out `continue`, now your template will update from code on every restart

Now any change made in code will be visible on the template after start.

> Important! Making this change will also revert any change made to a template in Litium backoffice to the code-version on every restart.

## 2. Create the definitions that will generate the template on startup

The template is what defines which fields that are avaliable when a Author page is created.

1. Add _Author_ to `Litium.Accelerator.Constants.PageTemplateNameConstants`
1. Copy `\Src\Litium.Accelerator\Definitions\Pages\ArticlePageTemplateSetup.cs` to `AuthorPageTemplateSetup.cs` in the same folder
    1. Search and replace all occurances of _Article_ in the file with _Author_
1. Add a translation in `\Src\Litium.Accelerator.Administration.Extensions\Resources\Administration.resx`, use **key=**`fieldtemplate.websitearea.Author.name` and **value=**`Author page`

## 3. Add MVC files needed to render the page

When the template definition is created you can create instances of your new page, but the page cannot be displayed on the public site until MVC files are added.

1. Copy `\Src\Litium.Accelerator\ViewModels\Article\ArticleViewModel.cs` to `\Src\Litium.Accelerator\ViewModels\Author\AuthorViewModel.cs`
    1. Search and replace all occurances of _Article_ in the file with _Author_
1. Copy `\Src\Litium.Accelerator\Builders\Article\ArticleViewModelBuilder.cs` to `\Src\Litium.Accelerator\Builders\Author\AuthorViewModelBuilder.cs`
    1. Search and replace all occurances of _Article_ in the file with _Author_
1. Copy `\Src\Litium.Accelerator.Mvc\Controllers\Article\ArticleController.cs` to `\Src\Litium.Accelerator.Mvc\Controllers\Author\AuthorController.cs`
    1. Search and replace all occurances of _Article_ in the file with _Author_
1. Copy `\Src\Litium.Accelerator.Mvc\Views\Article\Index.cshtml` to `\Src\Litium.Accelerator.Mvc\Views\Author\Index.cshtml`
    1. Search and replace all occurances of _Article_ in the file with _Author_

## 4. Connect the definition with the controller

With the MVC Controller and View created you can render the template on the site, but the Litium platform also need to know that the Author template and the Author controller are connected.

1. Add _Author_ to the `_controllerMapping`-list in `Litium.Accelerator.Mvc.Definitions.FieldTemplateSetupDecorator`, set type to `Websites.WebsiteArea` and reference your previously created `AuthorController` 

## 5. Try it out

1. Build your solution and open Litium backoffice
1. Select _Website_ in top menu and click _New page_
    1. Set your favourite authors name as name of the page
    1. _Author page_ should now be avaliable in the list of avaliable templates
    1. For _location_ select _Home page > Customer service_
1. Add some property values (at least set Name, Title, Introduction and Image)
1. Click the "..."-menu in the top right corner and select _Quick publish_
1. Go to the public site and click the _Customer Service_-link in the footer
1. You should now see a link to your Author page in the left menu