using CinemaDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaRepository.Mapping
{
    public class SessaoMap : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("SESSAO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("NOME");

        }
    }
}