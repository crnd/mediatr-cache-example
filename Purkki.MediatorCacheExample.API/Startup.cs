using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Purkki.MediatorCacheExample.API.Filters;
using Purkki.MediatorCacheExample.Database;

namespace Purkki.MediatorCacheExample.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ExampleContext>(o => o.UseInMemoryDatabase(databaseName: "CacheExample"));

			services.AddMemoryCache();

			services
				.AddMvc(o => o.Filters.Add(typeof(CustomExceptionFilter)))
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule(new AutofacModule());
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}
	}
}
