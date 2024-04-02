using System.ComponentModel.DataAnnotations;

namespace Warehouse.Model.Dto.Items;

public class CreateItemDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int UnitId { get; set; }

    [Required]
    public int ItemGroupId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public double PriceWithoutVat { get; set; }

}
