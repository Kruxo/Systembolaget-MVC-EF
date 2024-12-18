using Systembolaget.Models;

namespace Systembolaget.ViewModels;

public class ProductEditVm
{
    public required Product Product { get; set; }
    public List<Category> Categories { get; set; } = [];
}

