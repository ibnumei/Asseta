using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetaWeb.Controllers
{
    public class WorkOrderController : Controller
    {
        private readonly assetaDbContext _db;

        public WorkOrderController(assetaDbContext db)
        {
            _db = db;
        }

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
                var customerData = (from tempcustomer in _db.WorkOrderTbl
                                    select tempcustomer);
                //var customerData = from a in _db.WorkOrderTbl
                //                   join b in _db.TechnicianTbl on a.TechnicianId equals b.TechnicianId
                //                   select new { a.WoId, a.WoDesc, a.Status, a.Priority};

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.WoId == Convert.ToInt32(searchValue));
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
            ViewBag.status = new List<SelectListItem>
            {
              new SelectListItem { Text="Normal", Value="General"},
              new SelectListItem { Text="In Approval", Value="In Approval"},
              new SelectListItem { Text="Approved", Value="Approved"},
              new SelectListItem { Text="In Execution", Value="In Execution"},
              new SelectListItem { Text="Complete", Value="Complete"}
            };

            ViewBag.priority = new List<SelectListItem>
            {
              new SelectListItem { Text="Normal", Value="General"},
              new SelectListItem { Text="Urgent", Value="Urgent"}
            };
            ViewBag.Technicians = _db.TechnicianTbl.ToList();
            ViewBag.Schedule = _db.ScheduleMaintenanceTbl.ToList();
            ViewBag.Asset = _db.AssetTbl.ToList();
            ViewBag.Entity = _db.EntityTbl.ToList();
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
        //========================================================================
        //public async Task<IActionResult> Edit(int? id)
        public async Task<IActionResult> Edit(int? id)
        {
            var wo = await _db.WorkOrderTbl.SingleOrDefaultAsync(m => m.WoId == id);
            var sche_id = wo.MaentenanceId;
            var task_code = wo.EntityId;

            ViewBag.status = new List<SelectListItem>
            {
              new SelectListItem { Text="Normal", Value="General"},
              new SelectListItem { Text="In Approval", Value="In Approval"},
              new SelectListItem { Text="Approved", Value="Approved"},
              new SelectListItem { Text="In Execution", Value="In Execution"},
              new SelectListItem { Text="Complete", Value="Complete"}
            };

            ViewBag.priority = new List<SelectListItem>
            {
              new SelectListItem { Text="Normal", Value="General"},
              new SelectListItem { Text="Urgent", Value="Urgent"}
            };

            var customerData = from a in _db.ScheduleSparepartLinesTbl
                               join b in _db.SparepartTbl on a.SparepartId equals b.SparepartId
                               select new { a.SparepartId, a.Quantity, b.SparepartDesc };

            //var Sparepart = from a in _db.ScheduleMaintenanceTbl
            //                join b in _db.ScheduleSparepartLinesTbl on a.ScheduleMainId equals b.ScheduleMainId
            //                join c in _db.SparepartTbl on b.SparepartId equals c.SparepartId
            //                select new { c.SparepartDesc, b.Quantity };

          //  var schee = _db.SparepartTbl;

            //ViewBag.SparepartLines = _db.ScheduleSparepartLinesTbl.Where(x => x.ScheduleMainId == sche_id).Join(schee, x =>x.SparepartId, s=>s.SparepartId,(x,s) => s.SparepartDesc).ToList();

           // ViewBag.SparepartLines2 = Sparepart.Include(x=>x.SparepartDesc).ToList();

            ViewBag.SparepartLines3 = _db.ScheduleSparepartLinesTbl.Include(d=>d.Sparepart).Where(x => x.ScheduleMainId == sche_id).ToList();

            ViewBag.taskline = _db.TaskLineTbl.Where(x => x.TaskCode == task_code.ToString()).ToList();

            ViewBag.Technicians = _db.TechnicianTbl.ToList();
            ViewBag.Schedule = _db.ScheduleMaintenanceTbl.ToList();
            ViewBag.Asset = _db.AssetTbl.ToList();
            ViewBag.Entity = _db.EntityTbl.ToList();
            ViewBag.Site = _db.SiteMasterTbl.ToList();
            return View(wo);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, WorkOrderTbl workOrder)
        {
            if (id != workOrder.WoId)
            {
                return NotFound();
            }

            //var a = Convert.ToBoolean(workOrder.SparepartActive);
            //var b = "";
            //if (a == true)
            //{
            //    b = "Active";
            //}
            //else
            //{
            //    b = "Non Active";
            //}

            if (ModelState.IsValid)
            {

                //workOrder.SparepartActive = b;
                //_db.Add(workOrder);
                //await _db.SaveChangesAsync();
                _db.Update(workOrder);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrder);
        }
        //=========================================================================================
        [HttpPost]
        public ActionResult Run(long id)
        {
            WorkOrderTbl wotbl = _db.WorkOrderTbl.Where(x => x.WoId == id).First();

            string woeid = "";
            woeid = generateRunningNumber(woeid);

            WoExecutionTbl woe = new WoExecutionTbl();
            woe.WoId = wotbl.WoId;
            woe.Date = DateTime.Now;
            woe.SiteId = wotbl.SiteId;
            woe.TechnicianId = wotbl.TechnicianId;
            woe.WoDesc = wotbl.WoDesc;
            woe.WorkExeId = woeid;
            woe.MaintenanceId = wotbl.MaentenanceId;
            woe.Status = "Not Started";

            _db.WoExecutionTbl.Add(woe);
            _db.SaveChanges();

            var IdWoe = _db.WoExecutionTbl.Where(x => x.WoId == wotbl.WoId).First().Id;
            if (wotbl.SparepartActive == true)
            {
                List<ScheduleSparepartLinesTbl> spline = _db.ScheduleSparepartLinesTbl.Where(x => x.ScheduleMainId == wotbl.MaentenanceId).ToList();
                for (int i = 0; i < spline.Count; i++)
                {
                    WoExeSparepartTbl wosptb = new WoExeSparepartTbl();
                    wosptb.WoExeId = IdWoe;
                    wosptb.SparepartId = spline[i].SparepartId;
                    wosptb.SparepartCode = _db.SparepartTbl.Where(x => x.SparepartId == spline[i].SparepartId).First().SparepartCode;
                    wosptb.Quantity = 0;

                    _db.WoExeSparepartTbl.Add(wosptb);
                    _db.SaveChanges();
                }
            }


            List<TaskLineTbl> tskline = _db.TaskLineTbl.Where(x => x.TaskCode == wotbl.EntityId).ToList();
            for (int i = 0; i < tskline.Count; i++)
            {
                WoExeTaskTbl wotsk = new WoExeTaskTbl();
                wotsk.WoExeId = IdWoe;
                wotsk.TaskCode = tskline[i].TaskCode;
                wotsk.Detail = tskline[i].TaskName;
                wotsk.TaskType = tskline[i].TaskType;

                _db.WoExeTaskTbl.Add(wotsk);
                _db.SaveChanges();

            }




            return Json(new { success = true });
        }

        //GENERATE RUNNING NUMBER
        private String generateRunningNumber(string woeid)
        {
            WoExecutionTbl data = _db.WoExecutionTbl.Where(x => x.WorkExeId == "WOE" + DateTime.Now.ToString("yyMM") + "0001").FirstOrDefault();

            string tempPriceId = "";
            int tempId;

            if (data == null)
            {
                woeid = "WOE" + DateTime.Now.ToString("yyMM") + "0001";

            }
            else
            {

                var xx = (from a in _db.WoExecutionTbl
                          where a.WorkExeId.Substring(0, 7) == "WOE" + DateTime.Now.ToString("yyMM")
                          select a).Max(a => a.WorkExeId);

                tempPriceId = xx.Substring(7, 4);
                tempId = Convert.ToInt32(tempPriceId);
                tempId = tempId + 1;

                if (tempId.ToString().Length == 1)
                {
                    woeid = "WOE" + DateTime.Now.ToString("yyMM") + "000" + tempId;
                }
                else if (tempId.ToString().Length == 2)
                {
                    woeid = "WOE" + DateTime.Now.ToString("yyMM") + "00" + tempId;
                }
                else if (tempId.ToString().Length == 3)
                {
                    woeid = "WOE" + DateTime.Now.ToString("yyMM") + "0" + tempId;
                }
                else if (tempId.ToString().Length == 4)
                {
                    woeid = "WOE" + DateTime.Now.ToString("yyMM") + tempId;
                }


            }

            return woeid;
        }

    }
}