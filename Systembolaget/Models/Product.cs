using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systembolaget.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public decimal Procent { get; set; }
    public int Volume { get; set; }
    public string Picture { get; set; } = "";
    public int CategoryId { get; set; }

    public Category? Category { get; set; }

}
