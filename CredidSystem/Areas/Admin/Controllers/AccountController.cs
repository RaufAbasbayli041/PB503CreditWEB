using CredidSystem.Areas.Admin.Models;
using CredidSystem.Entity;
using CredidSystem.Helpers.Enum;
using CredidSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CredidSystem.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly EmailService _emailService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
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
                ModelState.AddModelError("", "You are not allowed to sign in.");
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
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            var user = new User()
            {
                UserName = signUpViewModel.Username,
                Email = signUpViewModel.Email,
                PhoneNumber = signUpViewModel.PhoneNumber,               
                LoginIpAdr = remoteIpAddress                                           
            };

            var result = await _userManager.CreateAsync(user, signUpViewModel.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                await _userManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            await _emailService.SendEmailAsync(user.Email, "Welcome to our site", "Thank you for signing up!");

            return View(signUpViewModel);
        }




    }
}
