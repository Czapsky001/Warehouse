using System.ComponentModel.DataAnnotations;

namespace Warehouse.Model.Dto.UnitDto
{
    public class CreateUnitDto
    {
        public int UnitId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
