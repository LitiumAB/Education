using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Application.AppManagement;
using Litium.Application.Runtime;
using Litium.Runtime.DependencyInjection;

namespace Litium.Accelerator.Services;

[ServiceDecorator(typeof(IAuthorService))]
public class AuthorServiceRatingsDecorator : IAuthorService
{
    private readonly AppService _appService;
    private readonly AppHttpClientFactory _httpClientFactory;
    private readonly IAuthorService _parent;

    public AuthorServiceRatingsDecorator(IAuthorService parent, AppService appService, 
        AppHttpClientFactory httpClientFactory)
    {
        _parent = parent;
        _httpClientFactory = httpClientFactory;
        _appService = appService;
    }

    public List<string> GetBooksByAuthor(Guid authorPageId)
    {
        return _parent.GetBooksByAuthor(authorPageId)
            .Select(book => $"{book} (Rated {GetBookRating(book)}/10)")
            .ToList();
    }

    private int GetBookRating(string book)
    {
        // The GetRating method should be async and return a Task<int> !
        // ...but to keep the task simple and skip rewriting the consuming AuthorService
        // just call Result on the async methods
        var appId = "BookRatingsApp";
        var app = _appService.Get(appId);
        if (app == null)
            throw new Exception($"No app found with id '{appId}'");

        // By passing the App to CreateClientAsync Litium will set a valid Bearer-token in the request
        // it will also set the base-url from the app configuration:
        var httpClient = _httpClientFactory.CreateClientAsync(app).Result;
        var response = httpClient.GetAsync($"/api/ratings/rating/{book}").Result;
        var ratingString = response.Content.ReadAsStringAsync().Result;

        if (int.TryParse(ratingString, out var rating))
            return rating;

        throw new Exception($"Invalid rating: {ratingString}");
    }
}