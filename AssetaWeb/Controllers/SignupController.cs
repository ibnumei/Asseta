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
        public IActionResult signup(String aa, String bb, String cc, String dd, String ee,LoginTbl login)
        {
            byte[] salt = new byte[128 / 8];
            //using (var rng = RandomNumberGenerator.Create())
            //{
            //    rng.GetBytes(salt);
            //}
            //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: dd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            var a = hashed;

            login.name = aa;
            login.Email = bb;
            login.Username = cc;
            login.Pass = a;
            login.type = ee;

            if (ModelState.IsValid)
            {
                
                _db.Add(login);
                 _db.SaveChangesAsync();
                //return RedirectToAction("Index", "Home");
                return Json(new { success = true });
            }
            return View();
        }
    }
}