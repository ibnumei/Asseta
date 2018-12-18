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
    public class AssetController : Controller
    {
        private readonly assetaDbContext _context;

        public AssetController(assetaDbContext context)
        {
            _context = context;
        }

        // GET: Asset
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetTbl.Include(x=>x.SITE).ToListAsync());
        }

        // GET: Asset/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetTbl = await _context.AssetTbl
                .FirstOrDefaultAsync(m => m.AssetId == id);
            if (assetTbl == null)
            {
                return NotFound();
            }

            return View(assetTbl);
        }

        // GET: Asset/Create
        public IActionResult Create()
        {
            ViewBag.SITEID = new SelectList(_context.SiteMasterTbl, "SiteId", "SiteName");

            return View();
        }

        // POST: Asset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssetId,AssetGroupId,SiteId,EntityId,AssetCode,AssetName,SerialNumber,ValidityDate,Location,Valuation,CreatedAtAsset,ModifyAtAsset")] AssetTbl assetTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetTbl);
        }

        // GET: Asset/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetTbl = await _context.AssetTbl.FindAsync(id);
            if (assetTbl == null)
            {
                return NotFound();
            }
            return View(assetTbl);
        }

        // POST: Asset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("AssetId,AssetGroupId,SiteId,EntityId,AssetCode,AssetName,SerialNumber,ValidityDate,Location,Valuation,CreatedAtAsset,ModifyAtAsset")] AssetTbl assetTbl)
        {
            if (id != assetTbl.AssetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetTblExists(assetTbl.AssetId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(assetTbl);
        }

        // GET: Asset/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetTbl = await _context.AssetTbl
                .FirstOrDefaultAsync(m => m.AssetId == id);
            if (assetTbl == null)
            {
                return NotFound();
            }

            return View(assetTbl);
        }

        // POST: Asset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var assetTbl = await _context.AssetTbl.FindAsync(id);
            _context.AssetTbl.Remove(assetTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetTblExists(long id)
        {
            return _context.AssetTbl.Any(e => e.AssetId == id);
        }
    }
}
