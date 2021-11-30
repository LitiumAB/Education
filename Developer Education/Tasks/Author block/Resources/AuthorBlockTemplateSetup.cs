using System;
using System.Collections.Generic;
using Litium.Accelerator.Constants;
using Litium.Blocks;
using Litium.FieldFramework;

namespace Litium.Accelerator.Definitions.Blocks
{
    internal class AuthorBlockTemplateSetup : FieldTemplateSetup
    {
        private readonly CategoryService _categoryService;

        public AuthorBlockTemplateSetup(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public override IEnumerable<FieldTemplate> GetTemplates()
        {
            var pageCategoryId = _categoryService.Get(BlockCategoryNameConstants.Pages)?.SystemId ?? Guid.Empty;

            var templates = new List<FieldTemplate>
            {
                new BlockFieldTemplate(BlockTemplateNameConstants.Author)
                {
                    CategorySystemId = pageCategoryId,
                    Icon = "fas fa-image",
                    FieldGroups = new List<FieldTemplateFieldGroup>
                    {
                        new()
                        {
                            Id = "General",
                            Collapsed = false,
                            Fields =
                            {
                                SystemFieldDefinitionConstants.Name,
                                BlockFieldNameConstants.LinkToPage
                            }
                        }
                    }
                }
            };

            return templates;
        }
    }
}