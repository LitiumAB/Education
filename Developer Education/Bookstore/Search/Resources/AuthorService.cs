public List<Tuple<string, Guid>> GetAuthors()
{
    var authorPageTemplate = _fieldTemplateService.Get<FieldTemplate>(typeof(WebsiteArea), "Author");

    var request = new QueryRequest(CultureInfo.CurrentCulture, CmsSearchDomains.Pages);
    request.FilterTags.Add(new Tag(TagNames.TemplateId, authorPageTemplate.Id));
    var searchResult = _solution.SearchService.Search(request);

    if(searchResult.Hits.Count == 0)
        throw new Exception("No authors found");

    var result = new List<Tuple<string, Guid>>();
    foreach (var hit in searchResult.Hits)
    {
        var authorPage = _pageService.Get(new Guid(hit.Id));
        result.Add(new Tuple<string, Guid>(authorPage.Localizations.CurrentUICulture.Name, authorPage.SystemId));
    }

    return result;
}