namespace Warehouse.Model.Dto.Items
{
    public class UpdateItemDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }

        public int ItemGroupId { get; set; }
        public int UnitId { get; set; }

        public int Quantity { get; set; }

        public double PriceWithoutVat { get; set; }

        public string? Status { get; set; }

        public string? StorageLocation { get; set; }

        public string? ContactPerson { get; set; }
    }
}
