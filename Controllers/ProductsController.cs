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
using System.IO;

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

        public void AddFilesForProduct(List<IFormFile> files, int productId, bool thumbnail = false)
        {
            var list = new List<File>();

            var path = Path.GetFullPath(Path.Combine(StorageConfiguration.StorageDirectory));
            Directory.CreateDirectory(path);
            
            foreach (var item in files)
            {
                var filePath = Path.Combine(path, item.FileName);

                if (item.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                        var file = new File();
                        if (thumbnail)
                            file.SaveMap(item, productId, true);
                        else
                            file.SaveMap(item, productId);
                        list.Add(file);
                    }
                }
            }
            _context.AddRange(list);
            _context.SaveChanges();
        }

        public void UpdateFilePathsForProduct(List<IFormFile> files, int productId, bool thumbnai = false)
        {
            var listFile = _context.Files.Where(x => x.ProductId == productId & x.thumbnail == thumbnai).ToList();
           
            if (files.Count != 0)
            {
                _context.RemoveRange(listFile); // Xóa đi

                AddFilesForProduct(files, productId, thumbnai); // thêm lại
            }
        }

        // GET: Products
       
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Products.Include(p => p.Files).Include(x => x.ProductCategory);

            return View(await dataContext.ToListAsync());
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
        public async Task<IActionResult> Create(ProductView productView, List<IFormFile> files, List<IFormFile> file)
        {
            var product = new Product();
            var listFile = new List<File>();
            //var path = System.IO.Path.GetFullPath(System.IO.Path.Combine(StorageConfiguration.StorageDirectory));
            //System.IO.Directory.CreateDirectory(path);
            product.SaveMap(productView);

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                // Upload file
                AddFilesForProduct(files, product.Id); // Upload image for product
                AddFilesForProduct(file, product.Id, true); // Upload thumbnail for product
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategorys, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();

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
        public async Task<IActionResult> Edit(int id, ProductView productView, List<IFormFile> files, List<IFormFile> file)
        {
            // cập nhật ảnh sản phẩm
            UpdateFilePathsForProduct(files, id);

            // Cập nhật thumbail
            UpdateFilePathsForProduct(file, id, true);


            // Cập nhật sản phẩm
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
            return RedirectToRoute("products");
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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

        [HttpGet, Route("products/search")]
        public async Task<IActionResult> Index([FromQuery]string query)
        {
            var dataContext = _context.Products.Include(p => p.Files).Include(x => x.ProductCategory).ToList();
            var products = new List<Product>();

            if (!String.IsNullOrEmpty(query))
            {
                foreach (var item in dataContext)
                {
                    if (item.Name.Contains(query))
                    {
                        products.Add(item);
                    }
                }
            }
            return products.Count == 0? View(dataContext) : View(products);
        }
       


    }

}
