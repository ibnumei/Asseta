﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetaWeb.Controllers
{
    public class AssetGroupController : Controller
    {
        private readonly assetaDbContext _db;

        public AssetGroupController(assetaDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //return View(_db.AssetGroupTbl.ToList());
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
                var customerData = (from tempcustomer in _db.AssetGroupTbl
                                    select tempcustomer);

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.AssetGroupCode.Contains(searchValue) || m.AssetGroupName.Contains(searchValue));
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

        //=========================================================================
        //View Create Data
        public IActionResult Create()
        {
            return View();
        }

        //Action Create Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssetGroupTbl assetGroup)
        {
            if(ModelState.IsValid)
            {
                String idrunning = "";
                idrunning = generateRunningNumber(idrunning);

                assetGroup.AssetGroupCode = idrunning;
                assetGroup.CreatedAtAssetGroup = DateTime.Now;
                assetGroup.ModifyAtAssetGroup = DateTime.Now;
                _db.Add(assetGroup);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetGroup);
        }
        //=========================================================================================================
        //GENERATE RUNNING NUMBER
        private String generateRunningNumber(string id)
        {
            AssetGroupTbl data = _db.AssetGroupTbl.Where(x => x.AssetGroupCode == "AG" + DateTime.Now.ToString("yyMM") + "0001").FirstOrDefault();

            string tempSubId = "";
            int tempId;

            if (data == null)
            {
                id = "AG" + DateTime.Now.ToString("yyMM") + "0001";

            }
            else
            {

                var xx = (from a in _db.AssetGroupTbl
                          where a.AssetGroupCode.Substring(0, 6) == "AG" + DateTime.Now.ToString("yyMM")
                          select a).Max(a => a.AssetGroupCode);

                tempSubId = xx.Substring(6, 4);
                tempId = Convert.ToInt32(tempSubId);
                tempId = tempId + 1;

                if (tempId.ToString().Length == 1)
                {
                    id = "AG" + DateTime.Now.ToString("yyMM") + "000" + tempId;
                }
                else if (tempId.ToString().Length == 2)
                {
                    id = "AG" + DateTime.Now.ToString("yyMM") + "00" + tempId;
                }
                else if (tempId.ToString().Length == 3)
                {
                    id = "AG" + DateTime.Now.ToString("yyMM") + "0" + tempId;
                }
                else if (tempId.ToString().Length == 4)
                {
                    id = "AG" + DateTime.Now.ToString("yyMM") + tempId;
                }


            }

            return id;
        }
        //=========================================================================================================
        //Edit View
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assetgroup = await _db.AssetGroupTbl.SingleOrDefaultAsync(m => m.AssetGroupId== id);
            if (assetgroup == null)
            {
                return NotFound();
            }
            return View(assetgroup);
        }


        //Method Edit Proses
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssetGroupTbl assetGroup)
        {
            if (id != assetGroup.AssetGroupId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                assetGroup.ModifyAtAssetGroup = DateTime.Now;
                _db.Update(assetGroup);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetGroup);
        }
        //=========================================================================================================
        //Delete
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var assetgroup = await _db.AssetGroupTbl.SingleOrDefaultAsync(m => m.AssetGroupId == id);
        //    if (assetgroup == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(assetgroup);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var assetgroup = await _db.AssetGroupTbl.SingleOrDefaultAsync(m => m.AssetGroupId == id);
        //    _db.AssetGroupTbl.Remove(assetgroup);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        //=========================================================================================================

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var sparepart = _db.AssetGroupTbl.Find(id);
            _db.AssetGroupTbl.Remove(sparepart);
            _db.SaveChanges();

            return Json(new { success = true });
        }
    }
}