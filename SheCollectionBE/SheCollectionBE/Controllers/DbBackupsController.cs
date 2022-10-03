using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.DB_Models;

namespace SheCollectionBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbBackupsController : ControllerBase
    {
        private readonly SheCollectionContext _context;

        public DbBackupsController(SheCollectionContext context)
        {
            _context = context;
        }

        // GET: api/DbBackups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbBackup>>> GetDbBackups()
        {
          if (_context.DbBackups == null)
          {
              return NotFound();
          }
            return await _context.DbBackups.ToListAsync();
        }

        // GET: api/DbBackups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbBackup>> GetDbBackup(int id)
        {
          if (_context.DbBackups == null)
          {
              return NotFound();
          }
            var dbBackup = await _context.DbBackups.FindAsync(id);

            if (dbBackup == null)
            {
                return NotFound();
            }

            return dbBackup;
        }

        // PUT: api/DbBackups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbBackup(int id, DbBackup dbBackup)
        {
            if (id != dbBackup.Id)
            {
                return BadRequest();
            }

            _context.Entry(dbBackup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbBackupExists(id))
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

        // POST: api/DbBackups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DbBackup>> PostDbBackup(DbBackup dbBackup)
        {
          if (_context.DbBackups == null)
          {
              return Problem("Entity set 'SheCollectionContext.DbBackups'  is null.");
          }
            _context.DbBackups.Add(dbBackup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbBackup", new { id = dbBackup.Id }, dbBackup);
        }

        // DELETE: api/DbBackups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDbBackup(int id)
        {
            if (_context.DbBackups == null)
            {
                return NotFound();
            }
            var dbBackup = await _context.DbBackups.FindAsync(id);
            if (dbBackup == null)
            {
                return NotFound();
            }

            _context.DbBackups.Remove(dbBackup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DbBackupExists(int id)
        {
            return (_context.DbBackups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
