using Microsoft.EntityFrameworkCore;
using Okala.Domain.Entities;

namespace Okala.Query.EF
{
    public class QueryDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Crypto> cryptos { get; set; }

        public QueryDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
