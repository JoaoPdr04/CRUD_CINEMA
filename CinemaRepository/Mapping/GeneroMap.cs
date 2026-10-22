using CinemaDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaRepository.Mapping
{
    public class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("EXEMPLO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("NOME");
        }
    }
}