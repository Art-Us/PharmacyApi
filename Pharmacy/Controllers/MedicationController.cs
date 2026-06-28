using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Database;

namespace Pharmacy.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicationController : ControllerBase
{
    private readonly PharmacyDbContext _context;

    public MedicationController(PharmacyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var medications = await _context.Medication.ToListAsync();
        return Ok(medications);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var medication = await _context.Medication.FirstOrDefaultAsync(m => m.Id == id);

        if (medication == null)
        {
            return NotFound(new { message = $"Medication with ID {id} not found." });
        }

        return Ok(medication);
    }
}



// [
//   {
//     "id": 1,
//     "name": "Apap",
//     "activeSubstance": "Paracetamol",
//     "doseMg": 500,
//     "prescriptionRequired": false,
//     "manufacturer": "US Pharmacia"
//   },
//   {
//     "id": 2,
//     "name": "Ibuprom",
//     "activeSubstance": "Ibuprofen",
//     "doseMg": 200,
//     "prescriptionRequired": false,
//     "manufacturer": "US Pharmacia"
//   },
//   {
//     "id": 3,
//     "name": "Ketonal Forte",
//     "activeSubstance": "Ketoprofen",
//     "doseMg": 100,
//     "prescriptionRequired": true,
//     "manufacturer": "Sandoz"
//   },
//   {
//     "id": 4,
//     "name": "Amotaks",
//     "activeSubstance": "Amoxicillin",
//     "doseMg": 500,
//     "prescriptionRequired": true,
//     "manufacturer": "Polfa Tarchomin"
//   },
//   {
//     "id": 5,
//     "name": "No-Spa",
//     "activeSubstance": "Drotaverine",
//     "doseMg": 40,
//     "prescriptionRequired": false,
//     "manufacturer": "Sanofi"
//   }
// ]








// dla id 1

// {
//   "id": 1,
//   "name": "Apap",
//   "activeSubstance": "Paracetamol",
//   "doseMg": 500,
//   "prescriptionRequired": false,
//   "manufacturer": "US Pharmacia"
// }
