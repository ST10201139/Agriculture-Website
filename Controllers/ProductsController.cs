using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriConnectPlatformProject.Areas.Identity.Data;
using AgriConnectPlatformProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AgriConnectPlatformProject.Controllers
{
  
    public class ProductsController : Controller
    {
        private readonly ProjectDbContext _context;
        private readonly UserManager<AgriConnectPlatformProjectUser> _userManager;

        public ProductsController(ProjectDbContext context, UserManager<AgriConnectPlatformProjectUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Farmer,Super Admin")]
        // GET: Products
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found");
            }

            if (User.IsInRole("Super Admin"))
            {
                var allProducts = await _context.Products.ToListAsync();
                return View(allProducts);
            }

            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.Email == user.Email);
            if (farmer == null)
            {
                return NotFound("Farmer not found");
            }

            var farmerProducts = await _context.Products
                .Where(p => p.FarmerId == farmer.Id)
                .ToListAsync();

            return View(farmerProducts);
        }
        [Authorize(Roles = "Farmer,Super Admin")]
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }
        [Authorize(Roles = "Farmer,Super Admin")]
        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Farmer,Super Admin")]
        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Category,ProductionDate")] Products product)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.Email == user.Email);
                if (farmer == null)
                {
                    return NotFound("Farmer not found");
                }

                product.FarmerId = farmer.Id;

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [Authorize(Roles = "Farmer,Super Admin")]
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            return View(product);
        }
        [Authorize(Roles = "Farmer,Super Admin")]
        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,ProductionDate,FarmerId")] Products product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);
                    var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.Email == user.Email);
                    if (farmer == null)
                    {
                        return NotFound("Farmer not found");
                    }

                    product.FarmerId = farmer.Id;

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        //Product List
        [Authorize(Roles = "Employee,Super Admin")]
        public async Task<IActionResult> List(DateTime? startDate, DateTime? endDate, string productType)
        {
            IQueryable<Products> productsQuery = _context.Products;

            if (startDate.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.ProductionDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.ProductionDate <= endDate.Value);
            }

            if (!string.IsNullOrEmpty(productType))
            {
                productsQuery = productsQuery.Where(p => p.Category == productType);
            }

            var products = await productsQuery.ToListAsync();
            return View(products);
        }
        [Authorize(Roles = "Farmer,Super Admin")]
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }
        [Authorize(Roles = "Farmer,Super Admin")]
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                _context.Products.Remove(products);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
