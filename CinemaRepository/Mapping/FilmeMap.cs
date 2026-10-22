using CinemaDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaRepository.Mapping
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("MOVIE");
            builder.HasKey(x => x.Nome);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("NOME");
            builder.Property(x => x.Duracao).IsRequired().HasColumnName("DURACAO");
            builder.HasOne(x => x.Genero).WithMany().IsRequired(true); //relacionamento com gênero
        }
    }
}
