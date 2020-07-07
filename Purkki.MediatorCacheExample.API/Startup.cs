using Autofac;
using Microsoft.AspNetCore.Builder;
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

			services.AddControllers(o => o.Filters.Add(typeof(CustomExceptionFilter)));
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule(new AutofacModule());
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
