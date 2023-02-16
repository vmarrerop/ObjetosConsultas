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
    public class NotaConsultaModelsController : ControllerBase
    {
        private readonly ConsultaDBContext _context;

        public NotaConsultaModelsController(ConsultaDBContext context)
        {
            _context = context;
        }

        // GET: api/NotaConsultaModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaConsultaModel>>> GetNota()
        {
            return await _context.Nota.ToListAsync();
        }

        // GET: api/NotaConsultaModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotaConsultaModel>> GetNotaConsultaModel(int id)
        {
            var notaConsultaModel = await _context.Nota.FindAsync(id);

            if (notaConsultaModel == null)
            {
                return NotFound();
            }

            return notaConsultaModel;
        }

        // PUT: api/NotaConsultaModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotaConsultaModel(int id, NotaConsultaModel notaConsultaModel)
        {
            if (id != notaConsultaModel.idPatientCheckupNote)
            {
                return BadRequest();
            }

            _context.Entry(notaConsultaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaConsultaModelExists(id))
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

        // POST: api/NotaConsultaModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotaConsultaModel>> PostNotaConsultaModel(NotaConsultaModel notaConsultaModel)
        {
            _context.Nota.Add(notaConsultaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotaConsultaModel", new { id = notaConsultaModel.idPatientCheckupNote }, notaConsultaModel);
        }

        // DELETE: api/NotaConsultaModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotaConsultaModel(int id)
        {
            var notaConsultaModel = await _context.Nota.FindAsync(id);
            if (notaConsultaModel == null)
            {
                return NotFound();
            }

            _context.Nota.Remove(notaConsultaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotaConsultaModelExists(int id)
        {
            return _context.Nota.Any(e => e.idPatientCheckupNote == id);
        }
    }
}

// CONSUMIENDO EL ENDPOINT 'OBTENER  NOTA DE CONSULTA'
/*
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ModelosConsultas.Controllers
{
    public class NotaConsultaModelsController
    {
        private readonly HttpClient _httpClient;

        public NotaConsultaModelsController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetNoteByIdEvent(string idEvent)
        {
            try
            {
                var url = $"https://api.huli.io/practice/v2/checkup/{idEvent}/note";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    throw new Exception($"Error al obtener la nota para el evento {idEvent}. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción y devuelve una respuesta adecuada para el usuario
                return $"Error al obtener la nota para el evento {idEvent}: {ex.Message}";
            }
        }
    }
}
*/
