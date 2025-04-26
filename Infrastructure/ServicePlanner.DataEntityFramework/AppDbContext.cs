using Microsoft.EntityFrameworkCore;
using ServicePlanner.Domain.Entities;

namespace ServicePlanner.DataEntityFramework
{
    public class AppDbContext : DbContext
    {
        DbSet<Record> Records => Set<Record>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
