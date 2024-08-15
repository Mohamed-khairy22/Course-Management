using Demo.Authentcation;
using Demo.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> SignInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.SignInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Registr()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registr(RegisterUserViewModel newUserVM)

        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.Email = newUserVM.Email;
                userModel.UserName = newUserVM.UserName;
                userModel.PasswordHash = newUserVM.Password;
                //save in db
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.ConfirmPassword);
                if (result.Succeeded)
                {
                    //Create Cookie
                    await SignInManager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Password", item.Description);
                    }
                }
            }
            return View(newUserVM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Login(LoginViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                //Check db
                ApplicationUser userModel = await userManager.FindByNameAsync(userVM.UserName);
                if (userModel !=null) 
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found ==true) 
                    {
                        //Create Cookie
                        await SignInManager.SignInAsync(userModel, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "User Name or Password is wrong.. try again");
                
            }
            return View(userVM);
        }
        public IActionResult LogOut()
        {
            SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
