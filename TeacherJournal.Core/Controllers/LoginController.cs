using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace TeacherJournal.Core.Controllers
{
    public class LoginController : Controller
    {
        // GET: Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: Index
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            // TODO: log in
            if(username == "admin" && password == "admin")
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaims(claims);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    principal, 
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false
                    });
                return Redirect("/Student");
            }
            return View();
        }

        // GET: About
        public IActionResult About()
        {
            return View();
        }

    }
}