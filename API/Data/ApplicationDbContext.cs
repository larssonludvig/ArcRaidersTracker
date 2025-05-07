using Microsoft.EntityFrameworkCore;
using ArcTrackerAPI.Models;

namespace ArcTrackerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Recyclable> Recyclables { get; set; }
    }
}