using System;
using System.Collections.Generic;
using System.Linq;
using Litium.Accelerator.Services;
using Moq;
using Shouldly;
using Xunit;

namespace Litium.Accelerator.Tests
{
    /// <summary>
    ///     Example XUnit-tests for AuthorServiceRatingsDecorator created in the Author Service Decorator task
    ///     https://github.com/LitiumAB/Education/tree/master/Developer%20Education/Tasks/Author%20service%20decorator
    ///
    ///     Dependencies:
    ///     https://github.com/Moq/moq4/wiki/Quickstart
    ///     https://github.com/shouldly/shouldly
    /// </summary>
    public class AuthorServiceRatingsDecoratorTests
    {
        [Fact]
        public void Adds_rating_to_book_name()
        {
            var bookTitle = "Lord of the rings";
            
            var parent = new Mock<IAuthorService>();
            parent.Setup(p => p.GetBooksByAuthor(It.IsAny<Guid>()))
                .Returns(new List<string> {bookTitle});

            var decorator = new AuthorServiceRatingsDecorator(parent.Object);

            var books = decorator.GetBooksByAuthor(Guid.Empty);

            books.Count.ShouldBe(1);
            books.First().ShouldBe($"{bookTitle} [RATED 9/10]");
        }
    }
}