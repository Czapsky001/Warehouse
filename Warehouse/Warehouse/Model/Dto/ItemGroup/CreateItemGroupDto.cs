using System.ComponentModel.DataAnnotations;

namespace Warehouse.Model.Dto.ItemGroup
{
    public class CreateItemGroupDto
    {
        public int ItemGroupId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
