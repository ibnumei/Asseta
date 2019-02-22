using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetaWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading;
using Microsoft.AspNetCore.Authentication;

namespace AssetaWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly assetaDbContext _db;
        public LoginController(assetaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginTbl login)
        {
            if(login.Username=="" || login.Pass == "")
            {
                return NotFound();
            }
            else
            {
                var search = _db.LoginTbl.FirstOrDefault(m => m.Username == login.Username && m.Pass == login.Pass);
                
                if (search == null)
                {
                    //ModelState.AddModelError(string.Empty, "Employee Doesn't Exist");
                    TempData["MsgNoData"] = "Your application description page.";
                    return View();
                }
                else
                {
                    var name = _db.LoginTbl.FirstOrDefault(m => m.Username == login.Username && m.Pass == login.Pass);
                    //var role = _context.UserLogin.Where(x => x.UserId == userFromRepo.UserId).First().Role;
                    var claims = new List<Claim>();
                    //claims.Add(new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, name.name));
                    claims.Add(new Claim(ClaimTypes.Role
, name.type));
                    //claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                    var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    Thread.CurrentPrincipal = claimsPrincipal;
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    HttpContext.Session.SetString("Username", search.Username);

                    //return View("Index");
                    return RedirectToAction("Index","Home");
                }
            }


        }

        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");
        }
    }
}