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
    public class TechnicianController : Controller
    {
        private readonly assetaDbContext _context;

        public TechnicianController(assetaDbContext context)
        {
            _context = context;
        }

        // GET: Technician
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.TechnicianTbl.ToListAsync());
        //}
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
                var customerData = (from tempcustomer in _context.TechnicianTbl
                                    select tempcustomer);

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.TechnicianName == searchValue);
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

        // GET: Technician/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicianTbl = await _context.TechnicianTbl
                .FirstOrDefaultAsync(m => m.TechnicianId == id);
            if (technicianTbl == null)
            {
                return NotFound();
            }

            return View(technicianTbl);
        }

        // GET: Technician/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Technician/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechnicianId,TechnicianName,CreatedAtTech,ModifyAtTech")] TechnicianTbl technicianTbl)
        {
            if (ModelState.IsValid)
            {
                technicianTbl.CreatedAtTech = DateTime.Now;
                technicianTbl.ModifyAtTech = DateTime.Now;
                _context.Add(technicianTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technicianTbl);
        }

        // GET: Technician/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicianTbl = await _context.TechnicianTbl.FindAsync(id);
            if (technicianTbl == null)
            {
                return NotFound();
            }
            return View(technicianTbl);
        }

        // POST: Technician/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("TechnicianId,TechnicianName,CreatedAtTech,ModifyAtTech")] TechnicianTbl technicianTbl)
        {
         

            if (ModelState.IsValid)
            {
                try
                {
                    technicianTbl.TechnicianId = id;
                    technicianTbl.ModifyAtTech = DateTime.Now;
                    _context.Update(technicianTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicianTblExists(technicianTbl.TechnicianId))
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
            return View(technicianTbl);
        }

        // GET: Technician/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var technicianTbl = await _context.TechnicianTbl
        //        .FirstOrDefaultAsync(m => m.TechnicianId == id);
        //    if (technicianTbl == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(technicianTbl);
        //}

        //// POST: Technician/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var technicianTbl = await _context.TechnicianTbl.FindAsync(id);
        //    _context.TechnicianTbl.Remove(technicianTbl);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool TechnicianTblExists(long id)
        {
            return _context.TechnicianTbl.Any(e => e.TechnicianId == id);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var sparepart = _context.TechnicianTbl.Find(id);
            _context.TechnicianTbl.Remove(sparepart);
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
