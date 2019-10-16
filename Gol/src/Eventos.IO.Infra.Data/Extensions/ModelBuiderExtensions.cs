using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Infra.Data.Extensions
{
    public static class ModelBuiderExtensions
    {
        public static void AddConfiguration<Tentity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<Tentity> configuration) where Tentity : class
        {
            configuration.Map(modelBuilder.Entity<Tentity>());
        }
    }
}
