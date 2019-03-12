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
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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
                byte[] salt = new byte[128 / 8];
                //using (var rng = RandomNumberGenerator.Create())
                //{
                //    rng.GetBytes(salt);
                //}
                //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

                // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: login.Pass,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));
                var a = hashed;

                var search = _db.LoginTbl.FirstOrDefault(m => m.Username == login.Username && m.Pass == a);
                
                if (search == null)
                {
                    //ModelState.AddModelError(string.Empty, "Employee Doesn't Exist");
                    TempData["MsgNoData"] = "Wrong Username Or Password";
                    return View();
                }
                else
                {
                    //var name = _db.LoginTbl.FirstOrDefault(m => m.Username == login.Username && m.Pass == login.Pass);
                    //var role = _context.UserLogin.Where(x => x.UserId == userFromRepo.UserId).First().Role;
                    var claims = new List<Claim>();
                    //claims.Add(new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, search.name));
                    claims.Add(new Claim(ClaimTypes.Role, search.type));
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