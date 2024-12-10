// using educae.contas.domain;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace educae.contas.infra.mappings
// {
//     public class AlunoMappings : IEntityTypeConfiguration<Aluno>
//     {
//         public void Configure(EntityTypeBuilder<Aluno> builder)
//         {
//             builder.ToTable("Alunos");
//
//             builder.HasKey(a => a.Id);
//
//             builder.Property(a => a.Nome)
//                 .IsRequired()
//                 .HasMaxLength(200);
//
//             builder.Property(a => a.Matricula)
//                 .IsRequired()
//                 .HasMaxLength(10);
//
//             builder.OwnsOne(a => a.Login, login =>
//             {
//                 login.Property(l => l.Hash).HasColumnName("LoginHash");
//
//                 login.OwnsOne(l => l.Email, email =>
//                 {
//                     email.Property(e => e.Endereco).HasMaxLength(256).HasColumnName("Email");
//                 });
//
//                 login.OwnsOne(l => l.Senha, senha =>
//                 {
//                     senha.Property(s => s.Valor).HasMaxLength(1000).HasColumnName("Senha");
//                 });
//             });
//         }
//     }
// }