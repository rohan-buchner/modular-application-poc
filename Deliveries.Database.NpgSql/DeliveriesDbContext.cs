using Microsoft.EntityFrameworkCore;

namespace Deliveries.Database.NpgSql
{
    public class DeliveriesDbContext : DbContext
    {
        public DeliveriesDbContext(DbContextOptions<DeliveriesDbContext> options) : base(options)
        {
        }

        public DbSet<Core.Domain.Delivery> Deliveries { get; set; }

        internal class DeliveriesDbContextFactory : NpgSqlContextFactory<DeliveriesDbContext>
        {
        }
    }
}