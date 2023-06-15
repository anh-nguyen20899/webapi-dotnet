using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mywebapi.Models;

[Table("Category")]
public class Category
{
    [Key]
    public int CategoryId {get; set;}

    [Required]
    [MaxLength(50)]
    public string Name {get; set;} = "Category";
    public virtual ICollection<Product> Products {get; set;} 

}

public class CategoryModel
{
    public static int Id {get; set;} = 10;

    public string Name {get; set;} = "Category";
}