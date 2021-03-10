# Create Author Page

Here we will create a new page template that will be used to present information about a specific author.

It is recommended that all steps are completed before the solution is built and run to prevent that the template gets generated incomplete. If this happens you will find steps to re-generate the template at the bottom.

To simplify we will copy and modify files for the Article page.

## 1. Create the definitions that will generate the template on startup

The template is what defines which fields that are avaliable when a Author page is created.

1. Add _Author_ to `Litium.Accelerator.Constants.PageTemplateNameConstants`
1. Copy `\Src\Litium.Accelerator\Definitions\Pages\ArticlePageTemplateSetup.cs` to `AuthorPageTemplateSetup.cs` in the same folder
    1. Replace all occurances of _article_ in the file with _author_
1. Add a translation in `Src\Litium.Accelerator.Mvc\Site\Resources\Administration\Administration.resx`, use **key=**`fieldtemplate.websitearea.Author.name` and **value=**`Author page`

## 2. Add MVC files needed to render the page

When the template definition is created you can create instances of your new page, but the page cannot be displayed on the public site until MVC files are added.

1. Copy `\Src\Litium.Accelerator\ViewModels\Article\ArticleViewModel.cs` to `\Src\Litium.Accelerator\ViewModels\Author\AuthorViewModel.cs`
    1. Adjust namespace and replace all occurances of _article_ in the file with _author_
1. Copy `\Src\Litium.Accelerator\Builders\Article\ArticleViewModelBuilder.cs` to `\Src\Litium.Accelerator\Builders\Author\AuthorViewModelBuilder.cs`
    1. Adjust namespace and replace all occurances of _article_ in the file with _author_
1. Copy `\Src\Litium.Accelerator.Mvc\Controllers\Article\ArticleController.cs` to `\Src\Litium.Accelerator.Mvc\Controllers\Author\AuthorController.cs`
    1. Adjust namespace and replace all occurances of _article_ in the file with _author_
1. Copy `\Src\Litium.Accelerator.Mvc\Views\Article\Index.cshtml` to `\Src\Litium.Accelerator.Mvc\Views\Author\Index.cshtml`
    1. Replace all occurances of _article_ in the file with _author_

## 3. Connect the definition with the controller

With the MVC Controller and View created we can render the template on the site, but the Litium platform also need to know that the Author template and the Author controller are connected.

1. Add _Author_ to the `_controllerMapping`-list in `Litium.Accelerator.Mvc.Definitions.FieldTemplateSetupDecorator`, set type to `Websites.WebsiteArea` and reference your previously created `AuthorController` 

## 4. Try it out

1. Build your solution and open Litium backoffice
1. Select _Websites_ in top menu and click _New page_
    1. Set your favourite authors name as name of the page
    1. _Author page_ should now be avaliable in the list of avaliable templates, select it (**if you do not see it then follow the steps below to re-generate the template**)
    1. For _location_ select _Home page > Customer service_
1. Add some property values (at least set Name, Title, Introduction and Image)
1. Click the "..."-menu in the top right corner and select _Quick publish_
1. Go to the public site and click the _Customer Service_-link in the footer
1. You should now see a link to your Author page in the left menu

> ### If your template is incorrect and needs to be re-generated
> 
> If you just try to delete your template from backoffice and restart it will not be recreated. The reason is that a flag is set in the database on first creation and if this flag is set the template will not be re-created.
> 
> So there are 2 options, first option is to remove the flag from database:
> 
> 1. First find the key in database: `SELECT * FROM Common.Setting WHERE [Key] LIKE '%author%'`
> 1. After verification that the flag is there delete the row: `DELETE FROM Common.Setting WHERE [Key] LIKE '%author%'`
> 1. Now delete the Author-template in Litium backoffice
> 1. Restart your website to flush cache and re-create the template from code
> 
> The other option is to remove the check in code so that all templates are always re-created
> 
> 1. Open `\Src\Litium.Accelerator\Definitions\DefinitionSetup.cs`
> 1. In the method `InitTemplates()` locate the `IsAlreadyExecutedCheck` and just comment out `continue`, now your template will update from code on every restart 
