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



        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetAllWithIncudeAsync();
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
            return View(product);
        }
        

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories =await _db.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();

            var product = await _productService.CreateAsync(viewModel);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
