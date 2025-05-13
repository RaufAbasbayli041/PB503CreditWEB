using CredidSystem.DB;
using CredidSystem.Models;
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
            var branches = await _branchService.GetAllAsync();
            return View(branches);
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Merchants = await _db.Merchants.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(BranchViewModel branchViewModel)
        {
            var result = await _branchService.CreateAsync(branchViewModel);

            return RedirectToAction("Index");
        }

        public override bool Equals(object? obj)
        {
            return obj is BranchController controller &&
                   EqualityComparer<CreditWebDB>.Default.Equals(_db, controller._db);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_db);
        }
    }
}
