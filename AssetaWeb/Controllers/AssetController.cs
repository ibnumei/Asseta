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
        //=============================================================================================================================================
        // GET: Asset
        public async Task<IActionResult> Index()
        {
            //return View(await _context.AssetTbl.Include(x=>x.SITE).Include(x=>x.AssetGroup).Include(x=>x.Entity).ToListAsync());
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
                var customerData = from a in _context.AssetTbl
                                   join b in _context.SiteMasterTbl on a.SiteId equals b.SiteId
                                   join c in _context.AssetGroupTbl on a.AssetGroupId equals c.AssetGroupId
                                   join d in _context.EntityTbl on a.EntityId equals d.EntityId
                                   select new { a.AssetId, a.AssetCode, a.AssetName, a.SerialNumber, a.ValidityDate, a.Location, a.Valuation, b.SiteName, c.AssetGroupName, d.EntityName};

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.AssetCode.Contains(searchValue) || m.AssetName.Contains(searchValue));
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
        //=============================================================================================================================================
        // GET: Asset/Create
        public IActionResult Create()
        {
            ViewBag.SITEID = new SelectList(_context.SiteMasterTbl, "SiteId", "SiteName");
            ViewBag.AssetGroupId = new SelectList(_context.AssetGroupTbl, "AssetGroupId", "AssetGroupName");
            ViewBag.EntityId = new SelectList(_context.EntityTbl, "EntityId", "EntityName");

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
                String idrunning = "";
                idrunning = generateRunningNumber(idrunning);

                assetTbl.AssetCode = idrunning;
                assetTbl.CreatedAtAsset = DateTime.Now;
                assetTbl.ModifyAtAsset = DateTime.Now;
                _context.Add(assetTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetTbl);
        }
        //=============================================================================================================
        //GENERATE RUNNING NUMBER
        private String generateRunningNumber(string id)
        {
            AssetTbl data = _context.AssetTbl.Where(x => x.AssetCode == "AS" + DateTime.Now.ToString("yyMM") + "0001").FirstOrDefault();

            string tempSubId = "";
            int tempId;

            if (data == null)
            {
                id = "AS" + DateTime.Now.ToString("yyMM") + "0001";

            }
            else
            {

                var xx = (from a in _context.AssetTbl
                          where a.AssetCode.Substring(0, 6) == "ST" + DateTime.Now.ToString("yyMM")
                          select a).Max(a => a.AssetCode);

                tempSubId = xx.Substring(6, 4);
                tempId = Convert.ToInt32(tempSubId);
                tempId = tempId + 1;

                if (tempId.ToString().Length == 1)
                {
                    id = "AS" + DateTime.Now.ToString("yyMM") + "000" + tempId;
                }
                else if (tempId.ToString().Length == 2)
                {
                    id = "AS" + DateTime.Now.ToString("yyMM") + "00" + tempId;
                }
                else if (tempId.ToString().Length == 3)
                {
                    id = "AS" + DateTime.Now.ToString("yyMM") + "0" + tempId;
                }
                else if (tempId.ToString().Length == 4)
                {
                    id = "AS" + DateTime.Now.ToString("yyMM") + tempId;
                }


            }

            return id;
        }
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //ViewBag.SITEID = new SelectList(_context.SiteMasterTbl, "SiteId", "SiteName");
            //ViewBag.AssetGroupId = new SelectList(_context.AssetGroupTbl, "AssetGroupId", "AssetGroupName");
            //ViewBag.EntityId = new SelectList(_context.EntityTbl, "EntityId", "EntityName");
            
            var assetTbl = await _context.AssetTbl.FindAsync(id);
            ViewBag.SITEID = _context.SiteMasterTbl.ToList();
            ViewBag.AssetGroupId = _context.AssetGroupTbl.ToList();
            ViewBag.EntityId = _context.EntityTbl.ToList();
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


            if (ModelState.IsValid)
            {
                try
                {
                    assetTbl.ModifyAtAsset = DateTime.Now;
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
        //=============================================================================================================================================
        // GET: Asset/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var assetTbl = await _context.AssetTbl
        //        .FirstOrDefaultAsync(m => m.AssetId == id);
        //    if (assetTbl == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(assetTbl);
        //}

        //// POST: Asset/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var assetTbl = await _context.AssetTbl.FindAsync(id);
        //    _context.AssetTbl.Remove(assetTbl);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AssetTblExists(long id)
        {
            return _context.AssetTbl.Any(e => e.AssetId == id);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var sparepart = _context.AssetTbl.Find(id);
            _context.AssetTbl.Remove(sparepart);
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
