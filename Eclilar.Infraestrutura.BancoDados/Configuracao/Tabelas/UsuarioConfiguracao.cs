using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Eclilar.Dominio.Entidades;

namespace Eclilar.Infraestrutura.BancoDados.Configuracao.Visoes {
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario> {

        public void Configure(EntityTypeBuilder<Usuario> builder) {
            builder.HasKey(e => e.UserId)
                .HasName("AI");

            builder.ToTable("user");

            builder.Property(e => e.UserId)
            .ValueGeneratedOnAdd()
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("user_id");

            builder.Property(e => e.UserName)
                .HasColumnName("user_name");

            builder.Property(e => e.UserEmail)
                .HasColumnName("user_email");

            builder.Property(e => e.UserPhone)
                .HasColumnName("user_phone");
            
            builder.Property(e => e.UserImage)
                .HasColumnName("user_image");   

            builder.Property(e => e.DataNasc)
                .HasColumnName("data_nasc");      

           builder.Property(e => e.UserPassword)
                .HasColumnName("user_password"); 

            builder.Property(e => e.RegisterDate)
                .HasColumnName("register_date");  

             builder.Property(e => e.UserSignupDate)
                .IsUnicode(false)
                .HasColumnName("user_signup_date");             
        }
    }
}
