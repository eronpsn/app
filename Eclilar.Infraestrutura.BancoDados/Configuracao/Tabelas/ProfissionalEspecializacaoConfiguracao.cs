using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Eclilar.Dominio.Entidades;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Visoes {
    public class ProfissionalEspecializacaoConfiguracao : IEntityTypeConfiguration<ProfissionalEspecializacao> {

        public void Configure(EntityTypeBuilder<ProfissionalEspecializacao> builder) {
            builder.HasKey(e => e.ProfessionalSpecialtyId)
                .HasName("AI");

            builder.ToTable("professional_specialty");

            builder.Property(e => e.ProfessionalSpecialtyId)
            .ValueGeneratedOnAdd()
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("professional_specialty_id");

            builder.Property(e => e.IdProfessionalId)
                .HasColumnName("id_professional_id");

            builder.Property(e => e.IdSpecialtyId)
                .HasColumnName("id_specialty_id");           
        }
    }
}
