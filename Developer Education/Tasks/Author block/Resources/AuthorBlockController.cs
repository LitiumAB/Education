using Litium.Accelerator.Builders.Block;
using Litium.Web.Models.Blocks;
using Microsoft.AspNetCore.Mvc;

namespace Litium.Accelerator.Mvc.Controllers.Blocks
{
    public class AuthorBlockController : ViewComponent
    {
        private readonly AuthorBlockViewModelBuilder _builder;

        public AuthorBlockController(AuthorBlockViewModelBuilder builder)
        {
            _builder = builder;
        }

        public IViewComponentResult Invoke(BlockModel currentBlockModel)
        {
            var model = _builder.Build(currentBlockModel);
            return View("~/Views/Blocks/Author.cshtml", model);
        }
    }
}