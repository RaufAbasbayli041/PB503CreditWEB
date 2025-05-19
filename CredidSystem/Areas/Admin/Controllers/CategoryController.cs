using CredidSystem.DB;
using CredidSystem.Models;
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
       
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
            
        }
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
        {
          var data = await _categoryService.CreateAsync(categoryViewModel);
           
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Edit()
        {
          return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CategoryViewModel model)   
        {
            var data = await _categoryService.Update(model);
            if (data == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

      

        [HttpPost]
        public async Task<ActionResult> Delete(CategoryViewModel model)
        {
            var data = await _categoryService.DeleteAsync(model.Id);
            if (data == false)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            var data = await _categoryService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }


    }
}
