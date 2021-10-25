# Data service - LITIUM 7 ONLY

Until now the list of books for authors has been hard coded but with our new field we can load all books for an author from PIM.

1. Inject `Litium.Data.DataService` into the constructor of `AuthorServiceImpl`
1. See the [documentation on docs for data service](https://docs.litium.com/documentation/architecture/data-service) and write a query that return all **BaseProducts** where the **Author**-field has the `authorPageId` that is passed to the `GetBooksByAuthor`-method
1. Get and return the name-property for all BaseProducts returned from your query (`book.Localizations.CurrentCulture.Name`)
1. A finished example is avaliable in the [_Resources_-folder](Resources/AuthorServiceImpl.cs)

### Try it out

1. Open the startpage and verify that the _AuthorBlock_ created earlier now shows products from PIM where the author selected in the block is set as author.
1. Modify products in PIM to veriry that changes to the author-field is reflected in the book listing of the author-block.