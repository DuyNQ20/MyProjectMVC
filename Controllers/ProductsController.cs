using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogService.Api.Data;
using MyProjectMVC.Mapper;
using MyProjectMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace MyProjectMVC.Models
{

    public class ProductsController : Controller
    {
        private readonly DataContext _context;
        private readonly StorageConfiguration _storageConfiguration;

        public ProductsController(DataContext context, IOptions<StorageConfiguration> storageConfiguration)
        {
            _context = context;
            _storageConfiguration = storageConfiguration.Value;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Products.Include(p => p.Vendor).Include(p => p.Files).Include(x => x.ProductCategory).Include(x => x.Supplier);

            return View(await dataContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategorys, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductView productView, List<IFormFile> files)
        {
            var product = new Product();
            var listFile = new List<File>();
            var path = System.IO.Path.GetFullPath(System.IO.Path.Combine(StorageConfiguration.StorageDirectory));
            System.IO.Directory.CreateDirectory(path);
            product.SaveMap(productView);
            
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

                // Upload file
                bool firstfile = true; // kiểm tra xem có phải file đầu tiên
                foreach (var formFile in files)
                {
                    var file = new File();
                    var filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(StorageConfiguration.StorageDirectory, formFile.FileName));
                    if (formFile.Length > 0)
                    {
                        using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                            file.SaveMap(formFile, product.Id);
                            if(firstfile)
                            {
                                file.thumbnail = true;
                            }
                        }
                    }
                    listFile.Add(file);
                    firstfile = false;
                }
               
                // them file vao db
                _context.AddRange(listFile);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategorys, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategorys, "Id", "Name", product.ProductCategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", product.SupplierId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name", product.VendorId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", product.StatusId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductView productView, List<IFormFile> files, IFormFile thumbfile)
        {
            var listFile = new List<File>();
            var fileone = new File();
            // cập nhật ảnh sản phẩm
            if (files.Count > 0)
            {
                listFile = _context.Files.Where(x => x.ProductId == id & x.thumbnail == false).ToList();
                int dem = 0;
                foreach(var item in files)
                {
                    var filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(StorageConfiguration.StorageDirectory, item.FileName));
                    if (item.Length > 0)
                    {
                        using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                            listFile[dem].Path = System.IO.Path.Combine(StorageConfiguration.Path, item.FileName);
                           
                        }
                    }
                    _context.Entry(listFile[dem]).State = EntityState.Modified;
                    dem++;
                    if (dem > listFile.Count - 1)
                        break;
                    
                }
               
            }

            // Cập nhật thumbail
            if (thumbfile != null)
            {
                fileone = await _context.Files.FirstOrDefaultAsync(x => x.ProductId == id & x.thumbnail == true);
                
                var filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(StorageConfiguration.StorageDirectory, thumbfile.FileName));
                if (thumbfile.Length > 0)
                {
                    using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                    {
                        await thumbfile.CopyToAsync(stream);
                        fileone.Path = System.IO.Path.Combine(StorageConfiguration.Path, thumbfile.FileName);
                    }
                }
                _context.Entry(fileone).State = EntityState.Modified;
            }

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Map(productView);
            _context.Entry(product).State = EntityState.Modified;
           
          
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int? id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            product.StatusId = product.StatusId == 1 ? 2 : 1;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
