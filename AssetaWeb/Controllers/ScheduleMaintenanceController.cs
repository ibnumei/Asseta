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
    public class ScheduleMaintenanceController : Controller
    {
        private readonly assetaDbContext _context;

        public ScheduleMaintenanceController(assetaDbContext context)
        {
            _context = context;
        }

        // GET: ScheduleMaintenance
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScheduleMaintenanceTbl.Include(x=>x.ASSETS).Include(x=>x.SITES).Include(x=>x.PERIODS).Include(x=>x.SPAREPARTS).Include(x=>x.TECHNICIANS).Include(x=>x.TASKS).ToListAsync());
        }

        //LOAD DATA TO JSON
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
                var customerData = from a in _context.ScheduleMaintenanceTbl
                                   join b in _context.AssetTbl on a.AssetId equals b.AssetId
                                   join c in _context.SiteMasterTbl on a.SiteId equals c.SiteId
                                   join d in _context.PeriodTbl on a.PeriodId equals d.PeriodId
                                   join e in _context.SparepartTbl on a.SparepartId equals e.SparepartId
                                   join f in _context.TechnicianTbl on a.TechnicianId equals f.TechnicianId
                                   join g in _context.TaskTbl on a.TaskId equals g.TaskId
                                   select new { b.AssetName, a.MaintenanceDesc, a.Schedule, a.LastMaintenance, a.NextMaintenance };
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
                    customerData = customerData.Where(m => m.MaintenanceDesc == searchValue);
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

        // 
        public ActionResult getget(string aidi)
        {
            int id = Convert.ToInt32(aidi);
            var getassetname = _context.AssetTbl.Where(x => x.AssetId == id).First().AssetName;

            List<string> asd = new List<string>();
            asd.Add(getassetname);


            return Json(asd);
        }

        // GET: ScheduleMaintenance/Create
        public IActionResult Create()
        {
            ViewBag.ASSETID = new SelectList(_context.AssetTbl, "AssetId", "AssetCode");
            ViewBag.SITEID = new SelectList(_context.SiteMasterTbl, "SiteId", "SiteName");
            ViewBag.PERIODID = new SelectList(_context.PeriodTbl, "PeriodId", "PeriodType");
            ViewBag.SPAREPARTID = new SelectList(_context.SparepartTbl, "SparepartId", "SparepartCode");
            ViewBag.TASKID = new SelectList(_context.TaskTbl, "TaskId", "TaskCode");
            ViewBag.TECHNICIANID = new SelectList(_context.TechnicianTbl, "TechnicianId", "TechnicianName");

            return View();
        }

        // POST: ScheduleMaintenance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetId,MaintenanceId,MaintenanceDesc,SiteId,LastMaintenance,NextMaintenance,CreateBy,LastEditedBy,PeriodId,SparepartId,Quantity,TaskId,TaskDetail,EstimatedTime,TechnicianId")] ScheduleMaintenanceTbl scheduleMaintenanceTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleMaintenanceTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleMaintenanceTbl);
        }

        // GET: ScheduleMaintenance/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleMaintenanceTbl = await _context.ScheduleMaintenanceTbl.FindAsync(id);
            if (scheduleMaintenanceTbl == null)
            {
                return NotFound();
            }
            return View(scheduleMaintenanceTbl);
        }

        // POST: ScheduleMaintenance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,AssetId,MaintenanceId,MaintenanceDesc,SiteId,LastMaintenance,NextMaintenance,CreateBy,LastEditedBy,PeriodId,SparepartId,Quantity,TaskId,TaskDetail,EstimatedTime,TechnicianId")] ScheduleMaintenanceTbl scheduleMaintenanceTbl)
        {
            if (id != scheduleMaintenanceTbl.ScheduleMainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleMaintenanceTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleMaintenanceTblExists(scheduleMaintenanceTbl.ScheduleMainId))
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
            return View(scheduleMaintenanceTbl);
        }

        // GET: ScheduleMaintenance/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleMaintenanceTbl = await _context.ScheduleMaintenanceTbl
                .FirstOrDefaultAsync(m => m.ScheduleMainId == id);
            if (scheduleMaintenanceTbl == null)
            {
                return NotFound();
            }

            return View(scheduleMaintenanceTbl);
        }

        // POST: ScheduleMaintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var scheduleMaintenanceTbl = await _context.ScheduleMaintenanceTbl.FindAsync(id);
            _context.ScheduleMaintenanceTbl.Remove(scheduleMaintenanceTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleMaintenanceTblExists(long id)
        {
            return _context.ScheduleMaintenanceTbl.Any(e => e.ScheduleMainId == id);
        }
    }
}
