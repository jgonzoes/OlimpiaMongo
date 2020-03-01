using Microsoft.EntityFrameworkCore;
using Olimpia.Mongo.Transfe.Domain.Models;

namespace Olimpis.Momgo.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
