using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Models;
using CredidSystem.Repository.Interface;
using CredidSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CredidSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MerchantController : Controller
    {
        
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMerchantService _merchantService;
        public MerchantController(IWebHostEnvironment webHostEnvironment, IMerchantService merchantService)
        {
            _webHostEnvironment = webHostEnvironment;
            _merchantService = merchantService;
        }

        public async Task<IActionResult> Index()
        {
            var merchants = await _merchantService.GetAllAsync();

            return View(merchants);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MerchantViewModel merchantViewModel)
        {
            await _merchantService.CreateAsync(merchantViewModel);
            return RedirectToAction(nameof(Index));
        }

    }
}
