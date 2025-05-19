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

        public async Task<IActionResult> Edit(int id)
        {
            var merchant = await _merchantService.GetByIdAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }
            return View(merchant);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MerchantViewModel merchantViewModel)
        {
            if (ModelState.IsValid)
            {
                await _merchantService.Update(merchantViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(merchantViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var merchant = await _merchantService.DeleteAsync(id);
            if (merchant == false)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var merchant = await _merchantService.GetByIdAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }
            return View(merchant);
        }
    }
}
