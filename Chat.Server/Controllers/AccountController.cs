using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Chat.Server.Crosscutting;
using Chat.Server.Infraestructure.Data;
using Chat.Server.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Server.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserRepository repository;

        public AccountController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            try
            {
                // User and Password validations

                var claims = new Claim(ClaimTypes.Name, login.UserName).Enumerate();
                ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                repository.Register(login.UserName);

                await HttpContext.SignInAsync(principal);
            }
            catch { return View(); }

            return RedirectToAction(nameof(UsersController.Index), "Users");
        }

        [HttpGet, HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}