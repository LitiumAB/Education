using System.Collections.Generic;
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
				Books = new List<string>
				{
					"Ready player one",
					"Armada"
				}
			};
		}
	}
}