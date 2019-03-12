# Author service

To make business logic for Authors reusable we will place it in a service that we can inject into multiple locations.

1. Create `Litium.Accelerator.Services.AuthorService` and interface `IAuthorService` in the same namespace.
1. Register the interface as a service (see [instruction on docs](https://docs.litium.com/documentation/architecture/dependency-injection/service-registration))
1. The interface should have the method `List<string> GetBooksByAuthor(Guid authorPageId)`
1. Implement the `GetBooksByAuthor`-method in `AuthorService` so that it returns a hard-coded list of book titles
1. Inject the `IAuthorService`-interface in the constructor of `AuthorBlockViewModelBuilder`
1. Use `IAuthorService` to populate the `Books`-property of `AuthorBlockViewModel`

### Try it out

1. Build your solution and verify that your block is listing books from `AuthorService`
1. If you get stuck a finished example of `AuthorBlockViewModelBuilder` can be found in the _Resources_-folder

## Optional extra task
 
Inject your new service in `AuthorViewModelBuilder` and use it to present the list of books also on the author page.