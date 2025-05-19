using CredidSystem.Entity;
using CredidSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CredidSystem.Controllers
{
    [Area("Admin")]
    public class AccountControllercs : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountControllercs(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult > SignIn(SignInViewModel signInViewModel)
        {
            if (!ModelState.IsValid) {
                return View(signInViewModel);
            }
            var user = await _signInManager.PasswordSignInAsync(signInViewModel.UserName,signInViewModel.Password,true,false);
            if (user.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.IsLockedOut) 
            {
                ModelState.AddModelError("", "Your account is locked out.");
            }
            else if (user.IsNotAllowed)
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
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin"});
                }
                else if (roles.Contains("Employee"))
                {
                    return RedirectToAction("Index", "Employee");
                }
                else if (roles.Contains("Customer"))
                {
                    return RedirectToAction("Index", "Customer");
                }


                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}
