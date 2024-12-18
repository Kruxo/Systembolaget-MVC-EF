using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Systembolaget.Models;
using Systembolaget.ViewModels;

namespace Systembolaget.Controllers;

public class SystembolagetController : Controller
{
    private readonly ApplicationDbContext _context;

    public SystembolagetController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products.ToListAsync();

        var viewModel = new ProductIndexVm { Products = products };
        return View(viewModel);
    }

    public IActionResult Create()
    {
        var viewModel = new ProductCreateVm
        {
            Product = new Product(),
            Categories = _context.Categories.OrderBy(c => c.Name).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = RoleConstants.Administrator)]
    public async Task<IActionResult> CreateAsync(ProductCreateVm createVm)
    {
        if (ModelState.IsValid)
        {
            _context.Add(createVm.Product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(createVm);
    }

    [Authorize(Roles = RoleConstants.Administrator)]
    public async Task<IActionResult> EditAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new ProductEditVm
        {
            Product = product,
            Categories = _context.Categories.OrderBy(c => c.Name).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = RoleConstants.Administrator)]
    public async Task<IActionResult> Edit(ProductEditVm productVm)
    {
        var product = productVm.Product;

        if (ModelState.IsValid)
        {
            if (!ProductExists(product.Id))
            {
                return NotFound();
            }
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(productVm);
    }

    [Authorize(Roles = RoleConstants.Administrator)]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new ProductDeleteVm
        {
            Product = product,
            Categories = _context.Categories.OrderBy(c => c.Name).ToList()
        };

        return View(viewModel);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = RoleConstants.Administrator)]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(x => x.Id == id);
    }
}
