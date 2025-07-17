using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aspnet_Crud_EFcore.Models.Data;

namespace Aspnet_Crud_EFcore.Controllers
{
    public class PackageTypesController : Controller
    {
        private readonly JourneyHubContext _context;

        public PackageTypesController(JourneyHubContext context)
        {
            _context = context;
        }

        // GET: PackageTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PackageTypes.ToListAsync());
        }

        // GET: PackageTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageTypes
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (packageType == null)
            {
                return NotFound();
            }

            return View(packageType);
        }

        // GET: PackageTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackageTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeName,Description")] PackageType packageType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packageType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packageType);
        }

        // GET: PackageTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageTypes.FindAsync(id);
            if (packageType == null)
            {
                return NotFound();
            }
            return View(packageType);
        }

        // POST: PackageTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName,Description")] PackageType packageType)
        {
            if (id != packageType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packageType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageTypeExists(packageType.TypeId))
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
            return View(packageType);
        }

        // GET: PackageTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageTypes
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (packageType == null)
            {
                return NotFound();
            }

            return View(packageType);
        }

        // POST: PackageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packageType = await _context.PackageTypes.FindAsync(id);
            if (packageType != null)
            {
                _context.PackageTypes.Remove(packageType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageTypeExists(int id)
        {
            return _context.PackageTypes.Any(e => e.TypeId == id);
        }
    }
}
