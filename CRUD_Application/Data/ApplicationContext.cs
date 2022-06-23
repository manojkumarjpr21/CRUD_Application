using CRUD_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }  
    }
}
