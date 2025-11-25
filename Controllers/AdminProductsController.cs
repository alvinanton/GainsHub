using GainsHub.Data;
using GainsHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GainsHub.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = new MultiSelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateView model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
                return View(model);
            }

            // Create product
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                StockQuantity = model.StockQuantity,
                ImageUrl = model.ImageUrl,
                IsVisible = model.IsVisible,
                ProductCategories = new List<ProductCategory>()
            };

            // Add existing categories
            if (model.SelectedCategoryIds != null)
            {
                var selectedCategories = await _context.Categories
                    .Where(c => model.SelectedCategoryIds.Contains(c.Id))
                    .ToListAsync();

                foreach (var category in selectedCategories)
                {
                    product.ProductCategories.Add(new ProductCategory { Product = product, Category = category });
                }
            }

            // Add new categories if any
            if (!string.IsNullOrWhiteSpace(model.NewCategoryNames))
            {
                var newCategoryNames = model.NewCategoryNames.Split(',')
                    .Select(c => c.Trim())
                    .Where(c => !string.IsNullOrEmpty(c))
                    .Distinct();

                foreach (var categoryName in newCategoryNames)
                {
                    var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
                    if (existingCategory == null)
                    {
                        var newCategory = new Category { Name = categoryName };
                        _context.Categories.Add(newCategory);
                        product.ProductCategories.Add(new ProductCategory { Product = product, Category = newCategory });
                    }
                    else
                    {
                        product.ProductCategories.Add(new ProductCategory { Product = product, Category = existingCategory });
                    }
                }
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            var product = await _context.Products
                .Include(pc => pc.ProductCategories)
                .ThenInclude(c  => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // Get the IDs of the categories associated with this product
            var selectedCategoryIds = product.ProductCategories.Select(pc => pc.CategoryId).ToList();

            // Fetch all available categories for the dropdown
            var allCategories = await _context.Categories.ToListAsync();
            ViewBag.Categories = new MultiSelectList(allCategories, "Id", "Name", selectedCategoryIds);
            return View(product);

        }

        [HttpPost]
        public IActionResult Edit(int id, decimal price)
        { 
            return View(id); 
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
        }


        public IActionResult ToggleVisibility(int id)
        {
            return View();
        }

        

    }
}
