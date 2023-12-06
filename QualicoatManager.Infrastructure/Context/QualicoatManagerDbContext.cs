using Microsoft.EntityFrameworkCore;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.Infrastructure.Context
{
    public class QualicoatManagerDbContext : DbContext
    {
        public QualicoatManagerDbContext(DbContextOptions<QualicoatManagerDbContext> options) : base(options)
        {

        }

        public DbSet<FormulationsFolder> FormulationsFolders { get; set; }
        public DbSet<Formulation> Formulations { get; set; }
        public DbSet<FormulationItem> FormulationItems { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Assessment> Assesments { get; set; }
        public DbSet<AssessmentsGroup> AssesmentsGroup { get; set; }
        public DbSet<BaseUser> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RawMaterial>().HasData(
                new RawMaterial { Id = 1, Name = "Resina M-8930", Description = "Polyester TGIC 93/3 ratio from Reichhold.", Category = RawMaterialCategory.Resin },
                new RawMaterial { Id = 2, Name = "TGIC", Description = "Regular tgic made in China", Category = RawMaterialCategory.CuringAgent},
                new RawMaterial { Id = 3, Name = "Flow agent", Description = "Regular agent made in China" , Category = RawMaterialCategory.Additive},
                new RawMaterial { Id = 4, Name = "TiO2", Description = "Basic TiO2", Category = RawMaterialCategory.Pigment},
                new RawMaterial { Id = 5, Name = "BaSO4", Description = "Brasil Minas", Category = RawMaterialCategory.Filler },
                new RawMaterial { Id = 6, Name = "Negro de Fumo", Description = "Carbon Powder", Category = RawMaterialCategory.Pigment}
                );
        }
    }
}
