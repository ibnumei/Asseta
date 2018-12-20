using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetaWeb.Controllers
{
    public class PeriodController : Controller
    {
        private readonly assetaDbContext _db;

        public PeriodController(assetaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.PeriodTbl.ToList());
        }
        //======================================================================================================
        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PeriodTbl period)
        {
            if (ModelState.IsValid)
            {
                period.CreatedAtPeriod = DateTime.Now;
                period.ModifyAtPeriod = DateTime.Now;
                _db.Add(period);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(period);
        }
        //=========================================================================================================
        //Edit View
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var period = await _db.PeriodTbl.SingleOrDefaultAsync(m => m.PeriodId == id);
            if (period == null)
            {
                return NotFound();
            }
            return View(period);
        }


        //Method Edit Proses
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, PeriodTbl period)
        {
            // var create = _db.SiteMasterTbl.Where(m => m.SiteId == siteMaster.SiteId).First().CreatedAtSite;
            if (id != period.PeriodId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //
                //siteMaster.CreatedAtSite = create;
                period.ModifyAtPeriod = DateTime.Now;
                _db.Update(period);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(period);
        }
        //=========================================================================================================
    }
}