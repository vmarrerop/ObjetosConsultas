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
    public class ObjetoConsultasController : ControllerBase
    {
        private readonly ConsultaDBContext _context;

        public ObjetoConsultasController(ConsultaDBContext context)
        {
            _context = context;
        }

        // GET: api/ObjetoConsultas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjetoConsulta>>> GetConsultas()
        {
            return await _context.Consultas.ToListAsync();
        }

        // GET: api/ObjetoConsultas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjetoConsulta>> GetObjetoConsulta(int id)
        {
            var objetoConsulta = await _context.Consultas.FindAsync(id);

            if (objetoConsulta == null)
            {
                return NotFound();
            }

            return objetoConsulta;
        }

        // PUT: api/ObjetoConsultas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjetoConsulta(int id, ObjetoConsulta objetoConsulta)
        {
            if (id != objetoConsulta.idEvent)
            {
                return BadRequest();
            }

            _context.Entry(objetoConsulta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetoConsultaExists(id))
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

        // POST: api/ObjetoConsultas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObjetoConsulta>> PostObjetoConsulta(ObjetoConsulta objetoConsulta)
        {
            _context.Consultas.Add(objetoConsulta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjetoConsulta", new { id = objetoConsulta.idEvent }, objetoConsulta);
        }

        // DELETE: api/ObjetoConsultas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjetoConsulta(int id)
        {
            var objetoConsulta = await _context.Consultas.FindAsync(id);
            if (objetoConsulta == null)
            {
                return NotFound();
            }

            _context.Consultas.Remove(objetoConsulta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjetoConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.idEvent == id);
        }
    }
}

//IMPLEMENTACIÓN DEL CONSUMO CON EL ENDPOINT DE 'OBTENER UNA RECETA'

/*
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModelosConsultas.Controllers
{
    public class ObjetoConsultasController : ControllerBase
    {
         private readonly ConsultaDBContext _context;

        public ObjetoConsultasController(ConsultaDBContext context)
        {
            _context = context;
        }

        private readonly HttpClient _httpClient;

        public ObjetoConsultasController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.huli.io/practice/v2/");
        }

        [HttpGet("checkup/{idEvent}")]
        public async Task<ActionResult> GetCheckup(string idEvent)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"checkup/{idEvent}");
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

