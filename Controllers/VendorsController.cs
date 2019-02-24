using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogService.Api.Data;
using MyProjectMVC.Models;
using MyProjectMVC.ViewModels;
using MyProjectMVC.Mapper;

namespace MyProjectMVC.Controllers
{
    public class VendorsController : Controller
    {
        private readonly DataContext _context;

        public VendorsController(DataContext context)
        {
            _context = context;
        }

        // GET: ProductCategories
        [HttpGet, Route("admin/vendor/categories")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Admin/Vendors/Index.cshtml", await _context.Vendors.ToListAsync());
        }

        [HttpGet, Route("admin/vendor/update/status/{id}")]
        public async Task<IActionResult> UpdateStatus(int? id)
        {
            var vendor = _context.Vendors.Find(id);
            if (vendor == null)
            {
                return NotFound();
            }
            vendor.Active = !vendor.Active;
            _context.Entry(vendor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductCategories/Create
        [HttpGet, Route("admin/vendor/create")]
        public IActionResult Create()
        {
            return View("~/Views/Admin/Vendors/Create.cshtml");
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, Route("admin/vendor/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendorView vendorView)
        {
            Vendor vendor = new Vendor();
            vendor.Map(vendorView);
            if (ModelState.IsValid)
            {
                _context.Add(vendor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Admin/Vendors/Create.cshtml", vendor);
        }

        // GET: ProductCategories/Edit/5
        [HttpGet, Route("admin/vendor/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Vendors/Edit.cshtml", vendor);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost, Route("admin/vendor/edit/{id}")]
        public async Task<IActionResult> Edit(int id, VendorView vendorView)
        {
            var vendor = _context.Vendors.Find(id);

            if (vendor == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vendor.Map(vendorView);
                    _context.Update(vendor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendor.Id))
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
            return View("~/Views/Admin/Vendors/Edit.cshtml", vendor);
        }

        // GET: ProductCategories/Delete/5
        [HttpGet, Route("admin/vendor/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
        }

        private bool VendorExists(int id)
        {
            return _context.Vendors.Any(e => e.Id == id);
        }

        [HttpGet, Route("admin/vendor/search")]
        public async Task<IActionResult> Search([FromQuery]string query)
        {
            var dataContext = _context.Vendors.ToList();
            var vendor = new List<Vendor>();

            if (!String.IsNullOrEmpty(query))
            {
                foreach (var item in dataContext)
                {
                    if (item.Name.ToLower().Contains(query.ToLower()))
                    {
                        vendor.Add(item);
                    }
                }
            }
            return vendor.Count == 0 ? View("~/Views/Admin/Vendors/Index.cshtml", dataContext) : View("~/Views/Admin/Vendors/Index.cshtml", vendor);
        }
    }
}
