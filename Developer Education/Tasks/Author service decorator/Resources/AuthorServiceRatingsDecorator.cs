using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Runtime.DependencyInjection;

namespace Litium.Accelerator.Services
{
    [ServiceDecorator(typeof(IAuthorService))]
    public class AuthorServiceRatingsDecorator : IAuthorService
    {
        private readonly IAuthorService _parent;

        public AuthorServiceRatingsDecorator(IAuthorService parent)
        {
            _parent = parent;
        }

        public List<string> GetBooksByAuthor(Guid authorPageId)
        {
            return _parent.GetBooksByAuthor(authorPageId)
                .Select(book => $"{book} (Rated {GetBookRating(book)}/10)")
                .ToList();
        }

        private int GetBookRating(string book)
        {
            if (string.IsNullOrEmpty(book))
                return 0;

            // Get book rating by counting number of characters in book title then
            // get the first number and add 1.
            return int.Parse(book.Length.ToString()[..1]) + 1;
        }
    }
}