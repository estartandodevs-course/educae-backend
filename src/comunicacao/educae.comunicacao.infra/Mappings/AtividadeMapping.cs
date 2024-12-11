using educae.comunicacao.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educae.comunicacao.infra.Mappings;

public class AtividadeMapping : IEntityTypeConfiguration<Atividade>
{
    public void Configure(EntityTypeBuilder<Atividade> builder)
    {
        builder.ToTable("Atividades");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Titulo).HasColumnName("Titulo").IsRequired();
        builder.Property(x => x.Descricao).HasColumnName("Descricao").IsRequired();
        builder.Property(X => X.DataMaximaEntrega).HasColumnName("DataMaximaEntrega").IsRequired();
        builder.Property(x => x.AvaliacaoDaExecucao).HasColumnName("AvaliacaoDaExecucao");
        builder.Property(x => x.Feito).HasColumnName("Feito");
    }
}