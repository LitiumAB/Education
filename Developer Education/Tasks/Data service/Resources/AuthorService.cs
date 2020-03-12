using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Data;
using Litium.Data.Queryable;
using Litium.Products;

namespace Litium.Accelerator.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly DataService _dataService;

        public AuthorService(DataService dataService)
        {
            _dataService = dataService;
        }

        public List<string> GetBooksByAuthor(Guid authorPageId)
        {
            using (var query = _dataService.CreateQuery<BaseProduct>())
            {
                var bookQuery = query.Filter(filter => filter
                    .Bool(boolFilter => boolFilter
                        .Must(boolFilterMust => boolFilterMust
                            .Field("AuthorField", "eq", authorPageId))));

                var books = bookQuery.ToList();
                var bookTitles = books.Select(book => book.Localizations.CurrentCulture.Name).ToList();
                return bookTitles;
            }
        }
    }
}