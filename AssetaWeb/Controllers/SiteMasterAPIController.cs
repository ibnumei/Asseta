using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetaWeb.Models;

namespace AssetaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteMasterAPIController : ControllerBase
    {
        private readonly assetaDbContext _context;

        public SiteMasterAPIController(assetaDbContext context)
        {
            _context = context;
        }

        // GET: api/SiteMasterAPI
        [HttpGet]
        public IEnumerable<SiteMasterTbl> GetSiteMasterTbl()
        {
            return _context.SiteMasterTbl;  
        }

        // GET: api/SiteMasterAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiteMasterTbl([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var siteMasterTbl = await _context.SiteMasterTbl.FindAsync(id);

            if (siteMasterTbl == null)
            {
                return NotFound();
            }

            return Ok(siteMasterTbl);
        }

        // PUT: api/SiteMasterAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiteMasterTbl([FromRoute] long id, [FromBody] SiteMasterTbl siteMasterTbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siteMasterTbl.SiteId)
            {
                return BadRequest();
            }

            _context.Entry(siteMasterTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteMasterTblExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SiteMasterAPI
        [HttpPost]
        public async Task<IActionResult> PostSiteMasterTbl([FromBody] SiteMasterTbl siteMasterTbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SiteMasterTbl.Add(siteMasterTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSiteMasterTbl", new { id = siteMasterTbl.SiteId }, siteMasterTbl);
        }

        // DELETE: api/SiteMasterAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiteMasterTbl([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var siteMasterTbl = await _context.SiteMasterTbl.FindAsync(id);
            if (siteMasterTbl == null)
            {
                return NotFound();
            }

            _context.SiteMasterTbl.Remove(siteMasterTbl);
            await _context.SaveChangesAsync();

            return Ok(siteMasterTbl);
        }

        private bool SiteMasterTblExists(long id)
        {
            return _context.SiteMasterTbl.Any(e => e.SiteId == id);
        }
    }
}