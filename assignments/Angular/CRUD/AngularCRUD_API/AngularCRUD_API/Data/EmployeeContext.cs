using AngularCRUD_API.Models;
using Microsoft.EntityFrameworkCore;
namespace AngularCRUD_API.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } 
        
    }
}
