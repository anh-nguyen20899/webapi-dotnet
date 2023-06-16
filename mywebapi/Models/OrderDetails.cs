using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mywebapi.Models;
[Table("OrderDetails")]
public class OrderDetails
{
    public Guid ProductId {get; set;}
    public Guid OrderId {get; set;}

    public int Quantity {get; set;}

    public double Price {get;set;}
    public double TotalPrice { get; set; }

    // relationship
    public Product Product { get; set; }
    public Order Order {get; set;}

}