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
    public class WorkOrderExeController : Controller
    {
        private readonly assetaDbContext _db;

        public WorkOrderExeController(assetaDbContext db)
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
                //var customerData = (from tempcustomer in _db.WoExecutionTbl
                //                    select tempcustomer);
                var customerData = from a in _db.WoExecutionTbl
                                   join b in _db.TechnicianTbl on a.TechnicianId equals b.TechnicianId
                                   select new { a.Id, a.WorkExeId, a.WoDesc, a.Date, a.Status, b.TechnicianName};

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.WorkExeId == searchValue);
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

        //========================================================================
        public async Task<IActionResult> Run(int? id)
        //public IActionResult Create()
        {
            var wo = await _db.WoExecutionTbl.SingleOrDefaultAsync(m => m.WoId == id);

            //var sche_id = wo.MaentenanceId;
            //var task_code = wo.EntityId;

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

            //ViewBag.SparepartLines3 = _db.ScheduleSparepartLinesTbl.Include(d => d.Sparepart).Where(x => x.ScheduleMainId == sche_id).ToList();

            //ViewBag.taskline = _db.TaskLineTbl.Where(x => x.TaskCode == task_code.ToString()).ToList();

            //=================================================================================
            ViewBag.Task = _db.WoExeTaskTbl.Where(x => x.WoExeId == wo.Id);
            ViewBag.Sparepart = _db.WoExeSparepartTbl.Where(x => x.WoExeId == wo.Id);
            //=================================================================================


            return View(wo);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Run(long id, WoExecutionTbl workOrder)
        {
            if (id != workOrder.Id)
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
                workOrder.Status = "Complete";
                _db.Update(workOrder);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrder);
        }
    }
}