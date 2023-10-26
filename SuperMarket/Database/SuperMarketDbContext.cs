using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Models;
namespace SuperMarket.Database
{
    public class SuperMarketDbContext : DbContext
    {
        public SuperMarketDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Supermarket> superMarkets { get; set; }
    }
}
