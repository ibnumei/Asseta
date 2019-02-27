using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic;

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
                var customerData = (from tempcustomer in _db.SiteMasterTbl
                                    select tempcustomer);

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    //customerData = customerData.Where(m => m.SiteCode == searchValue);
                    customerData = customerData.Where(m => m.SiteCode.Contains(searchValue) || m.SiteName.Contains(searchValue));
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
                String idrunning = "";
                idrunning = generateRunningNumber(idrunning);

                siteMaster.SiteCode = idrunning;
                siteMaster.ModifyAtSite = DateTime.Now;
                siteMaster.CreatedAtSite = DateTime.Now;
                _db.Add(siteMaster);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteMaster);
        }
        //=========================================================================================================
        //GENERATE RUNNING NUMBER
        private String generateRunningNumber(string id)
        {
            SiteMasterTbl data = _db.SiteMasterTbl.Where(x => x.SiteCode == "ST" + DateTime.Now.ToString("yyMM") + "0001").FirstOrDefault();

            string tempSubId = "";
            int tempId;

            if (data == null)
            {
                id = "ST" + DateTime.Now.ToString("yyMM") + "0001";

            }
            else
            {

                var xx = (from a in _db.SiteMasterTbl
                          where a.SiteCode.Substring(0, 6) == "ST" + DateTime.Now.ToString("yyMM")
                          select a).Max(a => a.SiteCode);

                tempSubId = xx.Substring(6, 4);
                tempId = Convert.ToInt32(tempSubId);
                tempId = tempId + 1;

                if (tempId.ToString().Length == 1)
                {
                    id = "ST" + DateTime.Now.ToString("yyMM") + "000" + tempId;
                }
                else if (tempId.ToString().Length == 2)
                {
                    id = "ST" + DateTime.Now.ToString("yyMM") + "00" + tempId;
                }
                else if (tempId.ToString().Length == 3)
                {
                    id = "ST" + DateTime.Now.ToString("yyMM") + "0" + tempId;
                }
                else if (tempId.ToString().Length == 4)
                {
                    id = "ST" + DateTime.Now.ToString("yyMM") + tempId;
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
        public async Task<IActionResult> Edit(long id, SiteMasterTbl siteMaster)
        {
           // var create = _db.SiteMasterTbl.Where(m => m.SiteId == siteMaster.SiteId).First().CreatedAtSite;
            if (id != siteMaster.SiteId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //
                //siteMaster.CreatedAtSite = create;
                siteMaster.ModifyAtSite = DateTime.Now;
                _db.Update(siteMaster);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(siteMaster);
        }
        //=========================================================================================================
        //Delete
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var sitemaster = await _db.SiteMasterTbl.SingleOrDefaultAsync(m => m.SiteId == id);
        //    if (sitemaster == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(sitemaster);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var sitemaster = await _db.SiteMasterTbl.SingleOrDefaultAsync(m => m.SiteId == id);
        //    _db.SiteMasterTbl.Remove(sitemaster);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        //=========================================================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DelNoView(int id)
        {
            var sitemaster = await _db.SiteMasterTbl.SingleOrDefaultAsync(m => m.SiteId == id);
            _db.SiteMasterTbl.Remove(sitemaster);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public ActionResult Delete(long id )
        {
            var sparepart = _db.SiteMasterTbl.Find(id);
            _db.SiteMasterTbl.Remove(sparepart);
            _db.SaveChanges();

            return Json(new { success = true });
        }
    }
}