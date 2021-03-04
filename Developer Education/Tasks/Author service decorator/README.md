# Author service decorator

> To do this task you first need to complete the task [Author service](../Author%20service)

We need to add ratings to all books returned by the `AuthorService`, instead of modifying the service this can be done using a service decorator.

1. Create a new class: `Litium.Accelerator.Services.AuthorServiceRatingsDecorator` that implement the `IAuthorService` interface

1. Register the class as a decorator for `IAuthorService` by decorating the class with 
    ```C#
    [Litium.Runtime.DependencyInjection.ServiceDecorator(typeof(IAuthorService))]
    ```
1. Open the [docs-site on service decorator](https://docs.litium.com/documentation/architecture/dependency-injection/service-decorator) and see how to use the original class implementation as __parent_ in your decorator
    1. Your decorator should append a rating to each book title, so _My book title_ becomes _My book title (5/10)_
    1. Implement how the rating number is fetched in any way you like (random/calculation/hard code to 5 etc.)
    1. A finished example is avaliable in the [_Resources_-folder](Resources/AuthorServiceRatingsDecorator.cs)

### Try it out

1. Build your solution and verify that your block is listing books from `AuthorService` where each title now displays a rating for the book