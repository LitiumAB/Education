using Litium.Accelerator.Services;
using Litium.Accelerator.ViewModels.Author;
using Litium.Accelerator.ViewModels.Block;
using Litium.FieldFramework.FieldTypes;
using Litium.Runtime.AutoMapper;
using Litium.Web.Models.Blocks;
using Litium.Web.Models.Websites;

namespace Litium.Accelerator.Builders.Block
{
	public class AuthorBlockViewModelBuilder : IViewModelBuilder<AuthorBlockViewModel>
	{
		private readonly IAuthorService _authorService;

		public AuthorBlockViewModelBuilder(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		public virtual AuthorBlockViewModel Build(BlockModel blockModel)
		{
			var authorPagePointer = blockModel.Block.Fields.GetValue<PointerPageItem>("LinkToPage");
			if (authorPagePointer == null)
				return new AuthorBlockViewModel();

			var authorPageViewModel = authorPagePointer.EntitySystemId.MapTo<PageModel>()?.MapTo<AuthorViewModel>();
			if (authorPageViewModel == null)
				return new AuthorBlockViewModel();

			return new AuthorBlockViewModel
			{
				Author = authorPageViewModel.Title,
				Description = authorPageViewModel.Introduction,
				Image = authorPageViewModel.Image,
				Books = _authorService.GetBooksByAuthor(authorPagePointer.EntitySystemId)
			};
		}
	}
}