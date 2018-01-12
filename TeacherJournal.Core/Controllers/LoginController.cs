using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using TeacherJournal.BusinessLogic;

namespace TeacherJournal.Core.Controllers
{
    public class LoginController : Controller
    {
        private readonly TeacherService _teacherService;

        public LoginController(TeacherService teacherSerivce)
        {
            _teacherService = teacherSerivce;
        }
        // GET: Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: Index
        [HttpPost]
        public async Task<IActionResult> Index(string login, string password)
        {
            if(await _teacherService.IsAuthenticated(login, password))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, login)
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