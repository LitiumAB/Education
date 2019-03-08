using System;
using System.Collections.Generic;

namespace Litium.Accelerator.Services
{
	public class AuthorService : IAuthorService
	{
		public List<string> GetBooksByAuthor(Guid authorPageId)
		{
			return new List<string>
			{
				"Ready player one",
				"Armada"
			};
		}
	}
}