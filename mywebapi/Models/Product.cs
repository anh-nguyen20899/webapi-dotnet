
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mywebapi.Models;
public class ProductVM
{
    
}

[Table("Product")]
public class Product
{
    [Key]
    public Guid Id {get; set;}
    [Required]
    [MaxLength(150)]
    public string Name {get; set;} = "Product";

    [Range(0, Double.MaxValue)]
    public double Price {get; set;}

    public string? Description {get; set;}

    // 0 - 100
    public byte Discount {get; set;}

    public int? CategoryId {get; set;}
    [ForeignKey("CategoryId")]
    public Category? Category {get; set;}
    //relationship
    public ICollection<OrderDetails> _orderDetails {get; set;} 

    public Product()
    {
        _orderDetails = new List<OrderDetails>();
    }
}