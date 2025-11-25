using GainsHub.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GainsHub.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int? categoryId, int page = 1)
        {
            int pageSize = 9;
            var query = _context.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId));
            }


            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalProducts = await query.CountAsync();

            ViewData["Categories"] = await _context.Categories.ToListAsync();
            ViewData["TotalPages"] = (int)Math.Ceiling(totalProducts / (double)pageSize);
            ViewData["CurrentPage"] = page;
            ViewData["SelectedCategory"] = categoryId;

            if (products.Count == 0)
            {
                ViewData["NoProductsMessage"] = "There are no products available at the moment.";
            }
            return View(products);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }



        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
    }
}