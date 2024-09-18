using Microsoft.EntityFrameworkCore;

using Demomvc.Models;

namespace Demomvc.Data

{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options) {}
        public DbSet<Person> Person { get; set;}
        public DbSet<Employee> Employee { get; set;}
        public DbSet<Student> Student { get; set;}
    }
}