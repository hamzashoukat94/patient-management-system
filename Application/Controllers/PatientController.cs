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
            IEnumerable<PatientDTO> patients = _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpGet("{patientId}")]
        public IActionResult GetPatientById(int patientId)
        {
            PatientDTO patientDTO = _patientService.GetPatientById(patientId);
            if (patientDTO == null)
            {
                return NotFound();
            }
            return Ok(patientDTO);
        }

        [HttpPost]
        public IActionResult CreatePatientRecord(PatientCreationDTO patientCreationDTO)
        {
            var patientCreatedDTO = _patientService.CreatePatientRecord(patientCreationDTO);
            return CreatedAtAction(nameof(GetPatientById), new { patientId = patientCreatedDTO.Id }, patientCreatedDTO);
        }


        [HttpPut]
        public IActionResult UpdatePatientRecord(PatientDTO patientDTO)
        {
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
            bool patientDeleted = _patientService.Delete(patientId);
            if (!patientDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
