using Microsoft.EntityFrameworkCore;
using Validation;

namespace ConnectApi.Models
{
    public class ConnectDbContext : ValidationDbContext
    {
        public ConnectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<AddressInfo> Address { get; set; }
    }
}