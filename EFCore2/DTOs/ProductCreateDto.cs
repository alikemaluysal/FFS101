using System.ComponentModel.DataAnnotations;

namespace EFCore2.DTOs;

public class ProductCreateDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    public int CategoryId { get; set; } //FK

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
    [Range(0, int.MaxValue)]
    public double Price { get; set; }

}
