using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst
{
    public class AccessCorpContext : DbContext
    {
        public AccessCorpContext() : base("databaseAccessCorp")
        {
            System.Data.Entity.Database.SetInitializer<AccessCorpContext>(new AccessCorpInitializer());
        }
        
        public DbSet<FormularioDomain> FormularioDomain { get; set; }
        public DbSet<FormularioCampoDomain> FormularioCampoDomain { get; set; }
        public DbSet<TipoCampoDomain> TipoCampoDomain { get; set; }
        public DbSet<TipoValorCampoDomain> TipoValorCampoDomain { get; set; }
        public DbSet<ValorCampoDomain> ValorCampoDomain { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            MapperFormulario(modelBuilder);
            MapperFormularioCampo(modelBuilder);
            MapperTipoValorCampo(modelBuilder);
            MapperTipoCampo(modelBuilder);
            MapperValorCampo(modelBuilder);
        }

        private void MapperTipoCampo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoCampoDomain>()
               .ToTable("TBL_TIPO_CAMPO")
               .HasKey(tc => tc.IdTipoCampo)
               .Property(tc => tc.IdTipoCampo).HasColumnAnnotation("Idx_IdTipoCampo", new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<TipoCampoDomain>()
                .Property(t => t.NomeTipoCampo).IsRequired().HasMaxLength(25);
        }

        private void MapperTipoValorCampo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoValorCampoDomain>()
                 .ToTable("TBL_TIPO_VALOR_CAMPO")
               .HasKey(tc => tc.IdTipoValorCampo)
               .Property(tc => tc.IdTipoValorCampo).HasColumnAnnotation("Idx_IdTipoValorCampo", new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<TipoValorCampoDomain>()
                .Property(t => t.NomeTipoValorCampo).IsRequired().HasMaxLength(25);
        }

        private void MapperFormulario(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormularioDomain>()
                .ToTable("TBL_FORMULARIO")
               .HasKey(tc => tc.IdFormulario)
               .Property(tc => tc.IdFormulario).HasColumnAnnotation("Idx_FormularioId", new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<FormularioDomain>().Property(t => t.NomeFormulario).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<FormularioDomain>().Property(t => t.DescricaoFormulario).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<FormularioDomain>().Property(t => t.DataVencimentoInicio).IsRequired();
            modelBuilder.Entity<FormularioDomain>().Property(t => t.DataVencimentoFim).IsRequired();
        }

        private void MapperValorCampo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValorCampoDomain>()
                .ToTable("TBL_VALOR_CAMPO")
               .HasKey(tc => tc.IdValorCampo)
               .Property(tc => tc.IdValorCampo).HasColumnAnnotation("Idx_IdValorCampo", new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<ValorCampoDomain>().Property(t => t.ValorCampo).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<ValorCampoDomain>()
               .HasRequired<FormularioCampoDomain>(vc => vc.Formulario)
                .WithMany(g => g.ValorCampoes)
                .HasForeignKey<int>(s => s.IdFormularioCampo);
        }

        private void MapperFormularioCampo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormularioCampoDomain>()
                 .ToTable("TBL_FORMULARIO_CAMPOS")
             .HasKey(tc => tc.IdFormularioCampo)
               .Property(tc => tc.IdFormularioCampo).HasColumnAnnotation("Idx_IdFormularioCampo", new IndexAnnotation(new IndexAttribute()));

            modelBuilder.Entity<FormularioCampoDomain>()
               .Property(t => t.DescricaoCampo).IsRequired().HasMaxLength(30);

            modelBuilder.Entity<FormularioCampoDomain>()
            .HasRequired<FormularioDomain>(vc => vc.Formulario)
             .WithMany(g => g.FormularioCampoes)
             .HasForeignKey<int>(s => s.IdFormulario);

            modelBuilder.Entity<FormularioCampoDomain>()
            .HasRequired<TipoValorCampoDomain>(vc => vc.TipoValorCampo)
             .WithMany(g => g.FormularioCampoes)
             .HasForeignKey<int>(s => s.IdTipoValorCampo);

            modelBuilder.Entity<FormularioCampoDomain>()
            .HasRequired<TipoCampoDomain>(vc => vc.TipoCampo)
             .WithMany(g => g.FormularioCampoes)
             .HasForeignKey<int>(s => s.IdTipoCampo);
        }
     }
}