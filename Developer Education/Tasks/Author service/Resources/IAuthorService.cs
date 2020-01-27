using System;
using System.Collections.Generic;
using Litium.Runtime.DependencyInjection;

namespace Litium.Accelerator.Services
{
	[Service(ServiceType = typeof(IAuthorService), Lifetime = DependencyLifetime.Transient)]
	public interface IAuthorService
	{
		List<string> GetBooksByAuthor(Guid authorPageId);
	}
}