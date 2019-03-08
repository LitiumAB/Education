using System.Collections.Generic;
using AutoMapper;
using JetBrains.Annotations;
using Litium.Accelerator.Builders;
using Litium.Runtime.AutoMapper;
using Litium.Web.Models;
using Litium.Web.Models.Blocks;

namespace Litium.Accelerator.ViewModels.Block
{
	public class AuthorBlockViewModel : IViewModel, IAutoMapperConfiguration
	{
		public string Author { get; set; }
		public string Description { get; set; }
		public ImageModel Image { get; set; }
		public List<string> Books { get; set; }

		[UsedImplicitly]
		void IAutoMapperConfiguration.Configure(IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<BlockModel, AuthorBlockViewModel>();
		}
	}
}