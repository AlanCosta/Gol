using Gol.IO.Domain.Airplane;
using Gol.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Infra.Data.Mappings
{
    public class AirplaneMapping : EntityTypeConfiguration<Airplane>
    {
        public override void Map(EntityTypeBuilder<Airplane> builder)
        {
            builder
                .Property(e => e.CodigoAviao)
                .HasColumnType("varchar(10)")
                .IsRequired();
            builder
                .Property(e => e.Modelo)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder
                .Property(e => e.QtdPassageiros)
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(e => e.DataRegistro)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Ignore(e => e.ValidationResult);
            builder
                .Ignore(e => e.CascadeMode);

            builder
                .ToTable("tb_AirplaneGol");
        }
    }
}
