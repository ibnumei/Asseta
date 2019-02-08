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
                                   join d in _context.PeriodTbl on a.PeriodId equals d.PeriodId
                                   select new { a.ScheduleMainId , b.AssetName, a.MaintenanceDesc, d.PeriodType , a.LastMaintenance, a.NextMaintenance };
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

        public ActionResult getget2(string aidi)
        {
            var getdetail = "";
            var gettime = "";
            if(aidi == null)
            {
                getdetail = null;
                gettime = null;
            }
            else
            {
                int id = Convert.ToInt32(aidi);
                 getdetail = _context.TaskTbl.Where(x => x.TaskId == id).First().TaskDetail;
                 gettime = _context.TaskTbl.Where(x => x.TaskId == id).First().TimeEstimate.ToString();
            }
            

            List<string> asd = new List<string>();
            asd.Add(getdetail);
            asd.Add(gettime);



            return Json(asd);
        }

        public ActionResult getget3(string aidi)
        {
            int id = Convert.ToInt32(aidi);
           // var getdetail = _context.TaskTbl.Where(x => x.TaskId == id).First().TaskDetail;
            var gettime = _context.TaskTbl.Where(x => x.TaskId == id).First().TimeEstimate;

            List<int?> asd = new List<int?>();
            asd.Add(gettime);


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
            ViewBag.Tanggal = DateTime.Now.ToShortDateString();
            // mm/dd/yyyy
            return View();
        }

        // POST: ScheduleMaintenance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleMaintenanceTbl scheduleMaintenanceTbl)
        {
            var assetnamess = _context.AssetTbl.Where(x => x.AssetId == scheduleMaintenanceTbl.AssetId).First().AssetName;
            var period = _context.PeriodTbl.Where(x => x.PeriodId == scheduleMaintenanceTbl.PeriodId).First().Days;


            if (ModelState.IsValid)
            {
                scheduleMaintenanceTbl.LastMaintenance = DateTime.Now;
                scheduleMaintenanceTbl.AssetName = assetnamess;
                scheduleMaintenanceTbl.NextMaintenance = DateTime.Now.AddDays((double)period);
                //if(scheduleMaintenanceTbl.)
                //{

                //}
              //  scheduleMaintenanceTbl.LastEditedBy = DateTime.Now;
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

            //ViewBag.ASSETID = new SelectList(_context.AssetTbl, "AssetId", "AssetCode");
            //ViewBag.SITEID = new SelectList(_context.SiteMasterTbl, "SiteId", "SiteName");
            //ViewBag.PERIODID = new SelectList(_context.PeriodTbl, "PeriodId", "PeriodType");
            //ViewBag.SPAREPARTID = new SelectList(_context.SparepartTbl, "SparepartId", "SparepartCode");
            //ViewBag.TASKID = new SelectList(_context.TaskTbl, "TaskId", "TaskCode");
            //ViewBag.TECHNICIANID = new SelectList(_context.TechnicianTbl, "TechnicianId", "TechnicianName");

            ViewBag.ASSETID = _context.AssetTbl.ToList();
            ViewBag.SITEID = _context.SiteMasterTbl.ToList();
            ViewBag.PERIODID = _context.PeriodTbl.ToList();
            ViewBag.SPAREPARTID = _context.SparepartTbl.ToList();
            ViewBag.TASKID = _context.TaskTbl.ToList();
            ViewBag.TECHNICIANID = _context.TechnicianTbl.ToList();

            return View(scheduleMaintenanceTbl);
        }

        // POST: ScheduleMaintenance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ScheduleMaintenanceTbl scheduleMaintenanceTbl)
        {
            scheduleMaintenanceTbl.ScheduleMainId = id;
            //if (id != scheduleMaintenanceTbl.ScheduleMainId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                scheduleMaintenanceTbl.AssetName = scheduleMaintenanceTbl.AssetName;
                    _context.Update(scheduleMaintenanceTbl);
                    await _context.SaveChangesAsync();
   
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleMaintenanceTbl);
        }

        // GET: ScheduleMaintenance/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var scheduleMaintenanceTbl = await _context.ScheduleMaintenanceTbl
        //        .FirstOrDefaultAsync(m => m.ScheduleMainId == id);
        //    if (scheduleMaintenanceTbl == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(scheduleMaintenanceTbl);
        //}

        // POST: ScheduleMaintenance/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var scheduleMaintenanceTbl = await _context.ScheduleMaintenanceTbl.FindAsync(id);
        //    _context.ScheduleMaintenanceTbl.Remove(scheduleMaintenanceTbl);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var task = _context.ScheduleMaintenanceTbl.Find(id);
            _context.ScheduleMaintenanceTbl.Remove(task);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        private bool ScheduleMaintenanceTblExists(long id)
        {
            return _context.ScheduleMaintenanceTbl.Any(e => e.ScheduleMainId == id);
        }

        public async Task<IActionResult> ScheduleSpareparts(long id)
        {
            ViewBag.type = new List<SelectListItem>
            {
              new SelectListItem { Text="General", Value="General"},
              new SelectListItem { Text="Yes / No", Value="Yes / No"},
              new SelectListItem { Text="Checklist", Value="Checklist"}
            };

            ViewBag.SPAREPARTID = new SelectList(_context.SparepartTbl, "SparepartId", "SparepartCode");

            if (id == null)
            {
                return NotFound();
            }
            var getcode = _context.ScheduleMaintenanceTbl.Where(x => x.ScheduleMainId == id).First().MaintenanceId;
            ViewBag.TaskId = id;
            ViewBag.MaintenanceId = getcode;
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSchedulParts(ScheduleSparepartLinesTbl partLines)
        {
            var t = partLines.ScheduleMainId;
            var a = _context.ScheduleMaintenanceTbl.Where(x => x.ScheduleMainId == t).First().ScheduleMainId;

            if (ModelState.IsValid)
            {
                _context.Add(partLines);
                await _context.SaveChangesAsync();
                //mengarahkan ke method laen dengan nama TaskLines dan dengan value id
                return RedirectToAction("ScheduleSpareparts", new { id = a });
            }
            return View(partLines);
        }


        public IActionResult LoadDataLine(int? id)
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
                var getcode = _context.ScheduleMaintenanceTbl.Where(x => x.ScheduleMainId == id).First().ScheduleMainId;

                //var customerData = (from tempcustomer in _context.ScheduleSparepartLinesTbl
                //                    where tempcustomer.ScheduleMainId == getcode
                //                    select tempcustomer);

                var customerData = from a in _context.ScheduleSparepartLinesTbl.Where(x=>x.ScheduleMainId == getcode)
                                   join b in _context.SparepartTbl on a.SparepartId equals b.SparepartId
                                   join c in _context.ScheduleMaintenanceTbl on a.ScheduleMainId equals c.ScheduleMainId
                                   select new { a.Id , c.ScheduleMainId , c.MaintenanceId , b.SparepartCode , a.Quantity};


                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.ScheduleMainId.ToString() == searchValue);
                //}

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

        [HttpPost]
        public ActionResult DeleteScheParts(long id)
        {
            var taskline = _context.ScheduleSparepartLinesTbl.Find(id);
            _context.ScheduleSparepartLinesTbl.Remove(taskline);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult CreateWoTas(long id)
        {
            ScheduleMaintenanceTbl schdl = _context.ScheduleMaintenanceTbl.Where(x => x.ScheduleMainId == id).First();

            WorkOrderTbl wo = new WorkOrderTbl();
            wo.AssetId = schdl.AssetId;
            wo.SiteId = schdl.SiteId;
            wo.TechnicianId = schdl.TechnicianId;
            wo.WoDesc = schdl.MaintenanceDesc;
            wo.MaentenanceId = schdl.ScheduleMainId;
            wo.RequestId = null;
            wo.Date = DateTime.Now;
            wo.CreatedAtWo = DateTime.Now;
            wo.EstimatedWorking = schdl.EstimatedTime;
            wo.TaskDetail = schdl.TaskDetail;
            wo.EntityId = _context.TaskTbl.Where(x=>x.TaskId == schdl.TaskId).First().TaskCode;

            
            _context.WorkOrderTbl.Add(wo);
            _context.SaveChanges();

            

            ScheduleMaintenanceTbl schdl2 = _context.ScheduleMaintenanceTbl.Where(x => x.ScheduleMainId == id).First();
            schdl2.Sended = true;
            schdl2.LastMaintenance = DateTime.Now;
            _context.Update(schdl2);
            _context.SaveChanges();

            return Json(new { success = true });   
        }
      
    }
}
