using Eclilar.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Tabelas
{
    public class AtendimentoConfiguracao : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.HasKey(e => e.AtendimentosId)
                .HasName("AI");

            builder.ToTable("atendimentos");

             builder.Property(e => e.AtendimentosId)
             .ValueGeneratedOnAdd()
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("atendimentos_id");

            builder.Property(e => e.UserId)
                .IsUnicode(false)
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
               .IsUnicode(false)
               .HasColumnName("last_time_stamp");

            builder.Property(e => e.LaterDate)
           .IsUnicode(false)
           .HasColumnName("later_date");

            builder.Property(e => e.LaterTime)
           .IsUnicode(false)
           .HasColumnName("later_time");

            builder.Property(e => e.ProfessionalId)
           .IsUnicode(false)
           .HasColumnName("professional_id");

            builder.Property(e => e.CityId)
           .IsUnicode(false)
           .HasColumnName("city_id");

            builder.Property(e => e.SpecialtyId)
           .IsUnicode(false)
           .HasColumnName("specialty_id");

            builder.Property(e => e.CategoryId)
           .IsUnicode(false)
           .HasColumnName("category_id");

            builder.Property(e => e.AtendimentoStatus)
           .IsUnicode(false)
           .HasColumnName("atendimento_status");

            builder.Property(e => e.PaymentStatus)
           .IsUnicode(false)
           .HasColumnName("payment_status");

            builder.Property(e => e.PaymentOptionId)
           .IsUnicode(false)
           .HasColumnName("payment_option_id");

            builder.Property(e => e.CardId)
           .IsUnicode(false)
           .HasColumnName("card_id");

            builder.Property(e => e.AtendimentoPlatform)
           .IsUnicode(false)
           .HasColumnName("atendimento_platform");

            builder.Property(e => e.SolicitacaoAdminStatus)
           .IsUnicode(false)
           .HasColumnName("solicitacao_admin_status");

            builder.Property(e => e.Date)
           .IsUnicode(false)
           .HasColumnName("date");

            builder.Property(e => e.ValorConsulta)
           .IsUnicode(false)
           .HasColumnName("valor_consulta");

            builder.Property(e => e.Sintomas)
           .IsUnicode(false)
           .HasColumnName("sintomas");

            builder.Property(e => e.MotivoCancelamento)
           .IsUnicode(false)
           .HasColumnName("motivo_cancelamento");

           builder.Property(e => e.ObservacaoAtendimento)
           .IsUnicode(false)
           .HasColumnName("observacao_atendimento");
        }


    }
}