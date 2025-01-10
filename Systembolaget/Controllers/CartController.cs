using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Systembolaget.Models;
using Systembolaget.ViewModels;

namespace Systembolaget.Controllers;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new CartIndexVm
        {
            Products = await _context.Products.ToListAsync()
        };

        return View(viewModel);
    }
}




