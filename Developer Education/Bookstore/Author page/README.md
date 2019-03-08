# Create Author Page

Here we will create a new page template that will be used to present information about a specific author.

It is recommended that all steps are completed before the solution is built and run to prevent that the template gets generated incomplete. If this happens you will find steps to re-generate the template at the bottom.

To simplify we will copy and modify files for the Article page.

### Add files to render the page

1. Copy `\Src\Litium.Accelerator\ViewModels\Article\ArticleViewModel.cs` to `\Src\Litium.Accelerator\ViewModels\Author\AuthorViewModel.cs`
    1. Adjust namespace and replace all occurances of _article_ in the file with _author_
1. Copy `\Src\Litium.Accelerator\Builders\Article\ArticleViewModelBuilder.cs` to `\Src\Litium.Accelerator\Builders\Author\AuthorViewModelBuilder.cs`
    1. Adjust namespace and replace all occurances of _article_ in the file with _author_
1. Copy `\Src\Litium.Accelerator.Mvc\Controllers\Article\ArticleController.cs` to `\Src\Litium.Accelerator.Mvc\Controllers\Author\AuthorController.cs`
    1. Adjust namespace and replace all occurances of _article_ in the file with _author_
1. Copy `\Src\Litium.Accelerator.Mvc\Views\Article\Index.cshtml` to `\Src\Litium.Accelerator.Mvc\Views\Author\Index.cshtml`
    1. Replace all occurances of _article_ in the file with _author_

### Register controller

1. Add _Author_ to `Litium.Accelerator.Constants.PageTemplateNameConstants`
1. Add _Author_ to the `_controllerMapping`-list in `Litium.Accelerator.Mvc.Definitions.FieldTemplateSetupDecorator`, set type to `Websites.WebsiteArea` and reference your previously created `AuthorController` 

### Create definitions that will generate the template on startup

1. Copy `\Src\Litium.Accelerator\Definitions\Pages\ArticlePageTemplateSetup.cs` to `AuthorPageTemplateSetup.cs` in the same folder
    1. Replace all occurances of _article_ in the file with _author_
1. Add a translation in `Src\Litium.Accelerator.Mvc\Site\Resources\Administration\Administration.resx`, use **key=**`fieldtemplate.websitearea.Author.name` and **value=**`Author page`

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

### Try it out

1. Build your solution and open Litium backoffice
1. Select _Websites_ in top menu and click _New page_
1. Your _Author page_ should now be avaliable in the list of avaliable templates, set your favourite authors name as name of the page and create the page below Start page > Customer service
1. Add some property values (at least set Name, Title, Introduction and Image which we will need later in the [Author block](../Author%20block) task
1. Click the "..."-menu in the top right corner and select _Quick publish_
1. Go to the public site and click the _Customer Service_-link in the footer
1. You should now se a link to your page in the left menu that you should be able to click and browse



