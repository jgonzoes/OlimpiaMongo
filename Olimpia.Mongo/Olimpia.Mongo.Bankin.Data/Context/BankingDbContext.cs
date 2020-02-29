using Microsoft.EntityFrameworkCore;
using Olimpia.Mongo.Bankin.Domain.Models;

namespace Olimpia.Mongo.Bankin.Data.Context
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
