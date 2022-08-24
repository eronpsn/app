using Microsoft.EntityFrameworkCore;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Entidades.Profissional;

namespace Eclilar.Infraestrutura.BancoDados
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco(DbContextOptions<ContextoBanco> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public virtual DbSet<Usuario> TUser { get; set; }
        public virtual DbSet<Especialista> TEspecialista { get; set; }
        public virtual DbSet<ProfissionalModel> TProfissional { get; set; }
        public virtual DbSet<Categoria> TCategoria { get; set; }
        public virtual DbSet<VisualizaAtendimento> TVisuAtendimento { get; set; }
        public virtual DbSet<Atendimento> TSolicitacao { get; set; }
        public virtual DbSet<Agenda> TAgenda { get; set; }
        public virtual DbSet<ProfissionalEspecializacao> TProfiEspecializao { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("eronpsn_eclilar")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoBanco).Assembly);
        }
    }
}
