using Eclilar.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Tabelas
{
    public class VisualizaAtendimentoConfiguracao : IEntityTypeConfiguration<VisualizaAtendimento>
    {

        public void Configure(EntityTypeBuilder<VisualizaAtendimento> builder)
        {

            builder.HasNoKey();

            builder.Property(e => e.AtendimentosId)
            .HasColumnName("atendimentos_id");

            builder.Property(e => e.UserId)
            .HasColumnName("user_id");

            builder.Property(e => e.CouponCode)
            .HasColumnName("coupon_code");

            builder.Property(e => e.AddressLat)
            .HasColumnName("address_lat");

            builder.Property(e => e.AddressLong)
            .HasColumnName("address_long");

            builder.Property(e => e.AddressLocation)
            .HasColumnName("address_location");

            builder.Property(e => e.AtendimentoData)
            .HasColumnName("atendimento_data");

            builder.Property(e => e.AtendimentoHora)
            .HasColumnName("atendimento_hora");

            builder.Property(e => e.LastTimeStamp)
            .HasColumnName("last_time_stamp");

            builder.Property(e => e.LaterDate)
            .HasColumnName("later_date");

            builder.Property(e => e.LaterTime)
            .HasColumnName("later_time");

            builder.Property(e => e.ProfessionalId)
            .HasColumnName("professional_id");

            builder.Property(e => e.CityId)
            .HasColumnName("city_id");

            builder.Property(e => e.SpecialtyId)
            .HasColumnName("specialty_id");

            builder.Property(e => e.CategoryId)
            .HasColumnName("category_id");

            builder.Property(e => e.PemFile)
            .HasColumnName("pem_file");

            builder.Property(e => e.AtendimentoStatus)
            .HasColumnName("atendimento_status");

            builder.Property(e => e.PaymentStatus)
            .HasColumnName("payment_status");

            builder.Property(e => e.ReasonId)
            .HasColumnName("reason_id");

            builder.Property(e => e.PaymentOptionId)
            .HasColumnName("payment_option_id");

            builder.Property(e => e.CardId)
            .HasColumnName("card_id");

            builder.Property(e => e.AtendimentoPlatform)
            .HasColumnName("atendimento_platform");

            builder.Property(e => e.SolicitacaoAdminStatus)
            .HasColumnName("solicitacao_admin_status");

            builder.Property(e => e.Date)
           .HasColumnName("date");

            builder.Property(e => e.ProfessionalName)
            .HasColumnName("professional_name");

            builder.Property(e => e.ProfessionalDescription)
            .HasColumnName("professional_description");

            builder.Property(e => e.ProfessionalImage)
            .HasColumnName("professional_image");

            builder.Property(e => e.ValorConsulta)
           .HasColumnName("valor_consulta");

            builder.Property(e => e.Sintomas)
            .HasColumnName("sintomas");

            builder.Property(e => e.Data)
            .HasColumnName("data");

            builder.Property(e => e.MotivoCancelamento)
            .HasColumnName("motivo_cancelamento");

        }

    }
}