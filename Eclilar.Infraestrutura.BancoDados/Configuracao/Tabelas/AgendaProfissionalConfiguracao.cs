using Eclilar.Dominio.Entidades.Profissional;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Tabelas
{
    public class AgendaProfissionalConfiguracao : IEntityTypeConfiguration<Agenda>
    {

        public void Configure(EntityTypeBuilder<Agenda> builder)
        {

            builder.HasNoKey();

            builder.Property(e => e.AtendimentosId)
            .HasColumnName("atendimentos_id");

            builder.Property(e => e.AtendimentoData)
            .HasColumnName("atendimento_data");

            builder.Property(e => e.UserName)
            .HasColumnName("user_name");

            builder.Property(e => e.UserImage)
             .HasColumnName("user_image");

            builder.Property(e => e.MinAtendimento)
             .HasColumnName("min_atendimento");

            builder.Property(e => e.AtendimentoStatus)
             .HasColumnName("atendimento_status");

            builder.Property(e => e.atendimentoHora)
                       .HasColumnName("atendimento_hora");

            builder.Property(e => e.addressLocation)
           .HasColumnName("address_location");

        }

    }
}