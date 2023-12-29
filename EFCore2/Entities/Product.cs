using EFCore2.Core;

namespace EFCore2.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public int CategoryId{ get; set; } //FK
    public int Stock { get; set; }
    public double Price { get; set; }

    //EFCore'a ilişkiyi belirtmek için kullandığım bir alan
    //Navigation Property
    public virtual Category Category { get; set; }


}
