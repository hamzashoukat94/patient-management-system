using Application.Domain;
using Application.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            IEnumerable<PatientDto> patients = _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpGet("{patientId}")]
        public IActionResult GetPatientById(int patientId)
        {
            if (patientId < 0)
                return BadRequest();

            PatientDto patientDTO = _patientService.GetPatientById(patientId);
            if (patientDTO == null)
            {
                return NotFound();
            }
            return Ok(patientDTO);
        }

        [HttpPost]
        public IActionResult CreatePatientRecord(PatientCreationDTO patientCreationDTO)
        {
            if (patientCreationDTO == null || !ModelState.IsValid)
                return BadRequest();

            var patientCreatedDTO = _patientService.CreatePatientRecord(patientCreationDTO);
            return CreatedAtAction(nameof(GetPatientById), new { patientId = patientCreatedDTO.Id }, patientCreatedDTO);
        }


        [HttpPut]
        public IActionResult UpdatePatientRecord(PatientDto patientDTO)
        {
            if (patientDTO == null || !ModelState.IsValid)
                return BadRequest();

            var patientUpdatedDTO = _patientService.UpdatePatientRecord(patientDTO);
            if (!patientUpdatedDTO)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletePatientRecord(int patientId)
        {
            if (patientId < 0)
                return BadRequest();

            bool patientDeleted = _patientService.Delete(patientId);
            if (!patientDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
