using System;
using System.Collections.Generic;
using Litium.Data;
using Litium.Data.Queryable;
using Litium.Products;
using Litium.Websites;

namespace Litium.Accelerator.Services
{
	public class AuthorService : IAuthorService
	{
		private readonly DataService _dataService;
		private readonly PageService _pageService;

		public AuthorService(PageService pageService, DataService dataService)
		{
			_pageService = pageService;
			_dataService = dataService;
		}

		public List<BaseProduct> GetBooksByAuthor(Guid authorPageId)
		{
			var authorPage = _pageService.Get(authorPageId);
			if (authorPage == null)
				throw new Exception($"Page not found for author with id {authorPageId}");

			using (var query = _dataService.CreateQuery<BaseProduct>())
			{
				var bookQuery = query.Filter(filter => filter
					.Bool(boolFilter => boolFilter
						.Must(boolFilterMust => boolFilterMust
							.Field("Author", "eq", authorPage.SystemId))));

				return bookQuery.ToList();
			}
		}
	}
}