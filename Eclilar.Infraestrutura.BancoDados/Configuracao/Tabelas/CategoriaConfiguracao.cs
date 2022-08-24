using Eclilar.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Tabelas
{
    public class CategoriaConfiguracao: IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("category");

            builder.HasNoKey();

            builder.Property(e => e.CategoriaId)
                .HasColumnName("category_id");

            builder.Property(e => e.SpecialtyId)
                .HasColumnName("specialty_id");

            builder.Property(e => e.CategoryName)
                .HasColumnName("category_name");

            builder.Property(e => e.CategoryStatus)
            .HasColumnName("category_status");

          
        }

    }
}