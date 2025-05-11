using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Models;
using CredidSystem.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CredidSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MerchantController : Controller
    {
        private readonly IGenericRepository<Merchant> _merchantRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MerchantController(IGenericRepository<Merchant> merchantRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var merchants = await _merchantRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<MerchantViewModel>>(merchants);
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MerchantViewModel merchantViewModel)
        {
            var merchant = _mapper.Map<Merchant>(merchantViewModel);
            await _merchantRepository.CreateAsync(merchant);
            return RedirectToAction(nameof(Index));
        }

    }
}
