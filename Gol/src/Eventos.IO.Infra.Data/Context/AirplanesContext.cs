using Gol.IO.Domain.Airplane;
using Gol.IO.Infra.Data.Extensions;
using Gol.IO.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Gol.IO.Infra.Data.Context
{
    public class AirplanesContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new AirplaneMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("Gol"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
