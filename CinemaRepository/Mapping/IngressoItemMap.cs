using CinemaDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaRepository.Mapping
{
    public class IngressoItemMap : IEntityTypeConfiguration<Ingresso>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ingresso> builder)
        {
            builder.ToTable("INGRESSO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCompra);
            builder.Property(x => x.Sessao);
            builder.Property(x => x.ValorTotal);
            builder.Property(x => x.FormaPagamento).HasMaxLenght(100);
            builder.Property(x => x.Ingresso).WithMany(x => x.IngressoItems).OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IngressoItem> builder)
        {
            builder.ToTable("INGRESSO_ITEM");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Assento);
            builder.Property(x => x.Fileira);
            builder.Property(x => x.Ingresso).WithMany(x => x.IngressoItems).OnDelete(DeleteBehavior.Cascade);
        }
    }
}