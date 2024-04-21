using DentalAppAPIDemo.Entites;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;



namespace DentalAppAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<PatientsEntity> _patients;

        public PatientController(IConfiguration configuration)
        {

            _configuration = configuration;
            var settings = MongoClientSettings.FromConnectionString(_configuration.GetConnectionString("ConnectionString"));
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _mongoClient = new MongoClient(settings);
            IMongoDatabase database = _mongoClient.GetDatabase("test");
            _patients = database.GetCollection<PatientsEntity>("patient");
        }

        // GET: api/<PatientController>
        [HttpGet]
        public ActionResult<List<PatientsEntity>> GetPatient()
        {
            return  _patients.Find(PatientsEntity => true).ToList();

        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public ActionResult<PatientsEntity> GetPatientById(string id)
        {
            var patient = _patients.Find(patients => patients.Id == id).FirstOrDefault();
            if (id == null)
                return NotFound($"Patient With Id={id} Not Found");

            return patient;

        }

        // POST api/<PatientController>
        [HttpPost]
        public ActionResult<PatientsEntity> AddPatient( PatientsEntity patient)
        {
            patient.Id = "";
            _patients.InsertOne(patient);

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);

        }
      
        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public  ActionResult UpdatePatient(string id, PatientsEntity patient)
        {
            try
            {
                var existingId = _patients.Find(p => p.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                return NotFound($"Patient With Id={id} Not Found");

            }
           
            patient.Id = id;
            _patients.ReplaceOne(patients => patients.Id == id, patient);

            return NoContent();
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public ActionResult DeletePatient(string id)
        {

            var existingId = _patients.Find(p => p.Id == id).FirstOrDefault();
            if (existingId == null)
                return NotFound($"Patient With Id={id} Not Found");
            _patients.DeleteOne(p => p.Id == id);

            return Ok($"Patient With Id={id} Deleted");
        }
    }
}
