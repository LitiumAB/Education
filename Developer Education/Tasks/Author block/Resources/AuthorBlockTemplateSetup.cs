using System.Collections.Generic;
using Litium.Accelerator.Constants;
using Litium.Blocks;
using Litium.FieldFramework;

namespace Litium.Accelerator.Definitions.Blocks
{
	internal class AuthorBlockTemplateSetup : FieldTemplateSetup
	{
		public override IEnumerable<FieldTemplate> GetTemplates()
		{
			var templates = new List<FieldTemplate>
			{
				new BlockFieldTemplate(BlockTemplateNameConstants.Author)
				{
					Icon = "fas fa-image",
					FieldGroups = new List<FieldTemplateFieldGroup>
					{
						new FieldTemplateFieldGroup
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