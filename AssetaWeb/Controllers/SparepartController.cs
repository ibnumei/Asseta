using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetaWeb.Models;

namespace AssetaWeb.Controllers
{
    public class SparepartController : Controller
    {
        private readonly assetaDbContext _db;

        public SparepartController(assetaDbContext db)
        {
            _db = db;
        }

        //=============================================================================================================================================
        public async Task<IActionResult> Index()
        {
            return View(await _db.SparepartTbl.Include(x => x.Supplier).Include(x=>x.SiteMaster).ToListAsync());
        }
        //=============================================================================================================================================
        // GET: Asset/Create
        public IActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(_db.SupplierTbl, "SupplierId", "SupplierCode");
            ViewBag.SITEID = new SelectList(_db.SiteMasterTbl, "SiteId", "SiteName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SparepartTbl sparepart)
        {
            if (ModelState.IsValid)
            {
                sparepart.CreatedAtSupp = DateTime.Now;
                sparepart.ModifyAtSupp = DateTime.Now;
                _db.Add(sparepart);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sparepart);
        }
        //=========================================================================================================
        //Edit View
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.SupplierId = new SelectList(_db.SupplierTbl, "SupplierId", "SupplierCode");
            ViewBag.SITEID = new SelectList(_db.SiteMasterTbl, "SiteId", "SiteName");
            var sparepart = await _db.SparepartTbl.SingleOrDefaultAsync(m => m.SparepartId == id);
            if (sparepart == null)
            {
                return NotFound();
            }
            return View(sparepart);
        }


        //Method Edit Proses
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, SparepartTbl sparepart)
        {
            // var create = _db.SiteMasterTbl.Where(m => m.SiteId == siteMaster.SiteId).First().CreatedAtSite;
            if (id != sparepart.SparepartId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //
                //siteMaster.CreatedAtSite = create;
                sparepart.ModifyAtSupp = DateTime.Now;
                _db.Update(sparepart);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sparepart);
        }
    }
}