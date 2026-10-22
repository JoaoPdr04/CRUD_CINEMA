using CinemaDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaRepository.Mapping
{
    public class SalaMap : IEntityTypeConfiguration<Sala>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("SALA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Capacidade).IsRequired().HasColumnName("CAPACIDADE");
            builder.Property(x => x.Numero).IsRequired().HasColumnName("NUMERO");
            builder.Property(x => x.Fileiras).IsRequired().HasColumnName("FILEIRAS");
            builder.Property(x => x.Assentos).IsRequired().HasColumnName("ASSENTOS");
        }
    }
}