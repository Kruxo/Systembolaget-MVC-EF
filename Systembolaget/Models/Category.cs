using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systembolaget.Models;

public class Category()
{
    public int Id { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Name cannot be empty")]
    public string Name { get; set; } = "";

    public List<Product> Products { get; set; } = new List<Product>();
}
