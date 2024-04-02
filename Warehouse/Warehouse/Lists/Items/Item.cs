using System.ComponentModel.DataAnnotations;
using Warehouse.Lists.Units;

namespace Warehouse.Lists.Items
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ItemGroupId { get; set; }
        public ItemGroup ItemGroup { get; set; }
        [Required]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        [Required]
        public int Quantity { get; set; } = 0;
        [Required]
        public double PriceWithoutVat { get; set; } = 0;
        [Required]
        public string? Status { get; set; } = string.Empty;
        public string StorageLocation { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string? ContactPerson { get; set; }

        public Item()
        {
        }

        public Item(int itemGroupId, Unit unit, int quantity, double priceWithoutVat, string status)
        {
            ItemGroupId = itemGroupId;
            Unit = unit;
            Quantity = quantity;
            PriceWithoutVat = priceWithoutVat;
            Status = status;
            ContactPerson = string.Empty;
        }
    }
}
