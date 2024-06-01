using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriConnectPlatformProject.Areas.Identity.Data;
using AgriConnectPlatformProject.Models;
using AgriConnectPlatformProject.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AgriConnectPlatformProject.Controllers
{
    [Authorize(Roles = "Employee,Super Admin")]
    public class FarmersController : Controller
    {
        private readonly ProjectDbContext _context;
        private readonly UserManager<AgriConnectPlatformProjectUser> _userManager;
        private readonly IPasswordHasher<AgriConnectPlatformProjectUser> _passwordHasher;

        public FarmersController(ProjectDbContext context, UserManager<AgriConnectPlatformProjectUser> userManager, IPasswordHasher<AgriConnectPlatformProjectUser> passwordHasher)
        {
            _context = context;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        // GET: Farmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farmers.ToListAsync());
        }

        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // GET: Farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,Email,Password")] FarmerViewModel farmerViewModel)
        {
            if (ModelState.IsValid)
            {
                var farmerUser = new AgriConnectPlatformProjectUser
                {
                    UserName = farmerViewModel.Email,
                    Email = farmerViewModel.Email
                };

                var result = await _userManager.CreateAsync(farmerUser, farmerViewModel.Password);

                if (result.Succeeded)
                {
                    // Hash the password using the Identity system
                    var hashedPassword = _userManager.PasswordHasher.HashPassword(farmerUser, farmerViewModel.Password);

                    // Create the farmer entry in the Farmers table
                    var farmer = new Farmer
                    {
                        Name = farmerViewModel.Name,
                        Address = farmerViewModel.Address,
                        Email = farmerViewModel.Email,
                        PasswordHash = hashedPassword
                    };
                    _context.Add(farmer);
                    await _context.SaveChangesAsync();

                    // Optionally, assign the user to a "Farmer" role
                    await _userManager.AddToRoleAsync(farmerUser, "Farmer");

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(farmerViewModel);
        }

        // GET: Farmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }
            return View(farmer);
        }

        // POST: Farmers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Email")] Farmer farmer)
        {
            if (id != farmer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerExists(farmer.Id))
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
            return View(farmer);
        }

        // GET: Farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer != null)
            {
                _context.Farmers.Remove(farmer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerExists(int id)
        {
            return _context.Farmers.Any(e => e.Id == id);
        }
    }
}
