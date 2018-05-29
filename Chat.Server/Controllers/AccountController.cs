using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Chat.Server.Crosscutting;
using Chat.Server.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Server.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            try
            {
                var claims = new Claim(ClaimTypes.Name, login.User).Enumerate();
                ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);
            }
            catch { return StatusCode(500); }

            return Ok();
        }

        [HttpGet, HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}