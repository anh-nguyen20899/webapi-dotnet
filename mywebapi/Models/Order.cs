using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mywebapi.Models;

public enum Status
{
    New = 0,
    Payment = 1,
    Complete = 2,
    Cancel = -1
}

[Table("Order")]
public class Order
{
    [Key]
    public Guid OrderId {get; set;}

    public DateTime OrderedDate {get; set;}

    public DateTime? DeliverDate { get; set; }

    public Status Status {get; set;}
    public string? Receiver {get; set;}
    public string? Address {get; set;}
    //relationship
    public ICollection<OrderDetails> _orderDetails {get; set;} 

    public Order()
    {
        _orderDetails = new List<OrderDetails>();
    }
}