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
    public class HabitoIntestinalModelsController : ControllerBase
    {
        private readonly ConsultaDBContext _context;

        public HabitoIntestinalModelsController(ConsultaDBContext context)
        {
            _context = context;
        }

        // GET: api/HabitoIntestinalModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitoIntestinalModel>>> GetHabito()
        {
            return await _context.Habito.ToListAsync();
        }

        // GET: api/HabitoIntestinalModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HabitoIntestinalModel>> GetHabitoIntestinalModel(int id)
        {
            var habitoIntestinalModel = await _context.Habito.FindAsync(id);

            if (habitoIntestinalModel == null)
            {
                return NotFound();
            }

            return habitoIntestinalModel;
        }

        // PUT: api/HabitoIntestinalModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabitoIntestinalModel(int id, HabitoIntestinalModel habitoIntestinalModel)
        {
            if (id != habitoIntestinalModel.idPatientBowelHabit)
            {
                return BadRequest();
            }

            _context.Entry(habitoIntestinalModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitoIntestinalModelExists(id))
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

        // POST: api/HabitoIntestinalModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HabitoIntestinalModel>> PostHabitoIntestinalModel(HabitoIntestinalModel habitoIntestinalModel)
        {
            _context.Habito.Add(habitoIntestinalModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabitoIntestinalModel", new { id = habitoIntestinalModel.idPatientBowelHabit }, habitoIntestinalModel);
        }

        // DELETE: api/HabitoIntestinalModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitoIntestinalModel(int id)
        {
            var habitoIntestinalModel = await _context.Habito.FindAsync(id);
            if (habitoIntestinalModel == null)
            {
                return NotFound();
            }

            _context.Habito.Remove(habitoIntestinalModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitoIntestinalModelExists(int id)
        {
            return _context.Habito.Any(e => e.idPatientBowelHabit == id);
        }
    }
}

// CONSUMIENDO EL ENDPOINT 'OBTENER HABITO INTESTINAL'
/*
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ModelosConsultas.Controllers
{
    public class HabitoIntestinalModelsController : Controller
    {
        private readonly ConsultaDBContext _context;

        public HabitoIntestinalModelsController(ConsultaDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ObtenerBowelHabit(int idEvent)
        {
            // Crear HttpClient para hacer solicitud HTTP
            using var httpClient = new HttpClient();

            // Hacer solicitud GET al endpoint con el id del evento
            var response = await httpClient.GetFromJsonAsync<BowelHabitModel>($"https://api.huli.io/practice/v2/checkup/{idEvent}/bowel-habit");

            // Guardar resultado en la base de datos utilizando el contexto de Entity Framework
            _context.BowelHabits.Add(response);
            await _context.SaveChangesAsync();

            return Ok(response);
        }
    }
}
*/