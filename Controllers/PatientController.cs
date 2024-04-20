using DentalAppAPIDemo.Entites;
using DentalAppAPIDemo.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentalAppAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
              _patientRepository = patientRepository;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public ActionResult<List<PatientsEntity>> GetPatient()
        {
            return _patientRepository.Get();
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public ActionResult<PatientsEntity> GetPatientById(string id)
        {
            var patient = _patientRepository.Get(id);
            if (id == null)
                return NotFound($"Patient With Id={id} Not Found");

            return patient;

        }

        // POST api/<PatientController>
        [HttpPost]
        public ActionResult<PatientsEntity> AddPatient([FromBody] PatientsEntity patient)
        {
            _patientRepository.Create(patient);

            return CreatedAtAction(nameof(GetPatient), new { id = patient.ID }, patient);

        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public ActionResult UpdatePatient(string id, [FromBody] PatientsEntity entity)
        {
            var existingPatient = _patientRepository.Get(id);
            if (existingPatient == null)
                return NotFound($"Patient With Id={id} Not Found");

            _patientRepository.Update(id, entity);

            return NoContent();
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public ActionResult DeletePatient(string id)
        {
            var existingPatient = _patientRepository.Get(id);
            if (existingPatient == null)
                return NotFound($"Patient With Id={id} Not Found");

            _patientRepository.Delete(id);

            return Ok($"Patient With Id={id} Deleted");
        }
    }
}
