using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
    public class AntropometricosModelsController : ControllerBase
    {
        private readonly ConsultaDBContext _context;

        public AntropometricosModelsController(ConsultaDBContext context)
        {
            _context = context;
        }

        // GET: api/AntropometricosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AntropometricosModel>>> GetAntropometricos()
        {
            return await _context.Antropometricos.ToListAsync();
        }

        // GET: api/AntropometricosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AntropometricosModel>> GetAntropometricosModel(int id)
        {
            var antropometricosModel = await _context.Antropometricos.FindAsync(id);

            if (antropometricosModel == null)
            {
                return NotFound();
            }

            return antropometricosModel;
        }

        // PUT: api/AntropometricosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAntropometricosModel(int id, AntropometricosModel antropometricosModel)
        {
            if (id != antropometricosModel.idPatientAnthropometricData)
            {
                return BadRequest();
            }

            _context.Entry(antropometricosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntropometricosModelExists(id))
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

        // POST: api/AntropometricosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AntropometricosModel>> PostAntropometricosModel(AntropometricosModel antropometricosModel)
        {
            _context.Antropometricos.Add(antropometricosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAntropometricosModel", new { id = antropometricosModel.idPatientAnthropometricData }, antropometricosModel);
        }

        // DELETE: api/AntropometricosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAntropometricosModel(int id)
        {
            var antropometricosModel = await _context.Antropometricos.FindAsync(id);
            if (antropometricosModel == null)
            {
                return NotFound();
            }

            _context.Antropometricos.Remove(antropometricosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AntropometricosModelExists(int id)
        {
            return _context.Antropometricos.Any(e => e.idPatientAnthropometricData == id);
        }
    }
}

// CONSUMIENDO ENDPOINT 'OBTENER DATOS ANTROPOMÉTRICOS
/*
public class AntropometricDataModel
{
    public string IdPatientAnthropometricData { get; set; }
    public string IdUserModifiedBy { get; set; }
    public string Status { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public decimal Height { get; set; }
    public string HeightUnit { get; set; }
    public decimal Weight { get; set; }
    public string WeightUnit { get; set; }
}

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AntropometricDataModel> GetAntropometricDataAsync(string idEvent)
    {
        var url = $"https://api.huli.io/practice/v2/checkup/{idEvent}/anthropometric-data";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error calling the API: {response.StatusCode}");
        }

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<AntropometricDataModel>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return result;
    }
}
public class AntropometricosModelsController : Controller
{
    private readonly ConsultaDBContext _context;
    private readonly ApiService _apiService;

    public AntropometricosModelsController(ConsultaDBContext context, ApiService apiService)
    {
        _context = context;
        _apiService = apiService;
    }

    public async Task<IActionResult> GetAntropometricData(string idEvent)
    {
        var data = await _apiService.GetAntropometricDataAsync(idEvent);

        var entity = new AntropometricDataEntity
        {
            IdPatientAnthropometricData = data.IdPatientAnthropometricData,
            IdUserModifiedBy = data.IdUserModifiedBy,
            Status = data.Status,
            CreatedOn = data.CreatedOn,
            ModifiedOn = data.ModifiedOn,
            Height = data.Height,
            HeightUnit = data.HeightUnit,
            Weight = data.Weight,
            WeightUnit = data.WeightUnit
        };

        _context.AntropometricDataEntities.Add(entity);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
*/
