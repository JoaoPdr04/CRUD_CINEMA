using CinemaDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaRepository.Mapping
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("MOVIE");
            builder.HasKey(x => x.Nome);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("NOME");
            builder.Property(x => x.Duracao).IsRequired().HasColumnName("DURACAO");
            builder.Property(x => x.Genero).WithMany().IsRequired(); //relacionamento com gênero

        }
    }
}
