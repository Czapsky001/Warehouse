using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Warehouse.Lists.Orders;

namespace Warehouse.DatabaseConnector
{
    public class TmaRequestConfiguration : IEntityTypeConfiguration<TmaRequest>
    {
        public void Configure(EntityTypeBuilder<TmaRequest> builder)
        {
            builder.Property(e => e.OrderStatus)
                .HasConversion<string>();
        }
    }
}
