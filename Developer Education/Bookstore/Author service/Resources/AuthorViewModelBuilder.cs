using Litium.Accelerator.Services;
using Litium.Accelerator.ViewModels.Author;
using Litium.Runtime.AutoMapper;
using Litium.Web.Models.Websites;

namespace Litium.Accelerator.Builders.Author
{
	public class AuthorViewModelBuilder : IViewModelBuilder<AuthorViewModel>
	{
		private readonly IAuthorService _authorService;

		public AuthorViewModelBuilder(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		public virtual AuthorViewModel Build(PageModel pageModel)
		{
			var model = pageModel.MapTo<AuthorViewModel>();
			model.Books = _authorService.GetBooksByAuthor(pageModel.SystemId);
			return model;
		}
	}
}