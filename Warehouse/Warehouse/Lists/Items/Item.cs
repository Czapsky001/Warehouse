using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Warehouse.Lists.Items
{
    public class Item
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public ItemGroup ItemGroup { get; set; }
        [Required]
        public Unit Unit { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double PriceWithoutVat { get; set; }
        [Required]
        public string? Status { get; set; }
        [DataType(DataType.MultilineText)]
        public string? ContactPerson { get; set; }

        public Item(int id, ItemGroup itemGroup, Unit unit, int quantity, double priceWithoutVat, string status)
        {
            Id = id;
            ItemGroup = itemGroup;
            Unit = unit;
            Quantity = quantity;
            PriceWithoutVat = priceWithoutVat;
            Status = status;
            ContactPerson = string.Empty;
        }
    }
}
