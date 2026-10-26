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
}