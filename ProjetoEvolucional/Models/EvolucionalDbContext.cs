using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoEvolucional.Models
{
    public class EvolucionalDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplina { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public EvolucionalDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EvolucionalDbContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(255));

            modelBuilder.Entity<Aluno>().HasKey(a => a.Id);
            modelBuilder.Entity<Disciplina>().HasKey(d => d.Id);
            modelBuilder.Entity<Usuario>().HasKey(d => d.Id);
        }
    }
}