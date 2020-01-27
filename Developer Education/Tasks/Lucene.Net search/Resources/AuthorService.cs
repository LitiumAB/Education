public List<(Guid, string)> GetAuthors()
{
    // To be simple this example just returns a tuple with data, you can also create a separate model object to return

    var authorPageTemplate = _fieldTemplateService.Get<FieldTemplate>(typeof(WebsiteArea), "Author");

    var request = new QueryRequest(_solution.Languages.DefaultLanguageID, CmsSearchDomains.Pages, _solution.SystemToken);
    request.FilterTags.Add(new Tag(TagNames.TemplateId, authorPageTemplate.Id));
    var searchResult = _solution.SearchService.Search(request);

    if (searchResult.Hits.Count == 0)
        throw new Exception("No authors found");

    var result = new List<(Guid, string)>();
    foreach (var hit in searchResult.Hits)
    {
        var authorPage = _pageService.Get(new Guid(hit.Id));
        result.Add((authorPage.SystemId, authorPage.Localizations.CurrentUICulture.Name));
    }

    return result;
}