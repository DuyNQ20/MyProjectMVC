using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProjectMVC.Data;
using MyProjectMVC.Models;
using MyProjectMVC.ViewModels;
using Microsoft.AspNetCore.Http;

namespace MyProjectMVC.Controllers.Home
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Products.Include(p => p.Files).Include(x => x.ProductCategory);
            return View(await dataContext.ToListAsync());
        }

        // GET: Home/Details/5
        [HttpGet, Route("details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.Status)
                .Include(p => p.Supplier)
                .Include(p => p.Files)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet, Route("search")]
        public async Task<IActionResult> Search([FromQuery]string query)
        {
            var dataContext = _context.Products.Include(p => p.Files).Include(x => x.ProductCategory).ToList();
            var products = new List<Product>();

            if (!String.IsNullOrEmpty(query))
            {
                foreach (var item in dataContext)
                {
                    if (item.Name.ToLower().Contains(query.ToLower()))
                    {
                        products.Add(item);
                    }
                }
            }
            return products.Count == 0 ? View("index", dataContext) : View("index", products);
        }


        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
