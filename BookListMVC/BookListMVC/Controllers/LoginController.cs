using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookListMVC.Controllers
{
    public class LoginController : Controller
    {
        private UserManager<LoginModel> userManager;
        private SignInManager<LoginModel> signInManager;

        public IActionResult Index()
        {


            return View();
        }

       [HttpGet]
        public IActionResult Loginn(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Loginn(LoginModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("Email", "Hatalı giriş");
            }

            return View(model);
        }
    }
}