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
    public class ProductCategoriesController : Controller
    {
        private readonly DataContext _context;

        public ProductCategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: ProductCategories
        [HttpGet, Route("admin/products/categories")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Admin/Productcategories/Index.cshtml", await _context.ProductCategorys.ToListAsync());
        }

        [HttpGet, Route("admin/products/categories/update/status/{id}")]
        public async Task<IActionResult> UpdateStatus(int? id)
        {
            var productCategory = _context.ProductCategorys.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            productCategory.Active = !productCategory.Active;
            _context.Entry(productCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductCategories/Create
        [HttpGet, Route("admin/products/categories/create")]
        public IActionResult Create()
        {
            return View("~/Views/Admin/Productcategories/Create.cshtml");
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, Route("admin/products/categories/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategoryView productCategoryView)
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Map(productCategoryView);
            if (ModelState.IsValid)
            {
                _context.Add(productCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Admin/Productcategories/Create.cshtml", productCategory);
        }

        // GET: ProductCategories/Edit/5
        [HttpGet, Route("admin/products/categories/edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategorys.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View("~/Views/Admin/Productcategories/Edit.cshtml", productCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost, Route("admin/products/categories/edit/{id}")]
        public async Task<IActionResult> Edit(int id, ProductCategoryView productCategoryView)
        {
            var productCategory = _context.ProductCategorys.Find(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productCategory.Map(productCategoryView);
                    _context.Update(productCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.Id))
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
            return View("~/Views/Admin/Productcategories/Edit.cshtml", productCategory);
        }

        // GET: ProductCategories/Delete/5
        [HttpGet, Route("admin/products/categories/delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategorys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory != null)
            {
                _context.ProductCategorys.Remove(productCategory);
                await _context.SaveChangesAsync();
                
            }
            return RedirectToAction(nameof(Index));
        }
        
        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategorys.Any(e => e.Id == id);
        }

        [HttpGet, Route("admin/products/categories/search")]
        public async Task<IActionResult> Search([FromQuery]string query)
        {
            var dataContext = _context.ProductCategorys.ToList();
            var productCategories = new List<ProductCategory>();

            if (!String.IsNullOrEmpty(query))
            {
                foreach (var item in dataContext)
                {
                    if (item.Name.ToLower().Contains(query.ToLower()))
                    {
                        productCategories.Add(item);
                    }
                }
            }
            return productCategories.Count == 0 ? View("~/Views/Admin/Productcategories/Index.cshtml", dataContext) : View("~/Views/Admin/Productcategories/Index.cshtml", productCategories);
        }
    }
}
