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
    public class EntityController : Controller
    {
        private readonly assetaDbContext _context;

        public EntityController(assetaDbContext context)
        {
            _context = context;
        }

        // GET: Entity
        public async Task<IActionResult> Index()
        {
            return View(await _context.EntityTbl.ToListAsync());
        }

        // GET: Entity/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityTbl = await _context.EntityTbl
                .FirstOrDefaultAsync(m => m.EntityId == id);
            if (entityTbl == null)
            {
                return NotFound();
            }

            return View(entityTbl);
        }

        // GET: Entity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntityId,SiteId,EntityCode,EntityName,CompanyName,Address,Contact,Pic,CreatedAtEntity,ModifyAtEntity,CreatedBy,ModifyBy")] EntityTbl entityTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entityTbl);
        }

        // GET: Entity/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityTbl = await _context.EntityTbl.FindAsync(id);
            if (entityTbl == null)
            {
                return NotFound();
            }
            return View(entityTbl);
        }

        // POST: Entity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("EntityId,SiteId,EntityCode,EntityName,CompanyName,Address,Contact,Pic,CreatedAtEntity,ModifyAtEntity,CreatedBy,ModifyBy")] EntityTbl entityTbl)
        {
            if (id != entityTbl.EntityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityTblExists(entityTbl.EntityId))
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
            return View(entityTbl);
        }

        // GET: Entity/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityTbl = await _context.EntityTbl
                .FirstOrDefaultAsync(m => m.EntityId == id);
            if (entityTbl == null)
            {
                return NotFound();
            }

            return View(entityTbl);
        }

        // POST: Entity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var entityTbl = await _context.EntityTbl.FindAsync(id);
            _context.EntityTbl.Remove(entityTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityTblExists(long id)
        {
            return _context.EntityTbl.Any(e => e.EntityId == id);
        }
    }
}
