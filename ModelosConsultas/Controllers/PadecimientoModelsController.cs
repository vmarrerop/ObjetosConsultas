using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelosConsultas.DataAccess;
using ModelosConsultas.Models.DataModels;

namespace ModelosConsultas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadecimientoModelsController : ControllerBase
    {
        private readonly ConsultaDBContext _context;

        public PadecimientoModelsController(ConsultaDBContext context)
        {
            _context = context;
        }

        // GET: api/PadecimientoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PadecimientoModel>>> GetPadecimiento()
        {
            return await _context.Padecimiento.ToListAsync();
        }

        // GET: api/PadecimientoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PadecimientoModel>> GetPadecimientoModel(int id)
        {
            var padecimientoModel = await _context.Padecimiento.FindAsync(id);

            if (padecimientoModel == null)
            {
                return NotFound();
            }

            return padecimientoModel;
        }

        // PUT: api/PadecimientoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPadecimientoModel(int id, PadecimientoModel padecimientoModel)
        {
            if (id != padecimientoModel.idPatientSuffering)
            {
                return BadRequest();
            }

            _context.Entry(padecimientoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PadecimientoModelExists(id))
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

        // POST: api/PadecimientoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PadecimientoModel>> PostPadecimientoModel(PadecimientoModel padecimientoModel)
        {
            _context.Padecimiento.Add(padecimientoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPadecimientoModel", new { id = padecimientoModel.idPatientSuffering }, padecimientoModel);
        }

        // DELETE: api/PadecimientoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePadecimientoModel(int id)
        {
            var padecimientoModel = await _context.Padecimiento.FindAsync(id);
            if (padecimientoModel == null)
            {
                return NotFound();
            }

            _context.Padecimiento.Remove(padecimientoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PadecimientoModelExists(int id)
        {
            return _context.Padecimiento.Any(e => e.idPatientSuffering == id);
        }
    }
}


// CONSUMIENDO ENDPOINT DE 'OBTENER PADECIMIENTO" 
/*

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModelosConsultas.Controllers
{
    public class PadecimientoModelsController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public PadecimientoModelsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.huli.io/practice/v2/");
        }

        [HttpGet("checkup/{idEvent}/suffering")]
        public async Task<ActionResult> GetSuffering(string idEvent)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"checkup/{idEvent}/suffering");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return Ok(responseBody);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}
*/