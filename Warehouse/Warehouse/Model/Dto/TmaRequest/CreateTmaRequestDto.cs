using Warehouse.Lists.Items;
using Warehouse.Lists.Units;

namespace Warehouse.Model.Dto.TmaRequest
{
    public class CreateTmaRequestDto
    {
        public int RequestId { get; set; }

        public string EmployeeName { get; set; }

        public int ItemId { get; set; }

        public int UnitId { get; set; }

        public int Quantity { get; set; }
    }
}
