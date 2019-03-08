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
			// Get book rating by counting number of characters in book title and get the first number
			// Example:
			//    25 = 2
			//    7 = 7
			//    13 = 1
			return string.IsNullOrEmpty(book) ? 0 : int.Parse(book.Length.ToString().Substring(0, 1)) + 1;
		}
	}
}