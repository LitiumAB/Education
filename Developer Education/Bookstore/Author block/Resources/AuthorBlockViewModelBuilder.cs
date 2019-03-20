using Litium.Accelerator.Builders.Author;
using Litium.Accelerator.Constants;
using Litium.Accelerator.ViewModels.Author;
using Litium.FieldFramework.FieldTypes;
using Litium.Runtime.AutoMapper;
using Litium.Web.Models.Blocks;
using Litium.Web.Models.Websites;

namespace Litium.Accelerator.Builders.Block
{
	public class AuthorBlockViewModelBuilder : IViewModelBuilder<AuthorViewModel>
	{
		private readonly AuthorViewModelBuilder _authorViewModelBuilder;

		public AuthorBlockViewModelBuilder(AuthorViewModelBuilder authorViewModelBuilder)
		{
			_authorViewModelBuilder = authorViewModelBuilder;
		}

		public virtual AuthorViewModel Build(BlockModel blockModel)
		{
			// Get the link on the block to retrieve the author page id 
			var authorPagePointer = blockModel.Block.Fields
				.GetValue<PointerPageItem>(BlockFieldNameConstants.LinkToPage);
			if (authorPagePointer == null)
				return new AuthorViewModel();

			// Use the author page id to get the model for the author page
			var pageModel = authorPagePointer.EntitySystemId.MapTo<PageModel>();

			// Use the viewmodelbuilder to build and return the author 
			return _authorViewModelBuilder.Build(pageModel);
		}
	}
}