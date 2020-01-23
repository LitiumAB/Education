# Lucene search

> Lucene is replaced by Elastic search in the Accelerator from Litium 7.4. Lucene is still part of the platform and is used to search for data in the E-Commerce module.

> To do this task you first need to complete the task [Web API](../Web%20API)

For the API to be useful for the resellers they have to be able to get a list of all authors avaliable to request books for.

We need to extend `IAuthorService` with a method to get all authors and make this mehod avaliable through the API.

To do this we will be using the [Lucene search engine in Litium](https://docs.litium.com/documentation/architecture/search).

1. Add method `List<(Guid, string)> GetAuthors();` to `IAuthorService` to return a list of tuples with id and name of all authors
1. Inject `Litium.Foundation.Solution` and `Litium.FieldFramework.FieldTemplateService` in `AuthorService`
1. Get the author template using `FieldTemplateService`: `var authorPageTemplate = _fieldTemplateService.Get<FieldTemplate>(typeof(WebsiteArea), "Author");`
1. Look at docs site on [how to build a search query and execute a search](https://docs.litium.com/documentation/architecture/search/building-a-search-query)
    1. Create the request: `var request = new QueryRequest(CultureInfo.CurrentCulture, CmsSearchDomains.Pages);`
    1. Add a tag to find pages using the Author-template: `request.FilterTags.Add(new Tag(TagNames.TemplateId, authorPageTemplate.Id));`
    1. Use `PageService` to get a page for each search hit and add the name and id of the page to the returned result
    1. A finished example is avaliable in the _Resources_-folder
1. Add the method `GetAuthors()` to `AuthorApiController` and make it return the result of `_authorService.GetAuthors()`

### Try it out

Call your new API-method and verify that it returns a list of all authors

## Optional extra task

Create a `AuthorServiceRatingsDecorator` that adds authors average rating for all books to the name, example: _Ernest Cline (avg. rating 7/10)_