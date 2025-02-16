using Microsoft.EntityFrameworkCore;
using Okala.Domain.Entities;

namespace Okala.Command.EF
{
    public class CommandDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Crypto> cryptos { get; set; }

        public CommandDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
