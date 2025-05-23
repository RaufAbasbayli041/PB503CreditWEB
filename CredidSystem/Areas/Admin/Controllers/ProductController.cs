using CredidSystem.DB;
using CredidSystem.Entity;
using CredidSystem.Models;
using CredidSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CredidSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly CreditWebDB _db;
        public ProductController(IWebHostEnvironment webHostEnvironment, CreditWebDB db, IProductService productService)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllWithIncludeAsync();
            return View(products);
        }
        public async Task<ActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.DeleteAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");   
        }
        

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Branches = await _db.Branches.ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Branches = await _db.Branches.ToListAsync();

            var product = await _productService.CreateAsync(viewModel);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Branches = await _db.Branches.ToListAsync();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.Branches = await _db.Branches.ToListAsync();

            var products = await _productService.Update(productViewModel);
            if (products == null)
            {
                return NotFound();

            }
            return RedirectToAction("Index");
        }
    }
}
