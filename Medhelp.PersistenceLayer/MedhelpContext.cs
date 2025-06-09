using Medhelp.Domain.Entities;
using Medhelp.PersistenceLayer.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Medhelp.PersistenceLayer;

public class MedhelpContext : DbContext
{
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<DiseaseGroup> DiseaseGroups { get; set; }
    public DbSet<ActiveSubstance> ActiveSubstances { get; set; }
    public DbSet<DrugAction> DrugActions { get; set; }
    public DbSet<DrugForm> DrugForms { get; set; }
    public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
    public DbSet<OrganSystem> OrganSystems { get; set; }
    public DbSet<ParsedElementsCounter> ParsedElementsCounters { get; set; }
    
    public MedhelpContext(DbContextOptions<MedhelpContext> options)
        : base(options)
    {
    }

    public MedhelpContext()
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("<connection string>");
        }
        
        optionsBuilder.AddInterceptors(new EntityDatesInterceptor());
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Medicine>()
            .HasMany(m => m.ActiveSubstances)
            .WithMany(a => a.Medicines)
            .UsingEntity(j => j.ToTable("MedicineActiveSubstances"));
            
        modelBuilder.Entity<Medicine>()
            .HasMany(m => m.DrugActions)
            .WithMany(d => d.Medicines)
            .UsingEntity(j => j.ToTable("MedicineDrugActions"));
            
        modelBuilder.Entity<Medicine>()
            .HasMany(m => m.DrugForms)
            .WithMany(d => d.Medicines)
            .UsingEntity(j => j.ToTable("MedicineDrugForms"));
            
        modelBuilder.Entity<Medicine>()
            .HasMany(m => m.MedicalSpecialties)
            .WithMany(m => m.Medicines)
            .UsingEntity(j => j.ToTable("MedicineMedicalSpecialties"));
            
        modelBuilder.Entity<Medicine>()
            .HasMany(m => m.OrganSystems)
            .WithMany(o => o.Medicines)
            .UsingEntity(j => j.ToTable("MedicineOrganSystems"));
            
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedhelpContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}
