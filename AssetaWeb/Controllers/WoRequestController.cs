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
    public class WoRequestController : Controller
    {
        private readonly assetaDbContext _context;

        public WoRequestController(assetaDbContext context)
        {
            _context = context;
        }

        // GET: WoRequest
        public async Task<IActionResult> Index()
        {
            return View(await _context.WoRequestTbl.ToListAsync());
        }

        public async Task<IActionResult> Views(long id)
        {
            ViewBag.type = new List<SelectListItem>
            {
              new SelectListItem { Text="General", Value="General"},
              new SelectListItem { Text="Yes / No", Value="Yes / No"},
              new SelectListItem { Text="Checklist", Value="Checklist"}
            };

            //ViewBag.SPAREPARTID = new SelectList(_context.SparepartTbl, "SparepartId", "SparepartCode");
            //ViewBag.TECHNICIANID = new SelectList(_context.TechnicianTbl, "TechnicianId", "TechnicianName");
            //ViewBag.TASKID = new SelectList(_context.TaskTbl, "TaskId", "TaskDetail");

            ViewBag.SPAREPARTID = _context.SparepartTbl.ToList();
            ViewBag.TECHNICIANID = _context.TechnicianTbl.ToList();
            ViewBag.TASKID = _context.TaskTbl.ToList();

            if (id == null)
            {
                return NotFound();
            }

          //  ViewBag.Sparepart = _db.WoExeSparepartTbl.Where(x => x.WoExeId == wo.Id);

            var getcode = _context.WoRequestTbl.Where(x => x.Id == id).First();
            ViewBag.Id = id;
            ViewBag.RequestId = getcode.RequestId;
            ViewBag.RequestDc = getcode.RequestDesc;
            ViewBag.Status = getcode.Status;
            ViewBag.Location = _context.SiteMasterTbl.Where(x => x.SiteId == getcode.SiteId).First().SiteName;
            return View();
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
                var customerData = from a in _context.WoRequestTbl
                                   select new {a.Id, a.RequestId , a.RequestDesc , a.Date , a.Status};
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
                    customerData = customerData.Where(m => m.RequestId.Contains(searchValue) || m.RequestDesc.Contains(searchValue) || m.Status.Contains(searchValue));
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

        // GET: WoRequest/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var woRequestTbl = await _context.WoRequestTbl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (woRequestTbl == null)
            {
                return NotFound();
            }

            return View(woRequestTbl);
        }

        // GET: WoRequest/Create
        public IActionResult Create()
        {
            ViewBag.ASSETID = new SelectList(_context.AssetTbl, "AssetId", "AssetCode");
            ViewBag.SITEID = new SelectList(_context.SiteMasterTbl, "SiteId", "SiteName");

            return View();
        }

        public ActionResult getget2(string aidi)
        {
            int id = Convert.ToInt32(aidi);
            // var getdetail = _context.TaskTbl.Where(x => x.TaskId == id).First().TaskDetail;
            var gettime = _context.AssetTbl.Where(x => x.AssetId == id).First().AssetName;

            List<string> asd = new List<string>();
            asd.Add(gettime);


            return Json(asd);
        }

        // POST: WoRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequestId,RequestDesc,SiteId,LocationId,AssetId,AssetDesc,Date,Status")] WoRequestTbl woRequestTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(woRequestTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(woRequestTbl);
        }

        // GET: WoRequest/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var woRequestTbl = await _context.WoRequestTbl.FindAsync(id);
            if (woRequestTbl == null)
            {
                return NotFound();
            }

            ViewBag.ASSETID = _context.AssetTbl.ToList();
            ViewBag.SITEID = _context.SiteMasterTbl.ToList();

            return View(woRequestTbl);
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
                var getcode = _context.WoRequestTbl.Where(x => x.Id == id).First().Id;

                var customerData = from a in _context.WoRequestSpartpartLineTbl.Where(x => x.WoRequestId == getcode)
                                   join b in _context.SparepartTbl on a.SparepartId equals b.SparepartId
                                   join c in _context.WoRequestTbl on a.WoRequestId equals c.Id
                                   select new { a.Id, c.RequestId, b.SparepartCode, a.Quantity };
                //var getcode = _context.ScheduleMaintenanceTbl.Where(x => x.ScheduleMainId == id).First().ScheduleMainId;


                //var customerData = from a in _context.ScheduleSparepartLinesTbl.Where(x => x.ScheduleMainId == getcode)
                //                   join b in _context.SparepartTbl on a.SparepartId equals b.SparepartId
                //                   join c in _context.ScheduleMaintenanceTbl on a.ScheduleMainId equals c.ScheduleMainId
                //                   select new { a.Id, c.ScheduleMainId, c.MaintenanceId, b.SparepartCode, a.Quantity };


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

        public IActionResult LoadDataLine2(int? id)
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
                var getcode = _context.WoRequestTbl.Where(x => x.Id == id).First().Id;

                var customerData = from a in _context.WoRequestTaskLine.Where(x => x.WoRequestId == getcode)
                                   join b in _context.TechnicianTbl on a.TechnicianId equals b.TechnicianId
                                   join c in _context.WoRequestTbl on a.WoRequestId equals c.Id
                                   select new { a.Id, c.RequestId, a.TaskDetail, b.TechnicianName };

                //var customerData = from a in _context.WoRequestSpartpartLineTbl.Where(x => x.WoRequestId == getcode)
                //                   join b in _context.SparepartTbl on a.SparepartId equals b.SparepartId
                //                   join c in _context.WoRequestTbl on a.WoRequestId equals c.Id
                //                   select new { a.Id, c.RequestId, b.SparepartCode, a.Quantity };


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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSWorParts(TwoModelOneView partLines )
        {
            var t = partLines.sPare.WoRequestId;
            var a = _context.WoRequestTbl.Where(x => x.Id == t).First().Id;

            if (ModelState.IsValid)
            {
                _context.Add(partLines.sPare);
                await _context.SaveChangesAsync();
                //mengarahkan ke method laen dengan nama TaskLines dan dengan value id
                return RedirectToAction("WorSpareparts", new { id = a });
            }
            return View(partLines);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSWorTask(TwoModelOneView partLines)
        {
            var t = partLines.tAsk.WoRequestId;
            var a = _context.WoRequestTbl.Where(x => x.Id == t).First().Id;

            if (ModelState.IsValid)
            {
                


                _context.Add(partLines.tAsk);
                await _context.SaveChangesAsync();
                //mengarahkan ke method laen dengan nama TaskLines dan dengan value id
                return RedirectToAction("WorSpareparts", new { id = a });
            }
            return View(partLines);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSWorTaskEx(TwoModelOneView partLines)
        {
            var t = partLines.tAsk.WoRequestId;
            var a = _context.WoRequestTbl.Where(x => x.Id == t).First().Id;

            if (ModelState.IsValid)
            {

                    string taskss = _context.TaskTbl.Where(x => x.TaskId == partLines.tAsk.TaskId).First().TaskDetail;
                    partLines.tAsk.TaskDetail = taskss;
                


                _context.Add(partLines.tAsk);
                await _context.SaveChangesAsync();
                //mengarahkan ke method laen dengan nama TaskLines dan dengan value id
                return RedirectToAction("WorSpareparts", new { id = a });
            }
            return View(partLines);
        }


        public async Task<IActionResult> WorSpareparts(long id)
        {
            ViewBag.type = new List<SelectListItem>
            {
              new SelectListItem { Text="General", Value="General"},
              new SelectListItem { Text="Yes / No", Value="Yes / No"},
              new SelectListItem { Text="Checklist", Value="Checklist"}
            };

            //ViewBag.SPAREPARTID = new SelectList(_context.SparepartTbl, "SparepartId", "SparepartCode");
            //ViewBag.TECHNICIANID = new SelectList(_context.TechnicianTbl, "TechnicianId", "TechnicianName");
            //ViewBag.TASKID = new SelectList(_context.TaskTbl, "TaskId", "TaskDetail");

            ViewBag.SPAREPARTID = _context.SparepartTbl.ToList();
            ViewBag.TECHNICIANID = _context.TechnicianTbl.ToList();
            ViewBag.TASKID = _context.TaskTbl.ToList();

            if (id == null)
            {
                return NotFound();
            }
            var getcode = _context.WoRequestTbl.Where(x => x.Id == id).First().RequestId;
            ViewBag.Id = id;
            ViewBag.RequestId = getcode;
            return View();

        }
        [HttpPost]
        public ActionResult DeleteScheParts(long id)
        {
            var taskline = _context.WoRequestSpartpartLineTbl.Find(id);
            _context.WoRequestSpartpartLineTbl.Remove(taskline);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult DeleteTaskLines(long id)
        {
            var taskline = _context.WoRequestTaskLine.Find(id);
            _context.WoRequestTaskLine.Remove(taskline);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        // POST: WoRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,RequestId,RequestDesc,SiteId,LocationId,AssetId,AssetDesc,Date")] WoRequestTbl woRequestTbl)
        {
            if (id != woRequestTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(woRequestTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WoRequestTblExists(woRequestTbl.Id))
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
            return View(woRequestTbl);
        }

        // GET: WoRequest/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var task = _context.WoRequestTbl.Find(id);
            _context.WoRequestTbl.Remove(task);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        private bool WoRequestTblExists(long id)
        {
            return _context.WoRequestTbl.Any(e => e.Id == id);
        }


        [HttpPost]
        public ActionResult CreateWoTas(long id)
        {
            WoRequestTbl schdl = _context.WoRequestTbl.Where(x => x.Id == id).First();
            var linestask = _context.WoRequestTaskLine.Where(x => x.WoRequestId == id).First().TaskId;

            WorkOrderTbl wo = new WorkOrderTbl();
            wo.AssetId = schdl.AssetId;
            wo.SiteId = schdl.SiteId;
          //  wo.TechnicianId = schdl.TechnicianId;
            wo.WoDesc = schdl.RequestDesc;
            wo.MaentenanceId = null;
            wo.Date = DateTime.Now;
            wo.CreatedAtWo = DateTime.Now;
            wo.RequestId = schdl.Id;
          //  wo.EstimatedWorking = schdl.EstimatedTime;
           // wo.TaskDetail = schdl.TaskDetail;
            wo.EntityId = _context.TaskTbl.Where(x => x.TaskId == linestask).First().TaskCode;


            _context.WorkOrderTbl.Add(wo);
            _context.SaveChanges();



            WoRequestTbl schdl2 = _context.WoRequestTbl.Where(x => x.Id == id).First();
            schdl2.Status = "In Approval";
           // schdl2.LastMaintenance = DateTime.Now;
            _context.Update(schdl2);
            _context.SaveChanges();

            return Json(new { success = true });
        }

    }
}
