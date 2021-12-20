using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Litium.Data;
using Litium.Data.Queryable;
using Litium.Products;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Litium.Accelerator.Services
{
    public class AuthorServiceImpl : IAuthorService
    {
        private readonly IDistributedCache _cache;
        private readonly DataService _dataService;
        private readonly ILogger<AuthorServiceImpl> _logger;

        public AuthorServiceImpl(DataService dataService, IDistributedCache cache, ILogger<AuthorServiceImpl> logger)
        {
            _dataService = dataService;
            _cache = cache;
            _logger = logger;
        }

        public List<string> GetBooksByAuthor(Guid authorPageId)
        {
            // 1. First try to get the books from cache
            var cacheKey = $"GetBooksByAuthor-{authorPageId}";
            var bookTitles = GetFromCache(cacheKey);
            if (bookTitles != null)
            {
                _logger.LogDebug($"Getting books from cache for author {authorPageId}");
                return bookTitles;
            }

            // 2. Books are not available in cache, get from database using DataService
            //    and then add to cache for one minute.
            _logger.LogDebug($"Getting books with DataService for author {authorPageId}");
            using (var query = _dataService.CreateQuery<BaseProduct>())
            {
                var bookQuery = query.Filter(filter => filter
                    .Bool(boolFilter => boolFilter
                        .Must(boolFilterMust => boolFilterMust
                            .Field("AuthorField", "eq", authorPageId))));

                var books = bookQuery.ToList();
                bookTitles = books.Select(book => book.Localizations.CurrentCulture.Name).ToList();
                AddToCache(cacheKey, bookTitles, 1);
                return bookTitles;
            }
        }

        private void AddToCache(string cacheKey, List<string> bookTitles, double cacheDurationMinutes)
        {
            var byteData = JsonSerializer.SerializeToUtf8Bytes(bookTitles);
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(cacheDurationMinutes))
            };
            _cache.Set(cacheKey, byteData, cacheOptions);
        }

        private List<string> GetFromCache(string cacheKey)
        {
            var cacheByteData = _cache.Get(cacheKey);
            if (cacheByteData == null || cacheByteData.Length == 0)
                return null;

            var stringData = Encoding.UTF8.GetString(cacheByteData);
            return JsonSerializer.Deserialize<List<string>>(stringData);
        }
    }
}