using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Warehouse.Lists.Items;

namespace Warehouse.Lists.Orders
{
    public class TmaRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public Unit Unit { get; set; }

        [Required]
        public int Quantity { get; set; }

        public double PriceWithoutVat { get; set; }

        public string? Comment { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        public TmaRequest()
        {
        }

        public TmaRequest(int id, string employeeName, int itemId, Unit unit, int quantity, string? comment, Item item)
        {
            Id = id;
            EmployeeName = employeeName;
            ItemId = itemId;
            Unit = unit;
            Quantity = quantity;
            Comment = comment;
            OrderStatus = OrderStatus.New;
            PriceWithoutVat = Quantity * Item.PriceWithoutVat;
            if (item != null)
            {
                PriceWithoutVat = Quantity * item.PriceWithoutVat;
            }
        }

    }
}
