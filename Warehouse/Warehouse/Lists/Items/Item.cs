using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Warehouse.Lists.Items
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public ItemGroup ItemGroup { get; set; } = ItemGroup.BuildingMaterials;
        [Required]
        public Unit Unit { get; set; } = Unit.Liter;
        [Required]
        public int Quantity { get; set; } = 0;
        [Required]
        public double PriceWithoutVat { get; set; } = 0;
        [Required]
        public string? Status { get; set; } = string.Empty;
        public string StorageLocation { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string? ContactPerson { get; set; }

        public Item(int id, ItemGroup itemGroup, Unit unit, int quantity, double priceWithoutVat, string status)
        {
            ItemGroup = itemGroup;
            Unit = unit;
            Quantity = quantity;
            PriceWithoutVat = priceWithoutVat;
            Status = status;
            ContactPerson = string.Empty;
        }
    }
}
