using System.Text.Json.Serialization;
using Warehouse.Lists.Items;
using Warehouse.Lists.Orders;

namespace Warehouse.Lists.Units
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public ICollection<TmaRequest> TmaRequests { get; set; } = new List<TmaRequest>();

    }

}
