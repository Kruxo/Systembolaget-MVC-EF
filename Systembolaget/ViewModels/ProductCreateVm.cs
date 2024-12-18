using Systembolaget.Models;

namespace Systembolaget.ViewModels;

public class ProductCreateVm
{
    public required Product Product { get; set; }
    public List<Category> Categories { get; set; } = [];
}