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
    public class SparepartRequestController : Controller
    {
        private readonly assetaDbContext _context;

        public SparepartRequestController(assetaDbContext context)
        {
            _context = context;
        }

        // GET: SparepartRequest
        public async Task<IActionResult> Index()
        {
            return View(await _context.SparepartRequestTbl.ToListAsync());
        }

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
                var customerData = from a in _context.SparepartRequestTbl
                                   join b in _context.WorkOrderTbl on a.WoId equals b.WoId
                                   select new { a.Id ,a.Availability ,a.SparepartRequestId  , b.WoDesc , a.Date , a.Status};
                //join c in _context.AssetGroupTbl on a.AssetGroupId equals c.AssetGroupId
                //join d in _context.EntityTbl on a.EntityId equals d.EntityId
                //select new { a.AssetId, a.AssetCode, a.AssetName, a.SerialNumber, a.ValidityDate, a.Location, a.Valuation, b.SiteName, c.AssetGroupName, d.EntityName };

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.SparepartRequestId == searchValue);
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

        // GET: SparepartRequest/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sparepartRequestTbl = await _context.SparepartRequestTbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sparepartRequestTbl == null)
            {
                return NotFound();
            }

            return View(sparepartRequestTbl);
        }

        // GET: SparepartRequest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SparepartRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Availability,SparepartRequestId,WoId,WoDesc,Date,Status,SiteId,Qty,Notes")] SparepartRequestTbl sparepartRequestTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sparepartRequestTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } 
            return View(sparepartRequestTbl);
        }

        // GET: SparepartRequest/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sparepartRequestTbl = await _context.SparepartRequestTbl.FindAsync(id);
            if (sparepartRequestTbl == null)
            {
                return NotFound();
            }

            
            var checknull = _context.WorkOrderTbl.Where(x => x.WoId == sparepartRequestTbl.WoId).First();

            if (checknull.MaentenanceId == null)
            {
                //   ViewBag.Sparepart = _context.WoRequestSpartpartLineTbl.Include(x=>x.Sparepart).Where(x => x.WoRequestId == checknull.RequestId);
                ViewBag.Sparepart = _context.SparepartRequestLinesTbl.Include(x=>x.Sparepart).Where(x => x.SprId == id);
            }
            else
            {
                //  ViewBag.Sparepart = _context.ScheduleSparepartLinesTbl.Include(x => x.Sparepart).Where(x => x.ScheduleMainId == checknull.MaentenanceId);
                ViewBag.Sparepart = _context.SparepartRequestLinesTbl.Include(x => x.Sparepart).Where(x => x.SprId == id);
            }

            var getcode = _context.SparepartRequestTbl.Where(x => x.Id == id).First();
            ViewBag.Id = id;
            ViewBag.RequestId = getcode.SparepartRequestId;
            ViewBag.Woaidi = getcode.WoId;
            ViewBag.WoDesc = getcode.WoDesc;
            ViewBag.Dates = getcode.Date;
            ViewBag.SiteId = _context.SiteMasterTbl.Where(x => x.SiteId == getcode.SiteId).First().SiteName;
            return View(sparepartRequestTbl);
        }

        // POST: SparepartRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Availability,SparepartRequestId,WoId,WoDesc,Date,Status,SiteId,Qty,Notes")] SparepartRequestTbl sparepartRequestTbl)
        {
            if (id != sparepartRequestTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sparepartRequestTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SparepartRequestTblExists(sparepartRequestTbl.Id))
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
            return View(sparepartRequestTbl);
        }

        // GET: SparepartRequest/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sparepartRequestTbl = await _context.SparepartRequestTbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sparepartRequestTbl == null)
            {
                return NotFound();
            }

            return View(sparepartRequestTbl);
        }

        // POST: SparepartRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sparepartRequestTbl = await _context.SparepartRequestTbl.FindAsync(id);
            _context.SparepartRequestTbl.Remove(sparepartRequestTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SparepartRequestTblExists(long id)
        {
            return _context.SparepartRequestTbl.Any(e => e.Id == id);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(List<string> listkey)
        {
            var t = listkey;

            string quant = t[0];
            string spares = t[1];
            string aidi = t[2];
            string woaidi = t[3];

            //WoExeSparepartTbl woExe = _context.WoExeSparepartTbl.Where(x => x.WoExeId == Convert.ToInt64(aidi) && x.SparepartCode == spares).First();
            //woExe.Quantity = Convert.ToInt32(quant);
            //_context.Update(woExe);
            //_context.SaveChanges();

            SparepartRequestLinesTbl spas = _context.SparepartRequestLinesTbl.Where(x => x.SprId == Convert.ToInt64(aidi) && x.SparepartCode == spares).First();
            spas.Quantity = Convert.ToInt32(quant);
            _context.Update(spas);
            _context.SaveChanges();

            return new EmptyResult();
        }

    }
}
