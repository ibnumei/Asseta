using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetaWeb.Controllers
{
    public class TaskController : Controller
    {
        private readonly assetaDbContext _db;

        public TaskController(assetaDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.TaskTbl.Include(x => x.AssetGroup).ToList());
            
        }
        //===================================================================================
        //View Create Data
        public IActionResult Create()
        {
            ViewBag.Daily = new List<SelectListItem>
            {
              new SelectListItem { Text="General", Value="General"},
              new SelectListItem { Text="Yes / No", Value="Yes / No"},
              new SelectListItem { Text="Checklist", Value="Checklist"}
            };
            ViewBag.AssetGroupId = new SelectList(_db.AssetGroupTbl, "AssetGroupId", "AssetGroupName");
            return View();
        }
        //Action Create Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskTbl taskTbl)
        {
            if (ModelState.IsValid)
            {
                taskTbl.CreatedAtTask = DateTime.Now;
                taskTbl.ModifyAtTask = DateTime.Now;
                _db.Add(taskTbl);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskTbl);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var sparepart = _db.TaskTbl.Find(id);
            _db.TaskTbl.Remove(sparepart);
            _db.SaveChanges();

            return Json(new { success = true });
        }
    }
}