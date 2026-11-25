using CinemaDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaRepository.Mapping
{
    public class IngressoItemMap : IEntityTypeConfiguration<Ingresso>, IEntityTypeConfiguration<IngressoItem>
    {
        public void Configure(EntityTypeBuilder<Ingresso> builder)
        {
            builder.ToTable("INGRESSO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Documento);
            builder.Property(x => x.DataCompra);
            builder.Property(x => x.ValorTotal);
            builder.Property(x => x.FormaPagamento);

            builder.HasOne(x => x.Sessao)
                   .WithMany();

            builder.HasMany(x => x.IngressoItens)
                   .WithOne(x => x.Ingresso)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<IngressoItem> builder)
        {
            builder.ToTable("INGRESSO_ITEM");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Assento);
            builder.Property(x => x.Fileira);
            builder.Property(x => x.MeiaEntrada);

            builder.HasOne(x => x.Ingresso)
                   .WithMany(x => x.IngressoItens)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}