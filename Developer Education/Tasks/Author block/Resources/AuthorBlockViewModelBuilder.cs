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
        private readonly AuthorViewModelBuilder _authorPageViewModelBuilder;

        public AuthorBlockViewModelBuilder(AuthorViewModelBuilder authorPageViewModelBuilder)
        {
            _authorPageViewModelBuilder = authorPageViewModelBuilder;
        }

        public virtual AuthorViewModel Build(BlockModel blockModel)
        {
            // Get the link property on the block to retrieve the selected author page id 
            var authorPagePointer = blockModel.Block.Fields
                .GetValue<PointerPageItem>(BlockFieldNameConstants.LinkToPage);
            if (authorPagePointer == null)
                return new AuthorViewModel();

            // Use the author page id to get the model for the author page
            var pageModel = authorPagePointer.EntitySystemId.MapTo<PageModel>();

            // Use the viewmodelbuilder to build and return the author 
            return _authorPageViewModelBuilder.Build(pageModel);
        }
    }
}