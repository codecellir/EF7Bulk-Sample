using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCore7Bulk
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (databaseCreator is not null)
            {
                if (!databaseCreator.CanConnect())
                {
                    databaseCreator.Create();
                }
                if (!databaseCreator.HasTables())
                {
                    databaseCreator.CreateTables();
                }
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFBulk;Integrated Security=False;TrustServerCertificate=True;User ID=sa;Password=@sohrab5552GH")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        public DbSet<Person> People { get; set; }
    }
}
