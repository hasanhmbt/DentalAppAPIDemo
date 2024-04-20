using DentalAppAPIDemo.Entites;
using DentalAppAPIDemo.Repositories.Abstract;
using MongoDB.Driver;

namespace DentalAppAPIDemo.Repositories.Concrete
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IMongoCollection<PatientsEntity> _patients;
        private readonly IDataBaseSettings _settings;
        public PatientRepository(IDataBaseSettings settings, IMongoClient mongoClient)
        {
            _settings = settings;  
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _patients = database.GetCollection<PatientsEntity>(settings.PatientsDatajs);
        }
        public PatientsEntity Create(PatientsEntity patient)
        {
           _patients.InsertOne(patient);
            return patient;
        }

       

        public List<PatientsEntity> Get()
        {
            return _patients.Find(PatientsEntity => true).ToList();
        }

        public PatientsEntity Get(string id)
        {
            return _patients.Find(patients => patients.ID == id).FirstOrDefault();

        }

        public void Update(string id, PatientsEntity patient)
        {
            _patients.ReplaceOne(patients => patients.ID == id, patient);

        }
        public void Delete(string id)
        {
            _patients.DeleteOne(patients => patients.ID == id);

        }
    }
}
