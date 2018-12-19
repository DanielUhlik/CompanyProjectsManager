using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CompanyProjectsManager.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CompanyProjectsManager.Controllers
{
    public class AccountController : Controller
    {
        private IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginRequestModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == _configuration["Settings:Access:UserName"] && model.Password == _configuration["Settings:Access:Password"])
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, model.Email)
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(principal: principal);

                    var a = User.Identity.Name;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}