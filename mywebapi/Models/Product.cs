
namespace mywebapi.Models;
public class ProductVM
{
    public string Name {get; set;} = "Product";
    public double Price {get; set;}
}

public class Product : ProductVM
{
    public Guid Id {get; set;}
}