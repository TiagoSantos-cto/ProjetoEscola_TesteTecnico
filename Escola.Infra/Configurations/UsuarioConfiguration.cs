using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.SobreNome).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("Varchar(255)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("Date").IsRequired();
            builder.HasOne(u => u.Escolaridade).WithOne(e => e.Usuario).HasForeignKey<Usuario>(u => u.EscolaridadeId);         
        }
    }
}
