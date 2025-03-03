using Microsoft.EntityFrameworkCore;
using ServicePetCarePlanner.Domain.Entities;

namespace ServicePetCarePlanner.DataEntityFramework
{
    public class AppDbContext : DbContext
    {
        DbSet<Record> Records => Set<Record>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
