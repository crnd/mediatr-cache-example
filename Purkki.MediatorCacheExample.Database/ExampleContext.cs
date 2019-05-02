using Microsoft.EntityFrameworkCore;
using Purkki.MediatorCacheExample.Database.Entities;

namespace Purkki.MediatorCacheExample.Database
{
	public class ExampleContext : DbContext
	{
		public ExampleContext(DbContextOptions<ExampleContext> options) : base(options) { }

		public DbSet<Car> Cars { get; set; }
	}
}
