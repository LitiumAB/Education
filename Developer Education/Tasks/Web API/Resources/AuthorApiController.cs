using System;
using System.Web.Http;
using Litium.Accelerator.Services;
using Litium.Accelerator.ViewModels.Author;
using Litium.Web.WebApi;

namespace Litium.Accelerator.Mvc.Controllers.Api
{
	[RoutePrefix("api/authors")]
	//[OnlyJwtAuthorization]
	public class AuthorApiController : ApiController
	{
		private readonly IAuthorService _authorService;

		public AuthorApiController(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		[HttpGet]
		[Route("author")]
		public IHttpActionResult GetAuthor(Guid authorPageId)
		{
			return Ok(new AuthorApiViewModel
			{
				Books = _authorService.GetBooksByAuthor(authorPageId)
			});
		}
	}
}