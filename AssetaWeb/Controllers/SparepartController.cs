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
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _db.SparepartTbl.Include(x => x.Supplier).Include(x=>x.SiteMaster).ToListAsync());
        //}
        public IActionResult Index()
        {
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
                var customerData = from a in _db.SparepartTbl
                                   join b in _db.SupplierTbl on a.SupplierId equals b.SupplierId
                                   join c in _db.SiteMasterTbl on a.SiteId equals c.SiteId
                                   select new { a.SparepartId, a.SparepartCode, a.SparepartDesc, a.Qty, a.UoM, b.SupplierCode, c.SiteName};

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.SparepartCode == searchValue);
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
            
            var sparepart = await _db.SparepartTbl.SingleOrDefaultAsync(m => m.SparepartId == id);
            //ViewBag.SupplierId = new SelectList(_db.SupplierTbl, "SupplierId", "SupplierCode");
            //ViewBag.SITEID = new SelectList(_db.SiteMasterTbl, "SiteId", "SiteName");
            ViewBag.SupplierId = _db.SupplierTbl.ToList();
            ViewBag.SITEID = _db.SiteMasterTbl.ToList();
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
        //===============================================================================
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var sparepart = _db.SparepartTbl.Find(id);
            _db.SparepartTbl.Remove(sparepart);
            _db.SaveChanges();

            return Json(new { success = true });
        }
    }
}