using CredidSystem.Areas.Admin.Models;
using CredidSystem.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CredidSystem.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(signInViewModel);
            }

            var user = await _userManager.FindByEmailAsync(signInViewModel.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email tapılmadı.");
                return View(signInViewModel);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, signInViewModel.Password, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account is locked out.");
            }
            else if (result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Your account is not allowed to sign in.");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(signInViewModel);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
          

            var user = new User
            {
                UserName = signUpViewModel.Username,
                Email = signUpViewModel.Email,
                PhoneNumber = signUpViewModel.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, signUpViewModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(signUpViewModel);

        }
    }
}
