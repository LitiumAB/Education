using System;
using System.Collections.Generic;
using Litium.Accelerator.Services;
using Litium.Web.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace Litium.Accelerator.Mvc.Controllers.Api
{
    [Route("api/authors")]
    //[OnlyJwtAuthorization]
    public class AuthorApiController : ApiControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorApiController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("author")]
        public IActionResult GetAuthor(Guid authorPageId)
        {
            return Ok(new AuthorApiViewModel
            {
                Books = _authorService.GetBooksByAuthor(authorPageId)
            });
        }

        public class AuthorApiViewModel
        {
            public List<string> Books { get; set; }
        }
    }
}