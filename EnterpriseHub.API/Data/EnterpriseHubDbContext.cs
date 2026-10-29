using EnterpriseHub.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseHub.API.Data;

public class EnterpriseHubDbContext : DbContext
{
    public EnterpriseHubDbContext(DbContextOptions<EnterpriseHubDbContext> options)
    : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Employee>().Property(e=>e.Salary).HasPrecision(18,2);
        //OR
        modelBuilder.Entity<Employee>(entity => {
            //To change the table name
            entity.ToTable("Employees");


            entity.Property(e => e.Salary)
                    .HasPrecision(18,2);
        });
    }
}