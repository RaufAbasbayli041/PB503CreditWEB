using CredidSystem.DB;
using CredidSystem.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CredidSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly CreditWebDB _db;
        public CategoryController(ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, CreditWebDB db)
        {
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
            
        }

    }
}
