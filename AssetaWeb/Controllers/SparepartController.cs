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
                    customerData = customerData.Where(m => m.SparepartCode.Contains(searchValue) || m.SparepartDesc.Contains(searchValue));
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
            ViewBag.UOM = new List<SelectListItem>
            {
              new SelectListItem { Text="Pcs", Value="Pcs"},
              new SelectListItem { Text="Kg", Value="Kg"},
            };

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
                String idrunning = "";
                idrunning = generateRunningNumber(idrunning);

                sparepart.SparepartCode = idrunning;
                sparepart.CreatedAtSupp = DateTime.Now;
                sparepart.ModifyAtSupp = DateTime.Now;
                _db.Add(sparepart);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sparepart);
        }
        //=========================================================================================================
        //GENERATE RUNNING NUMBER
        private String generateRunningNumber(string id)
        {
            SparepartTbl data = _db.SparepartTbl.Where(x => x.SparepartCode == "SC" + DateTime.Now.ToString("yyMM") + "0001").FirstOrDefault();

            string tempSubId = "";
            int tempId;

            if (data == null)
            {
                id = "SC" + DateTime.Now.ToString("yyMM") + "0001";

            }
            else
            {

                var xx = (from a in _db.SparepartTbl
                          where a.SparepartCode.Substring(0, 6) == "SC" + DateTime.Now.ToString("yyMM")
                          select a).Max(a => a.SparepartCode);

                tempSubId = xx.Substring(6, 4);
                tempId = Convert.ToInt32(tempSubId);
                tempId = tempId + 1;

                if (tempId.ToString().Length == 1)
                {
                    id = "SC" + DateTime.Now.ToString("yyMM") + "000" + tempId;
                }
                else if (tempId.ToString().Length == 2)
                {
                    id = "SC" + DateTime.Now.ToString("yyMM") + "00" + tempId;
                }
                else if (tempId.ToString().Length == 3)
                {
                    id = "SC" + DateTime.Now.ToString("yyMM") + "0" + tempId;
                }
                else if (tempId.ToString().Length == 4)
                {
                    id = "SC" + DateTime.Now.ToString("yyMM") + tempId;
                }


            }

            return id;
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

            ViewBag.UOM = new List<SelectListItem>
            {
              new SelectListItem { Text="Pcs", Value="Pcs"},
              new SelectListItem { Text="Kg", Value="Kg"},
            };

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