using System.Collections.Generic;
using Litium.Accelerator.Constants;
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
			// Get the page-link of the block to retrieve the author PAGE 
			var authorPagePointer = blockModel.Block.Fields
				.GetValue<PointerPageItem>(BlockFieldNameConstants.LinkToPage);
			if (authorPagePointer == null)
				return new AuthorBlockViewModel();

			// Map the retrieved pageid from the link to the viewmodel of the page
			var authorPageViewModel = authorPagePointer.EntitySystemId
				.MapTo<PageModel>()?
				.MapTo<AuthorViewModel>();

			if (authorPageViewModel == null)
				return new AuthorBlockViewModel();

			// Get the properties of the author PAGE and put these in the
			// viewmodel for the block, in this way we can show author info
			// by just pointing our block to the page we want to get
			// author information from.
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