﻿namespace EFCore.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }

    //NavigationPropety
    public virtual Category Category { get; set; }
}

