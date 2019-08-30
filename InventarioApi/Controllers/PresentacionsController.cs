using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioApi.Models;

namespace InventarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionsController : ControllerBase
    {
        private readonly InventarioContext _context;

        public PresentacionsController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Presentacions
        [HttpGet]
        public IEnumerable<Presentacion> GetPresentacion()
        {
            return _context.Presentacion;
        }

        // GET: api/Presentacions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPresentacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var presentacion = await _context.Presentacion.FindAsync(id);

            if (presentacion == null)
            {
                return NotFound();
            }

            return Ok(presentacion);
        }

        // PUT: api/Presentacions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresentacion([FromRoute] int id, [FromBody] Presentacion presentacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != presentacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(presentacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentacionExists(id))
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

        // POST: api/Presentacions
        [HttpPost]
        public async Task<IActionResult> PostPresentacion([FromBody] Presentacion presentacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Presentacion.Add(presentacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresentacion", new { id = presentacion.Id }, presentacion);
        }

        // DELETE: api/Presentacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresentacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var presentacion = await _context.Presentacion.FindAsync(id);
            if (presentacion == null)
            {
                return NotFound();
            }

            _context.Presentacion.Remove(presentacion);
            await _context.SaveChangesAsync();

            return Ok(presentacion);
        }

        private bool PresentacionExists(int id)
        {
            return _context.Presentacion.Any(e => e.Id == id);
        }
    }
}