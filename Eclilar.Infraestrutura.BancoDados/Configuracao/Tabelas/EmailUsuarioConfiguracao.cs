using Eclilar.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Tabelas
{
    public class EmailUsuarioConfiguracao : IEntityTypeConfiguration<EmailUsuarioModel>
    {
        public void Configure(EntityTypeBuilder<EmailUsuarioModel> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.UserId)
                .HasColumnName("user_id");

            builder.Property(e => e.UserEmail)
                .HasColumnName("user_email");

        }

    }
}