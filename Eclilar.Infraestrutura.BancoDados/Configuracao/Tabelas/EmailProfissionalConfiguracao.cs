using Eclilar.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Tabelas
{
    public class EmailProfissionalConfiguracao: IEntityTypeConfiguration<EmailProfissionalModel>
    {
        public void Configure(EntityTypeBuilder<EmailProfissionalModel> builder)
        {
            builder.ToTable("professional");

                builder.HasNoKey();

            builder.Property(e => e.ProfessionalId)
                .HasColumnName("professional_id");          

            builder.Property(e => e.ProfessionalEmail)
                .HasColumnName("professional_email");

        }

    }
}