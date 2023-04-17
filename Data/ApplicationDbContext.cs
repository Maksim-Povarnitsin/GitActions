using Microsoft.EntityFrameworkCore;
using LabMiAu.Models;

namespace LabMiAu.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
              
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Firms { get; set; }
    }
}
