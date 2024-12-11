using educae.comunicacao.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educae.comunicacao.infra.Mappings;

public class SolicitacaoFeedBackMapping : IEntityTypeConfiguration<SolicitacaoFeedback>
{
    public void Configure(EntityTypeBuilder<SolicitacaoFeedback> builder)
    {
        builder.ToTable("SolicitacoesFeedBack");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Assunto).HasColumnName("Assunto").IsRequired();
        builder.Property(x => x.Conteudo).HasColumnName("Conteudo").IsRequired();
        
        builder.OwnsOne(c => c.EducadorDestinatario, usuario =>
        {
            usuario.Property(x => x.Id).HasColumnName("UsuarioDestinatarioId").IsRequired();
            usuario.Property(x => x.Nome).HasColumnName("UsuarioDestinatarioNome").IsRequired();
            usuario.Property(x => x.Foto).HasColumnName("UsuarioDestinatarioFoto").IsRequired();
        });
        
        builder.OwnsOne(c => c.AlunoRementente, usuario =>
        {
            usuario.Property(x => x.Id).HasColumnName("UsuarioRemetenteId");
            usuario.Property(x => x.Nome).HasColumnName("UsuarioRemetenteNome");
            usuario.Property(x => x.Foto).HasColumnName("UsuarioRemetenteFoto");
        });
        
        builder.Property(x => x.EnvioAnonimo).HasColumnName("EnvioAnonimo");
        builder.Property(x => x.Aberta).HasColumnName("Aberta");
        
        builder.OwnsOne(c => c.Resposta, resposta =>
        {
            resposta.Property(x => x.Resposta).HasColumnName("Resposta");
            resposta.Property(x => x.DataResposta).HasColumnName("DataResposta");
        });
    }
}