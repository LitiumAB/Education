using System;
using System.Collections.Generic;

namespace Litium.Accelerator.Services;

public class AuthorServiceImpl : IAuthorService
{
    public List<string> GetBooksByAuthor(Guid authorPageId)
    {
        // The authorPageId-parameter is used in the later Data Service task
        // to get actual books by id from PIM 

        return new List<string>
        {
            "Ready player one",
            "Armada"
        };
    }
}