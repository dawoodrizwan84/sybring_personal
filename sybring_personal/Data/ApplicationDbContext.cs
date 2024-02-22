using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sybring_personal.Models;

namespace sybring_personal.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Billing> billings { get; set; }
        public DbSet<Consultant> consultants { get; set; }

        public DbSet<Project> projects { get; set; }

        public DbSet<TimeHistory> timeHistories { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
