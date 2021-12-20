# Data service

> To do this task you first need to complete the tasks [Author field](../Author%20field) and [Author service](../Author%20service).

Until now the list of books for authors has been hard coded but with our new field we can load all books for an author from PIM.

A finished example is avaliable in the [_Resources_-folder](Resources/AuthorServiceImpl.cs)

1. Inject `Litium.Data.DataService` into the constructor of `AuthorServiceImpl`
1. See the [documentation on docs for data service](https://docs.litium.com/documentation/architecture/data-service) and write a query that returns all **BaseProducts** where the **Author**-field has the `authorPageId` that is passed to the `GetBooksByAuthor`-method
1. Get and return the name-property for all BaseProducts returned from your query (`book.Localizations.CurrentCulture.Name`)

## Try it out

1. Open the startpage and verify that the _AuthorBlock_ created earlier now shows products from PIM where the author selected in the block is set as author.
1. Modify products in PIM to veriry that changes to the author-field is reflected in the book listing of the author-block.

## Optional extra task

Data service should never be used in production without a cache, inject and use [IDistributedCache](https://docs.litium.com/documentation/get-started/multi-server-installation) to cache the books for a limited time.

A finished example is avaliable in the [_Resources_-folder](Resources/AuthorServiceImpl.cs)
