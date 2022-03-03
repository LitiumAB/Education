# Author service

> To do this task you first need to complete the task [Author page](../Author%20page)

To retreive books by authors you need a reusable service that you can inject and use in several places.

## Create and register the service

1. Create the interface `Litium.Accelerator.Services.IAuthorService`
    1. The interface should have one method:

        ```C#
        List<string> GetBooksByAuthor(Guid authorPageId)
        ```

        The parameter `authorPageId` will not be used in this task but is needed later in the [data service task](../Data%20service).

1. Register the interface as a service according to [instruction on docs](https://docs.litium.com/documentation/architecture/dependency-injection/service-registration)

1. Create the class `Litium.Accelerator.Services.AuthorServiceImpl` and make it implement your new `IAuthorService`-interface
    1. Implement the `GetBooksByAuthor`-method in `AuthorServiceImpl` so that it returns a hard-coded list of book titles

## Use the service to render books on the Author page

1. Add a books-property in `AuthorViewModel`:

    ```C#
    public List<string> Books { get; set; }
    ```

1. Add a constructor to `AuthorViewModelBuilder` and inject the `IAuthorService`-interface. Use the injected interface instance to set the `Books`-property of `AuthorViewModel`

1. Add a listing of the books in the author page view (_Src\Litium.Accelerator.Mvc\Views\Author\Index.cshtml_), example:

    ```HTML+Razor
    <h3>Popular books by @Model.Title</h3>
    <ul>
        @foreach (var book in Model.Books)
        {
            <li>@book</li>
        }
    </ul>
    ```

### Try it out

1. Build your solution and verify that your page is listing books from `AuthorServiceImpl`
1. If you get stuck a finished example of the service and `AuthorViewModelBuilder` can be found in the [_Resources_-folder](Resources/AuthorViewModelBuilder.cs)
