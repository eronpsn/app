using Eclilar.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Tabelas
{
    public class ProfissionalConfiguracao: IEntityTypeConfiguration<ProfissionalModel>
    {
        public void Configure(EntityTypeBuilder<ProfissionalModel> builder)
        {
            builder.ToTable("professional");

                builder.HasKey(e => e.ProfessionalId)
                .HasName("AI");

            builder.Property(e => e.ProfessionalId)
                .HasColumnName("professional_id");

            builder.Property(e => e.ProfessionalName)
                .HasColumnName("professional_name");

            builder.Property(e => e.ProfessionalEmail)
                .HasColumnName("professional_email");

             builder.Property(e => e.ProfessionalPhone)
                .HasColumnName("professional_phone");    

            builder.Property(e => e.ProfessionalPassword)
                .HasColumnName("professional_password");        

            builder.Property(e => e.ProfessionalDescription)
                .HasColumnName("professional_description");

            builder.Property(e => e.ProfessionalImage)
            .HasColumnName("professional_image");

            builder.Property(e => e.Rating)
            .HasColumnName("rating");

             builder.Property(e => e.CompletedAttendance)
            .HasColumnName("completed_attendance");

             builder.Property(e => e.ProfessionalValueVisit)
            .HasColumnName("professional_value_visit");

             builder.Property(e => e.ProfessionalExperience)
            .HasColumnName("professional_experience");

             builder.Property(e => e.ProfessionalFormation)
            .HasColumnName("professional_formation");

             builder.Property(e => e.CityId)
            .HasColumnName("city_id");

             builder.Property(e => e.ProfessionalAdminStatus)
            .HasColumnName("professional_admin_status");

             builder.Property(e => e.RegisterDate)
            .HasColumnName("register_date");

             builder.Property(e => e.ProfessionalSignupDate)
            .HasColumnName("professional_signup_date");
        }

    }
}