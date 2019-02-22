using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace AssetaWeb.Controllers
{
    public class SignupController : Controller
    {
        private readonly assetaDbContext _db;

        public SignupController(assetaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult signup()
        {
            ViewBag.Role = new List<SelectListItem>
            {
              new SelectListItem { Text="Super Admin", Value="SU"},
              new SelectListItem { Text="Web Admin", Value="WA"},
            };

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> signup(LoginTbl login)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: login.Pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            var a = hashed;

            if (ModelState.IsValid)
            {
                login.Pass = a;
                _db.Add(login);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}