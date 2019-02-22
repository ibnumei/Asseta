using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AssetaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewData["MsgNoData"] = HttpContext.Session.GetString("Username");
            //var a = ViewData["MsgNoData"];
            //var b = a;
            
            //var a = HttpContext.Session.GetString("Username");
            //var b = a;

            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var role = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
