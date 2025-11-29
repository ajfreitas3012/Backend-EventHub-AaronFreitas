using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // ⚠️ Usa la misma cadena de conexión que tienes en appsettings.json
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=eventhub;Username=postgres;Password=tu_password");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
