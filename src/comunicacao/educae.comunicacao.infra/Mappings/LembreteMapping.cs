using educae.comunicacao.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educae.comunicacao.infra.Mappings;

public class LembreteMapping : IEntityTypeConfiguration<Lembrete>
{
    public void Configure(EntityTypeBuilder<Lembrete> builder)
    {
        builder.ToTable("Lembretes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Descricao).HasColumnName("Descricao").IsRequired();
        builder.Property(x => x.Concluido).HasColumnName("Concluido");
    }
}