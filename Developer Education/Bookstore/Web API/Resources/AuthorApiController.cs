using System;
using System.Web.Http;
using Litium.Accelerator.Services;
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

		[Route("getBooksByAuthor")]
		public IHttpActionResult GetBooksByAuthor(Guid authorPageId)
		{
			return Ok(_authorService.GetBooksByAuthor(authorPageId));
		}
	}
}