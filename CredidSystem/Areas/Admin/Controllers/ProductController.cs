using CredidSystem.DB;
using CredidSystem.Models;
using CredidSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;

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


        public IActionResult Index()
        {
            var products = _productService.GetAllAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
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
            return RedirectToAction("Index");
        }
    }
}
