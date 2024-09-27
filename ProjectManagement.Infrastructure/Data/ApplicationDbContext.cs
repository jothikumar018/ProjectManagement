using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tenant>().HasQueryFilter(x => x.IsDeleted == false);
        modelBuilder.Entity<Enumerations>().HasQueryFilter(x => x.IsDeleted == false);
        modelBuilder.Entity<Customer>().HasQueryFilter(x => x.IsDeleted == false);
        modelBuilder.Entity<Project>().HasQueryFilter(x => x.IsDeleted == false);

        //modelBuilder.Entity<Customer>(entity =>
        //{
        //    entity.HasQueryFilter(x => x.IsDeleted == false)
        //          .HasMany(x => x.Projects)
        //          .WithOne()
        //          .HasForeignKey(x => x.CustomerId);
        //});

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Tenant> Tenant { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Project> Project { get; set; }
    public DbSet<Enumerations> Enumerations { get; set; }
}
