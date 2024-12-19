using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systembolaget.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name cannot be empty")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name needs to have 2-50 characters")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Description cannot be empty")]
    [StringLength(200)]
    public string Description { get; set; } = "";

    [Required(ErrorMessage = "Price cannot be empty")]
    [Range(0, 1000, ErrorMessage = "Price must be positive.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Procent cannot be empty")]
    [Range(0, 100, ErrorMessage = "Procent must be between 0 and 100.")]
    public decimal Procent { get; set; }

    [Required(ErrorMessage = "Volume cannot be empty")]
    [Range(0, int.MaxValue, ErrorMessage = "Volume must be positive.")]
    public int Volume { get; set; }

    [Required(ErrorMessage = "Picture url cannot be empty")]
    public string Picture { get; set; } = "";
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

}
