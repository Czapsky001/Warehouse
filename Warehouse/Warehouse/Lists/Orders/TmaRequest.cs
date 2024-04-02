using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Warehouse.Lists.Items;
using Warehouse.Lists.Units;

namespace Warehouse.Lists.Orders
{
    public class TmaRequest
    {
        public int Id { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        [Required]
        public int Quantity { get; set; }

        private double _priceWithoutVat;
        public double PriceWithoutVat
        {
            get => _priceWithoutVat;
            set
            {
                _priceWithoutVat = value;
            }
        }

        public string? Comment { get; set; }

        public OrderStatus OrderStatus { get; set; }

        private Item _item;
        public Item Item
        {
            get => _item;
            set
            {
                _item = value;
                if (_item != null)
                {
                    PriceWithoutVat = Quantity * _item.PriceWithoutVat;
                }
            }
        }

        public TmaRequest()
        {

        }
        public TmaRequest(int id, string employeeName, int itemId, int quantity, string? comment)
        {
            Id = id;
            EmployeeName = employeeName;
            ItemId = itemId;
            Quantity = quantity;
            Comment = comment;
            OrderStatus = OrderStatus.New;
        }

    }
}
