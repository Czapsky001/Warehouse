using Microsoft.EntityFrameworkCore;
using Warehouse.Lists.Items;
using Warehouse.Lists.Orders;

namespace Warehouse.DatabaseConnector;

public class DatabaseContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<TmaRequest> Requests { get; set; }


    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}