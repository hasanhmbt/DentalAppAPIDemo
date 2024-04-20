using DentalAppAPIDemo.Entites;

namespace DentalAppAPIDemo.Repositories.Abstract 
{
    public interface IPatientRepository
    {
        List<PatientsEntity> Get();
        PatientsEntity Get(string id);
        PatientsEntity Create(PatientsEntity entity);
        void Update(string id, PatientsEntity entity);
        void Delete(string id);
    }
}
