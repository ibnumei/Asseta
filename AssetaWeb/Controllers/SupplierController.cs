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
    public class SupplierController : Controller
    {
        private readonly assetaDbContext _context;

        public SupplierController(assetaDbContext context)
        {
            _context = context;
        }

        // GET: Supplier
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
                var customerData = (from tempcustomer in _context.SupplierTbl
                                    select tempcustomer);

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.SupplierCode.Contains(searchValue) || m.Description.Contains(searchValue));
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

        // GET: Supplier/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierTbl = await _context.SupplierTbl
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplierTbl == null)
            {
                return NotFound();
            }

            return View(supplierTbl);
        }

        // GET: Supplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,SupplierCode,Description,Address,Contact,ProductData,CreatedAtSupplier,ModifyAtSupplier")] SupplierTbl supplierTbl)
        {
            if (ModelState.IsValid)
            {
                String idrunning = "";
                idrunning = generateRunningNumber(idrunning);

                supplierTbl.SupplierCode = idrunning;

                supplierTbl.CreatedAtSupplier = DateTime.Now;
                supplierTbl.ModifyAtSupplier = DateTime.Now;
                
                _context.Add(supplierTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierTbl);
        }
        //=========================================================================================================
        //GENERATE RUNNING NUMBER
        private String generateRunningNumber(string id)
        {
            SupplierTbl data = _context.SupplierTbl.Where(x => x.SupplierCode == "SP" + DateTime.Now.ToString("yyMM") + "0001").FirstOrDefault();

            string tempSubId = "";
            int tempId;

            if (data == null)
            {
                id = "SP" + DateTime.Now.ToString("yyMM") + "0001";

            }
            else
            {

                var xx = (from a in _context.SupplierTbl
                          where a.SupplierCode.Substring(0, 6) == "SP" + DateTime.Now.ToString("yyMM")
                          select a).Max(a => a.SupplierCode);

                tempSubId = xx.Substring(6, 4);
                tempId = Convert.ToInt32(tempSubId);
                tempId = tempId + 1;

                if (tempId.ToString().Length == 1)
                {
                    id = "SP" + DateTime.Now.ToString("yyMM") + "000" + tempId;
                }
                else if (tempId.ToString().Length == 2)
                {
                    id = "SP" + DateTime.Now.ToString("yyMM") + "00" + tempId;
                }
                else if (tempId.ToString().Length == 3)
                {
                    id = "SP" + DateTime.Now.ToString("yyMM") + "0" + tempId;
                }
                else if (tempId.ToString().Length == 4)
                {
                    id = "SP" + DateTime.Now.ToString("yyMM") + tempId;
                }


            }

            return id;
        }
        // GET: Supplier/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierTbl = await _context.SupplierTbl.FindAsync(id);
            if (supplierTbl == null)
            {
                return NotFound();
            }
            return View(supplierTbl);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, SupplierTbl supplierTbl)
        {

           
            // supplierTbl = _context.SupplierTbl.Find(id);

            if (ModelState.IsValid)
            {
                try
                {
                    //var edits = _context.SupplierTbl.Where(x => x.SupplierId == id).First();
                    //supplierTbl.
                    supplierTbl.SupplierId = id;
                    supplierTbl.CreatedAtSupplier = supplierTbl.CreatedAtSupplier;
                    supplierTbl.ModifyAtSupplier = DateTime.Now;
                  //  _context.Entry(supplierTbl).State = EntityState.Detached;
                    _context.SupplierTbl.Update(supplierTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierTblExists(supplierTbl.SupplierId))
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
            return View(supplierTbl);
        }

        // GET: Supplier/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var supplierTbl = await _context.SupplierTbl
        //        .FirstOrDefaultAsync(m => m.SupplierId == id);
        //    if (supplierTbl == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(supplierTbl);
        //}

        //// POST: Supplier/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var supplierTbl = await _context.SupplierTbl.FindAsync(id);
        //    _context.SupplierTbl.Remove(supplierTbl);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SupplierTblExists(long id)
        {
            return _context.SupplierTbl.Any(e => e.SupplierId == id);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var sparepart = _context.SupplierTbl.Find(id);
            _context.SupplierTbl.Remove(sparepart);
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}
