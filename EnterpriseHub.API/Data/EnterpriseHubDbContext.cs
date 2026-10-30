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
    public DbSet<Department> Departments => Set<Department>();

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

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.DepartmentDetails)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}