using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelosConsultas.DataAccess;
using ModelosConsultas.Models.DataModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModelosConsultas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivoConsultaModelsController : ControllerBase
    {
        private readonly ConsultaDBContext _context;

        public MotivoConsultaModelsController(ConsultaDBContext context)
        {
            _context = context;
        }

        // GET: api/MotivoConsultaModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotivoConsultaModel>>> GetMotivo()
        {
            return await _context.Motivo.ToListAsync();
        }

        // GET: api/MotivoConsultaModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotivoConsultaModel>> GetMotivoConsultaModel(int id)
        {
            var motivoConsultaModel = await _context.Motivo.FindAsync(id);

            if (motivoConsultaModel == null)
            {
                return NotFound();
            }

            return motivoConsultaModel;
        }

        // PUT: api/MotivoConsultaModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivoConsultaModel(int id, MotivoConsultaModel motivoConsultaModel)
        {
            if (id != motivoConsultaModel.idPatientReasonOfVisit)
            {
                return BadRequest();
            }

            _context.Entry(motivoConsultaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivoConsultaModelExists(id))
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

        // POST: api/MotivoConsultaModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MotivoConsultaModel>> PostMotivoConsultaModel(MotivoConsultaModel motivoConsultaModel)
        {
            _context.Motivo.Add(motivoConsultaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotivoConsultaModel", new { id = motivoConsultaModel.idPatientReasonOfVisit }, motivoConsultaModel);
        }

        // DELETE: api/MotivoConsultaModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotivoConsultaModel(int id)
        {
            var motivoConsultaModel = await _context.Motivo.FindAsync(id);
            if (motivoConsultaModel == null)
            {
                return NotFound();
            }

            _context.Motivo.Remove(motivoConsultaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotivoConsultaModelExists(int id)
        {
            return _context.Motivo.Any(e => e.idPatientReasonOfVisit == id);
        }
    }
}

// CONSUMIENDO ENDOPINT 'OBTENER MOTIVO DE CONSULTA'
/*
using Newtonsoft.Json;

public class ReasonOfVisit
{
    [JsonProperty("idPatientReasonOfVisit")]
    public string IdPatientReasonOfVisit { get; set; }

    [JsonProperty("idUserModifiedBy")]
    public string IdUserModifiedBy { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("reason")]
    public string Reason { get; set; }

    [JsonProperty("createdOn")]
    public DateTime CreatedOn { get; set; }

    [JsonProperty("modifiedOn")]
    public DateTime ModifiedOn { get; set; }
}

using Consultas.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ModelosConsultas.Controllers
{
    public class ConsultaModelsController : ControllerBase
    {
        private readonly ConsultaDBContext _context;

        public ConsultaModelsController(ConsultaDBContext context)
        {
            _context = context;
        }

        [HttpGet("checkup/{idEvent}/reason-of-visit")]
        public async Task<ActionResult<ReasonOfVisit>> GetReasonOfVisitByIdEvent(string idEvent)
        {
            var uri = $"https://api.huli.io/practice/v2/checkup/{idEvent}/reason-of-visit";

            using var client = new HttpClient();
            using var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var reasonOfVisit = JsonConvert.DeserializeObject<ReasonOfVisit>(content);
                return reasonOfVisit;
            }

            return NotFound();
        }
        
        // Asumiendo que la clase ReasonOfVisit tiene la propiedad "IdPatientReasonOfVisit"
        [HttpGet("patient-reason-of-visit/{idPatientReasonOfVisit}")]
        public async Task<ActionResult<ReasonOfVisit>> GetReasonOfVisitByIdPatientReasonOfVisit(string idPatientReasonOfVisit)
        {
            var uri = $"https://api.huli.io/practice/v2/patient-reason-of-visit/{idPatientReasonOfVisit}";

            using var client = new HttpClient();
            using var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var reasonOfVisit = JsonConvert.DeserializeObject<ReasonOfVisit>(content);
                return reasonOfVisit;
            }

            return NotFound();
        }
    }
}

*/

