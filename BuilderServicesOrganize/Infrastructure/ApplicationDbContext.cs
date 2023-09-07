using BuilderServicesOrganize.Model;
using Microsoft.EntityFrameworkCore;

namespace BuilderServicesOrganize.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
