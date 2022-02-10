using System;
using System.Collections.Generic;
using Litium.Runtime.DependencyInjection;

namespace Litium.Accelerator.Services;

[Service(ServiceType = typeof(IAuthorService), Lifetime = DependencyLifetime.Transient)]
// Add RequireServiceImplementation to not allow Litium to start without an implementation of this interface:
[RequireServiceImplementation]
public interface IAuthorService
{
    List<string> GetBooksByAuthor(Guid authorPageId);
}