﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetaWeb.Controllers
{
    public class SiteController : Controller
    {
        private readonly assetaDbContext _db;

        public SiteController(assetaDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.SiteMasterTbl.ToList());
        }
        //===================================================================================
        //View Create Data
        public IActionResult Create()
        {
            return View();
        }
        //Action Create Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SiteMasterTbl siteMaster)
        {
            if (ModelState.IsValid)
            {
                siteMaster.ModifyAtSite = DateTime.Now;
                siteMaster.CreatedAtSite = DateTime.Now;
                _db.Add(siteMaster);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteMaster);
        }
        //=========================================================================================================
        //Edit View
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sitemaster = await _db.SiteMasterTbl.SingleOrDefaultAsync(m => m.SiteId == id);
            if (sitemaster == null)
            {
                return NotFound();
            }
            return View(sitemaster);
        }


        //Method Edit Proses
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SiteMasterTbl siteMaster)
        {
            if (id != siteMaster.SiteId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
               //var create =  await _db.SiteMasterTbl.SingleOrDefaultAsync(m => m.SiteId == id);
               // siteMaster.CreatedAtSite = create.CreatedAtSite;
                siteMaster.ModifyAtSite = DateTime.Now;
                _db.Update(siteMaster);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteMaster);
        }
        //=========================================================================================================
        //Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sitemaster = await _db.SiteMasterTbl.SingleOrDefaultAsync(m => m.SiteId == id);
            if (sitemaster == null)
            {
                return NotFound();
            }
            return View(sitemaster);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var sitemaster = await _db.SiteMasterTbl.SingleOrDefaultAsync(m => m.SiteId == id);
            _db.SiteMasterTbl.Remove(sitemaster);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //=========================================================================================================
    }
}