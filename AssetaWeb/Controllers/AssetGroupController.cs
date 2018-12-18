using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetaWeb.Controllers
{
    public class AssetGroupController : Controller
    {
        private readonly assetaDbContext _db;

        public AssetGroupController(assetaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.AssetGroupTbl.ToList());
        }
        //=========================================================================
        //View Create Data
        public IActionResult Create()
        {
            return View();
        }

        //Action Create Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssetGroupTbl assetGroup)
        {
            if(ModelState.IsValid)
            {
                assetGroup.CreatedAtAssetGroup = DateTime.Now;
                assetGroup.ModifyAtAssetGroup = DateTime.Now;
                _db.Add(assetGroup);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetGroup);
        }
        //=========================================================================================================
        //Edit View
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assetgroup = await _db.AssetGroupTbl.SingleOrDefaultAsync(m => m.AssetGroupId== id);
            if (assetgroup == null)
            {
                return NotFound();
            }
            return View(assetgroup);
        }


        //Method Edit Proses
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssetGroupTbl assetGroup)
        {
            if (id != assetGroup.AssetGroupId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                assetGroup.ModifyAtAssetGroup = DateTime.Now;
                _db.Update(assetGroup);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetGroup);
        }
        //=========================================================================================================
        //Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assetgroup = await _db.AssetGroupTbl.SingleOrDefaultAsync(m => m.AssetGroupId == id);
            if (assetgroup == null)
            {
                return NotFound();
            }
            return View(assetgroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var assetgroup = await _db.AssetGroupTbl.SingleOrDefaultAsync(m => m.AssetGroupId == id);
            _db.AssetGroupTbl.Remove(assetgroup);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //=========================================================================================================
    }
}