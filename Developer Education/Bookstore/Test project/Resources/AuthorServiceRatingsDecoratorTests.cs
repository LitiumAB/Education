using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Accelerator.Services;
using Xunit;

namespace Litium.Accelerator.Tests
{
	public class AuthorServiceRatingsDecoratorTests
	{
		[Theory]
		[InlineData("The Odyssey", 2)]
		[InlineData("The Hitchhiker's Guide to the Galaxy", 4)]
		[InlineData("The Fellowship of the Ring (The Lord of the Rings, #1)", 6)]
		public void should_append_rating_to_title(string bookTitle, int expectedRating)
		{
			// An easier way than creating your own mocks
			// is to use an existing mocking library, like https://github.com/moq/moq
			var service = new MockAuthorService(bookTitle);
			var decorator = new AuthorServiceRatingsDecorator(service);
			var decoratedBooks = decorator.GetBooksByAuthor(Guid.Empty);

			Assert.Equal(1, decoratedBooks.Count);
			Assert.Equal($"{bookTitle} (Rated {expectedRating}/10)", decoratedBooks.First());
		}

		private class MockAuthorService : IAuthorService
		{
			private readonly string _bookTitle;

			public MockAuthorService(string bookTitle)
			{
				_bookTitle = bookTitle;
			}

			public List<string> GetBooksByAuthor(Guid authorPageId)
			{
				return new List<string> {_bookTitle};
			}

			public List<Tuple<string, Guid>> GetAuthors()
			{
				throw new NotImplementedException();
			}
		}
	}
}