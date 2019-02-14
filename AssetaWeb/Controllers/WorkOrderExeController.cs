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
                                   select new { a.Id, a.WorkExeId, a.WoDesc, a.Date, a.Status, b.TechnicianName };

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
            var wo = await _db.WoExecutionTbl.SingleOrDefaultAsync(m => m.Id == id);
            ViewBag.Aidi = id.ToString();

            //menggunakan 2model untuk 1 view, dari tabel wo exe dan wo exe task
            WoExeAndWoExeTask vm = new WoExeAndWoExeTask();
            vm.WoExecution = wo;
            vm.WoExeTask = _db.WoExeTaskTbl.Where(x => x.WoExeId == wo.Id).ToList();

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
            ViewBag.TECHNICIANID = _db.TechnicianTbl.ToList();
            ViewBag.SITEID = _db.SiteMasterTbl.ToList();
            ViewBag.typetask = new List<SelectListItem>
            {
              new SelectListItem { Text="Yes", Value="Yes"},
              new SelectListItem { Text="No", Value="No"}
            };
            //=================================================================================


            return View(vm);


        }
        //============================================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Run(long id, WoExeAndWoExeTask woexe)
        {
            if (id != woexe.WoExecution.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {

                woexe.WoExecution.Status = "Complete";
                _db.Update(woexe.WoExecution);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(woexe);
        }
        //============================================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveWoExeTask(WoExeAndWoExeTask woExeTask)
        {
            // var data =  _db.WoExeTaskTbl.Where(m => m.Id == woExeTask.noListWoTask.Id).First();

            if (ModelState.IsValid)
            {
                //woExeTask.noListWoTask.WoExeId = data.WoExeId;
                //woExeTask.noListWoTask.TaskCode = data.TaskCode;
                //woExeTask.noListWoTask.Detail = data.Detail;
                //woExeTask.noListWoTask.TaskType = data.TaskType;

                _db.Update(woExeTask.noListWoTask);
                _db.SaveChanges();
            }
            return new EmptyResult();
        }
        //============================================================================================
        [HttpPost]
        public ActionResult UpdateCustomer(List<string> listkey)
        {
            var t = listkey;

            string quant = t[0];
            string spares = t[1];
            string aidi = t[2];

            WoExeSparepartTbl woExe = _db.WoExeSparepartTbl.Where(x => x.WoExeId == Convert.ToInt64(aidi) && x.SparepartCode == spares).First();
            woExe.Quantity = Convert.ToInt32(quant);
            _db.Update(woExe);
            _db.SaveChanges();


            return new EmptyResult();
        }
        //========================================================================================================
        [HttpPost]
        public ActionResult WoExeTask(List<string> listkey)
        {
            var t = listkey;

            string id = t[0];
            string text_value = t[1];

            WoExeTaskTbl woExe = _db.WoExeTaskTbl.Where(x => x.Id == Convert.ToInt64(id)).FirstOrDefault(); ;
            woExe.TypeGeneral = text_value;
            _db.Update(woExe);
            _db.SaveChanges();


            return new EmptyResult();
        }
        //========================================================================================================
    }
}