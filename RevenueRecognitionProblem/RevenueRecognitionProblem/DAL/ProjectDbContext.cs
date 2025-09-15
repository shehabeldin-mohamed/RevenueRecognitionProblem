using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RevenueRecognitionProblem.Models;

namespace RevenueRecognitionProblem.DAL;

public class ProjectDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<IndividualClient>  IndividualClients { get; set; }
    public DbSet<CompanyClient> CompanyClients { get; set; }

    protected ProjectDbContext()
    {
    }

    public ProjectDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().UseTpcMappingStrategy();
        
        modelBuilder.Entity<IndividualClient>(entity =>
        {
            entity.HasIndex(i => i.Pesel).IsUnique();
            
            entity.Property(i => i.Pesel)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
        });
        
        modelBuilder.Entity<CompanyClient>(entity =>
        {
            entity.HasIndex(cc => cc.Krs).IsUnique();
            
            entity.Property(cc => cc.Krs)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
            
        });
    }
}