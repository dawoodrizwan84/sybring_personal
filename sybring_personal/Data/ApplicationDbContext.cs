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

        public DbSet<Billing> Billings { get; set; }
        public DbSet<Consultant> Consultants { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TimeHistory> TimeHistories { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
