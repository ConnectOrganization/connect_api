using Microsoft.EntityFrameworkCore;

namespace ConnectApi.Models
{
    public class ConnectDbContext : DbContext
    {
        public ConnectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<AddressInfo> Address { get; set; }
    }
}