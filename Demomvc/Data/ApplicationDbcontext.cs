using Microsoft.EntityFrameworkCore;

using Demomvc.Models;

namespace Demomvc.Data

{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options) {}
        public DbSet<Person> Person { get; set;}
    }
}