using CredidSystem.DB;
using CredidSystem.Models;
using CredidSystem.Service.Implementation;
using CredidSystem.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CredidSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BranchController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBranchService _branchService;

        private readonly CreditWebDB _db;



        public BranchController(IBranchService branchService, IWebHostEnvironment webHostEnvironment, CreditWebDB db)
        {
            _branchService = branchService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        // GET: BranchController
        public async Task<ActionResult> Index()
        {
            var branches = await _branchService.GetAllWithIncudeAsync();

            return View(branches);
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Branches = await _db.Branches.ToListAsync();

            ViewBag.Categories = await _db.Categories.ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(BranchViewModel branchViewModel)
        {
            ViewBag.Branches = await _db.Branches.ToListAsync();
            ViewBag.Categories = await _db.Categories.ToListAsync();


            var result = await _branchService.CreateAsync(branchViewModel);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var branch = await _branchService.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            ViewBag.Merchants = await _db.Merchants.ToListAsync();
            return View(branch);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BranchViewModel branchViewModel)
        {

            var result = await _branchService.Update(branchViewModel);
            ViewBag.Merchants = await _db.Merchants.ToListAsync();
            return RedirectToAction("Index");
           

        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var merchant = await _branchService.GetByIdAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }
            return View(merchant);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var merchant = await _branchService.DeleteAsync(id);
            if (merchant == false)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
