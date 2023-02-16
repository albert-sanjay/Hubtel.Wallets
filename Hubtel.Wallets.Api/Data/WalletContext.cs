using Hubtel.Wallets.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.Wallets.Api.Data
{
    public class WalletContext : DbContext
    {
        public WalletContext(DbContextOptions<WalletContext> options) : base(options) { }

        public DbSet<WalletModel> WalletsModel { get; set; }
    }
}
