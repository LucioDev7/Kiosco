﻿using KioscoInformaticoBackend.DataContext;
using KioscoInformaticoServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KioscoInformaticoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesComprasController : ControllerBase
    {
        private readonly KioscoContext _context;

        public DetallesComprasController(KioscoContext context)
        {
            _context = context;
        }

        // GET: api/DetallesCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesCompra>>> GetDetallesCompras()
        {
            return await _context.DetallesCompras.ToListAsync();
        }

        // GET: api/DetallesCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesCompra>> GetDetallesCompra(int id)
        {
            var detallesCompra = await _context.DetallesCompras.FindAsync(id);

            if (detallesCompra == null)
            {
                return NotFound();
            }

            return detallesCompra;
        }

        // PUT: api/DetallesCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesCompra(int id, DetallesCompra detallesCompra)
        {
            if (id != detallesCompra.Id)
            {
                return BadRequest();
            }

            _context.Entry(detallesCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesCompraExists(id))
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

        // POST: api/DetallesCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesCompra>> PostDetallesCompra(DetallesCompra detallesCompra)
        {
            _context.DetallesCompras.Add(detallesCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesCompra", new { id = detallesCompra.Id }, detallesCompra);
        }

        // DELETE: api/DetallesCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesCompra(int id)
        {
            var detallesCompra = await _context.DetallesCompras.FindAsync(id);
            if (detallesCompra == null)
            {
                return NotFound();
            }

            _context.DetallesCompras.Remove(detallesCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesCompraExists(int id)
        {
            return _context.DetallesCompras.Any(e => e.Id == id);
        }
    }
}
