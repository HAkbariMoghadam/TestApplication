using Domain.Entities;
using System.Data.Entity;

namespace Data
{
	public class DatabaseContext : DbContext
	{
		static DatabaseContext()
		{
			Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>());
		}
		public DatabaseContext()
			: base("TestApplication")
		{
		}

		public DbSet<Currency> Currencies { get; set; }
		public DbSet<Company> Companies { get; set; }
	}
}
