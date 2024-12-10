using educae.contas.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educae.contas.infra.mappings
{
    public class EducadorMappings : IEntityTypeConfiguration<Educador>
    {
        public void Configure(EntityTypeBuilder<Educador> builder)
        {
            builder.ToTable("Educadores");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.OwnsOne(e => e.CPF, cpf =>
            {
                cpf.Property(c => c.Numero)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsRequired();
            });

            builder.OwnsOne(e => e.Login, login =>
            {
                login.Property(l => l.Hash).HasColumnName("LoginHash");

                login.OwnsOne(l => l.Email, email =>
                {
                    email.Property(e => e.Endereco).HasMaxLength(256).HasColumnName("Email");
                });

                login.OwnsOne(l => l.Senha, senha =>
                {
                    senha.Property(s => s.Valor).HasMaxLength(1000).HasColumnName("Senha");
                });
            });
        }
    }
}