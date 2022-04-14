using System;
using Litium.FieldFramework;
using Litium.Products;
using Litium.Validations;
using Litium.Websites;

namespace Litium.Accelerator.ValidationRules;

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
        var result = new ValidationResult();

        // No need to validate if someone is just trying to delete a product
        if (validationMode == ValidationMode.Remove)
            return result;

        // Get id of the selected page
        var authorPageId = entity.Fields.GetValue<Guid?>("AuthorField");

        // No need to validate if a page has not been selected
        if (authorPageId == null || authorPageId == Guid.Empty)
            return result;

        // No need to validate if page cannot be found (perhaps deleted after property was set?)
        var authorPage = _pageService.Get((Guid)authorPageId);
        if (authorPage == null)
            return result;

        // A page is selected, get its template and make sure it is the 
        // author-template created in the author page task
        var pageFieldTemplate = _fieldTemplateService.Get<FieldTemplate>(authorPage.FieldTemplateSystemId);
        var isAuthorTemplate = pageFieldTemplate.Id.Equals("Author");

        // If author template is used then all is good
        if (isAuthorTemplate)
            return result;

        // An invalid template is selected, add errors to the returned result
        // The first parameter of the AddError-method is used to identify a field to attach
        // the validation message to, pass the id of a field to display the error message
        // next to that field in the UI:
        result.AddError("AuthorField", "Only Author-pages can be selected as author");

        // ...and/or pass "*" to display the validation error in the header.
        result.AddError("*", "Author page validation failed");

        return result;
    }
}