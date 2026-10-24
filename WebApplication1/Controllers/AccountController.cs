using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]

    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser
                {
                    UserName = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.Mobile
                };
                var result = await userManager.CreateAsync(identityUser, user.Password);
                if (result.Succeeded)
                {
                    //Performing a Sign-In into the appliction
                    await signInManager.SignInAsync(identityUser, false);   // it will manage signin and signout  // false :- not signin when close the browser
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var Error in result.Errors)
                    {
                        //Displaying error details to the user
                        ModelState.AddModelError("", Error.Description);
                    }
                }
            }
            return View(user);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel , string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.Name, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(returnUrl);   // connot allow remote redirect for safety we use it 
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");

        }
    }
}
