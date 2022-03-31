using CRUD.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace CRUD
{
    public class CRUDContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var mapCond = modelBuilder.Entity<Condominio>();
            mapCond.HasKey(x => x.Id);
            mapCond.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            mapCond.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(25);
            mapCond.Property(x => x.Bairro)
                .IsOptional()
                .HasMaxLength(25);
            mapCond.ToTable("Condominio");

            var mapFam = modelBuilder.Entity<Familia>();
            mapFam.HasKey(x => x.Id);
            mapFam.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            mapFam.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(25);
            mapFam.HasRequired<Condominio>(x => x.Condominio)
                .WithMany(x => x.Familias)
                .HasForeignKey<int>(x => x.Id_Condominio);
            mapFam.Property(x => x.Apto)
                .HasColumnOrder(int.MaxValue);
            mapFam.ToTable("Familia");

            var mapMor = modelBuilder.Entity<Morador>();
            mapMor.HasKey(x => x.Id);
            mapMor.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            mapMor.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(25);
            mapMor.HasRequired<Familia>(x => x.Familia)
                .WithMany(x => x.Moradores)
                .HasForeignKey<int>(x => x.Id_Familia);
            mapMor.Property(x => x.Idade)
                .HasColumnOrder(int.MaxValue);
            mapMor.ToTable("Morador");
        }
        public System.Data.Entity.DbSet<CRUD.Model.Condominio> Codominio { get; set; }
        public System.Data.Entity.DbSet<CRUD.Model.Familia> Familia { get; set; }
        public System.Data.Entity.DbSet<CRUD.Model.Morador> Morador { get; set; }
    }
}
