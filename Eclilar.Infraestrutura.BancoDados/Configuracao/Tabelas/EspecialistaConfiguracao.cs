using Eclilar.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Tabelas
{
    public class EspecialistaConfiguracao : IEntityTypeConfiguration<Especialista>
    {
        public void Configure(EntityTypeBuilder<Especialista> builder)
        {
            builder.ToTable("specialty");

            builder.HasNoKey();

            builder.Property(e => e.SpecialtyId)
                .HasColumnName("specialty_id");

            builder.Property(e => e.SpecialtyName)
                .HasColumnName("specialty_name");

            builder.Property(e => e.SpecialtyImage)
                .HasColumnName("specialty_image");

            builder.Property(e => e.SpecialtyCategory)
            .HasColumnName("specialty_category");

            builder.Property(e => e.SpecialtyStatus)
            .HasColumnName("specialty_status");
        }


    }
}