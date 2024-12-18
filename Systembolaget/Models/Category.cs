using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Systembolaget.Models;

public class Category()
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
