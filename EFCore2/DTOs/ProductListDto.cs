namespace EFCore2.DTOs;

public class ProductListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; } //FK
    public int Stock { get; set; }
    public double Price { get; set; }

}
