using System.Text.Json.Serialization;

namespace Warehouse.Lists.Items;

public class ItemGroup
{
    public int ItemGroupId { get; set; }

    public string Name { get; set; } = string.Empty;
    public ICollection<Item> Items { get; set; } = new List<Item>();
}
