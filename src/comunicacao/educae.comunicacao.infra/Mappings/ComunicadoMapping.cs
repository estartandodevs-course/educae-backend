using educae.comunicacao.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educae.comunicacao.infra.Mappings;

public class ComunicadoMapping : IEntityTypeConfiguration<Comunicado>
{
    public void Configure(EntityTypeBuilder<Comunicado> builder)
    {
        builder.ToTable("Comunicados");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Titulo).HasColumnName("Titulo").IsRequired();
        builder.Property(x => x.Descricao).HasColumnName("Descricao").IsRequired();
        builder.Property(x => x.Imagem).HasColumnName("Imagem").IsRequired();
        builder.Property(x => x.DataExpiracao).HasColumnName("DataExpiracao").IsRequired();
    }
}