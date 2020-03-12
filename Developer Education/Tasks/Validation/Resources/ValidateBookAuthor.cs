using System;
using Litium.FieldFramework;
using Litium.Products;
using Litium.Validations;
using Litium.Websites;

namespace Litium.Accelerator.ValidationRules
{
	public class ValidateBookAuthor : ValidationRuleBase<BaseProduct>
	{
		private readonly FieldTemplateService _fieldTemplateService;
		private readonly PageService _pageService;

		public ValidateBookAuthor(PageService pageService, FieldTemplateService fieldTemplateService)
		{
			_pageService = pageService;
			_fieldTemplateService = fieldTemplateService;
		}

		public override ValidationResult Validate(BaseProduct entity, ValidationMode validationMode)
		{
			var authorPageId = entity.Fields.GetValue<Guid>("AuthorField");

			var result = new ValidationResult();
			if (authorPageId == Guid.Empty)
				return result;

			var authorPage = _pageService.Get(authorPageId);
			if (authorPage == null)
				return result;

			var pageFieldTemplate = _fieldTemplateService.Get<FieldTemplate>(authorPage.FieldTemplateSystemId);
			var isAuthorTemplate = pageFieldTemplate.Id.Equals("Author");
			if (!isAuthorTemplate)
				result.AddError("Author", "Only Author-pages can be selected as author");

			return result;
		}
	}
}