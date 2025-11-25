using GainsHub.Data;
using GainsHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GainsHub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

          
           
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            var totalProducts = await _context.Products.CountAsync();
            var totalUsers = await _context.Users.CountAsync();
            var totalOrders = await _context.Orders.CountAsync();

            var viewModel = new AdminDashboard
            {
                TotalProducts = totalProducts,
                TotalUsers = totalUsers,
                TotalOrders = totalOrders
            };
            return View(viewModel);
        }
    }
}
