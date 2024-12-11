using educae.biblioteca.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educae.biblioteca.infra.Mappings;

public class CartilhaMapping : IEntityTypeConfiguration<Cartilha>
{
    public void Configure(EntityTypeBuilder<Cartilha> builder)
    {
        builder.ToTable("Cartilhas");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Titulo).HasColumnName("Titulo");
        builder.Property(c => c.Resumo).HasColumnName("Resumo");
        builder.Property(c => c.Descricao).HasColumnName("Descricao");
        builder.Property(c => c.Autor).HasColumnName("Autor");

        builder.OwnsMany(c => c.Anexos, anexo =>
        {
            anexo.WithOwner().HasForeignKey("CartilhaId");
            anexo.Property<Guid>("Id").ValueGeneratedOnAdd();
            anexo.HasKey("Id");

            anexo.Property(c => c.NomeArquivo).HasColumnName("NomeArquivo");
            anexo.Property(c => c.NomeOriginal).HasColumnName("NomeOriginal");
        });
    }
}