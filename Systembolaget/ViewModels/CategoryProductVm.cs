using Systembolaget.Models;

namespace Systembolaget.ViewModels;

public class CategoryProductsVm
{
    public string CategoryName { get; set; } = "";
    public List<Product> Products { get; set; } = new();
}
