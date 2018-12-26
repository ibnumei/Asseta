using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetaWeb.Models;
using System.Linq.Dynamic;

namespace AssetaWeb.Controllers
{
    public class EntityController : Controller
    {
        private readonly assetaDbContext _context;

        public EntityController(assetaDbContext context)
        {
            _context = context;
        }
        //=============================================================================================================================================
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.EntityTbl.Include(x => x.SiteMaster).ToListAsync());
        //    //return View(await _context.AssetTbl.Include(x => x.SITE).Include(x => x.AssetGroup).Include(x => x.Entity).ToListAsync());
        //}
        public IActionResult Index()
        {
            //return View(_db.SiteMasterTbl.ToList());
            return View();
        }
        //===================================================================================
        //Get Processing Data tables
        public IActionResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data  
                //var customerData = (from tempcustomer in _context.EntityTbl
                //                    select tempcustomer);
                var customerData = from tempcustomer in _context.EntityTbl
                                   join tempcustomer2 in _context.SiteMasterTbl on tempcustomer.SiteId equals tempcustomer2.SiteId
                                   select new { tempcustomer.EntityId, tempcustomer.EntityCode, tempcustomer.EntityName, tempcustomer.Address, tempcustomer.CompanyName, tempcustomer.Contact, tempcustomer.Pic, tempcustomer.CreatedBy, tempcustomer.ModifyBy, tempcustomer2.SiteName} ;

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.EntityCode == searchValue);
                }

                //total number of rows count   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }

        //=============================================================================================================================================
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
        //=============================================================================================================================================
        // GET: Entity/Create
        public IActionResult Create()
        {
            ViewBag.SITEID = new SelectList(_context.SiteMasterTbl, "SiteId", "SiteName");
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
        //=============================================================================================================================================
        // GET: Entity/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.SITEID = new SelectList(_context.SiteMasterTbl, "SiteId", "SiteName");
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
                    entityTbl.ModifyAtEntity = DateTime.Now;
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
        //=============================================================================================================================================
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
