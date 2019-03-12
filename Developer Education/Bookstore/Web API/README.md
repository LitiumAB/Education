# Web API

Our client has resellers that need to access information about books for specific authors through a REST API. We need to provide an API to access our [Author service](../Author%20service).

See Litium docs for a [API controller sample](https://docs.litium.com/documentation/architecture/web-api) which is similar to the controller we are creating here.

1. Create the class `Litium.Accelerator.Mvc.Controllers.Api.AuthorApiController`
    1. Decorate it with `[RoutePrefix("api/authors")]`
1. Add the method `GetBooksByAuthor(Guid authorPageId)`
    1. Decorate it with `[Route("getBooksByAuthor")]`
1. Inject `IAuthorService` in your controllers constructor and use it to get and return all books for the provided id

### Try it out

1. Get the systemid for your author page (the easiest way is to open the page in Litium backoffice, then the id is showing in the url-field)
1. You should be able to reach your API at _[your site domain]/api/authors/getBooksByAuthor?authorPageId=[Your author page id]_

## Optional extra task

We need to protect access to our API, for information read sections on _Security_ and _Authorization_ on the Docs-link above

1. Decorate your controller with `[Litium.Web.WebApi.OnlyJwtAuthorization]`
1. Try accessing your API again and note that your are now getting a **401 Unauthorized** error
1. Create a service account in _Litium Backoffice > Control panel > System settings > Service accounts_
1. Use postman to get a JWT token and pass the token in your API-call, instructions on how to do this can be found on docs.