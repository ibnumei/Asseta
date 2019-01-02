using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetaWeb.Controllers
{
    public class TaskController : Controller
    {
        private readonly assetaDbContext _db;

        public TaskController(assetaDbContext db)
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
                //var customerData = (from tempcustomer in _db.AssetGroupTbl
                //                    select tempcustomer);
                var customerData = from a in _db.TaskTbl
                                   join b in _db.AssetGroupTbl on a.AssetGroupId equals b.AssetGroupId
                                   select new { a.TaskId, a.TaskCode, a.TaskDetail, a.Date, a.TimeEstimate, b.AssetGroupName};

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.TaskCode == searchValue);
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
        //Get Processing Data tables
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
                var getcode = _db.TaskTbl.Where(x => x.TaskId == id).First().TaskCode;

                var customerData = (from tempcustomer in _db.TaskLineTbl
                                    where tempcustomer.TaskCode == getcode
                                    select tempcustomer);

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.TaskCode == searchValue);
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
        //Create Task Lines
        public async Task<IActionResult> TaskLines(long id)
        {
            ViewBag.type = new List<SelectListItem>
            {
              new SelectListItem { Text="General", Value="General"},
              new SelectListItem { Text="Yes / No", Value="Yes / No"},
              new SelectListItem { Text="Checklist", Value="Checklist"}
            };

            if (id == null)
            {
                return NotFound();
            }
            var assetgroup = await _db.TaskTbl.SingleOrDefaultAsync(m => m.TaskId == id);
            var getcode = _db.TaskTbl.Where(x => x.TaskId == id).First().TaskCode;
            if (assetgroup == null)
            {
                return NotFound();
            }
            //parsing id task header ke tampilan task lines agar dicari task code nya, lalu dicari task code sesuai task code yg di dapat 
            ViewBag.TaskId = id;
            ViewBag.TaskCode = getcode;
            return View();
            
        }
        //===================================================================================
        //View Create Data
        public IActionResult Create()
        {
            ViewBag.Daily = new List<SelectListItem>
            {
              new SelectListItem { Text="General", Value="General"},
              new SelectListItem { Text="Yes / No", Value="Yes / No"},
              new SelectListItem { Text="Checklist", Value="Checklist"}
            };
            ViewBag.AssetGroupId = new SelectList(_db.AssetGroupTbl, "AssetGroupId", "AssetGroupName");

            return View();
        }
        //Action Create Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskTbl taskTbl)
        {
            if (ModelState.IsValid)
            {
                taskTbl.Date = DateTime.Now;
                taskTbl.CreatedAtTask = DateTime.Now;
                taskTbl.ModifyAtTask = DateTime.Now;
                _db.Add(taskTbl);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskTbl);
        }
        //===================================================================================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taskmaster = await _db.TaskTbl.SingleOrDefaultAsync(m => m.TaskId == id);
            if (taskmaster == null)
            {
                return NotFound();
            }
            ViewBag.AssetGroupId = new SelectList(_db.AssetGroupTbl, "AssetGroupId", "AssetGroupName");
            return View(taskmaster);
        }


        //Method Edit Proses
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, TaskTbl task)
        {
            // var create = _db.SiteMasterTbl.Where(m => m.SiteId == siteMaster.SiteId).First().CreatedAtSite;
            if (id != task.TaskId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //
                //siteMaster.CreatedAtSite = create;
                task.ModifyAtTask = DateTime.Now;
                _db.Update(task);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
        //===================================================================================
        //Action Create Task Line
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTaskLine(TaskLineTbl taskLine)
        {
            var taskcode = taskLine.TaskCode;
            var a = _db.TaskTbl.Where(x => x.TaskCode == taskcode).First().TaskId;

            if (ModelState.IsValid)
            {
                _db.Add(taskLine);
                await _db.SaveChangesAsync();
                //mengarahkan ke method laen dengan nama TaskLines dan dengan value id
                return RedirectToAction("TaskLines", new {id = a });
            }
            return View(taskLine);
        }

        //===============================================================================
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var task = _db.TaskTbl.Find(id);
            _db.TaskTbl.Remove(task);
            _db.SaveChanges();

            return Json(new { success = true });
        }

        //===============================================================================
        [HttpPost]
        public ActionResult DeleteTaskLine(long id)
        {
            var taskline = _db.TaskLineTbl.Find(id);
            _db.TaskLineTbl.Remove(taskline);
            _db.SaveChanges();

            return Json(new { success = true });
        }
    }
}