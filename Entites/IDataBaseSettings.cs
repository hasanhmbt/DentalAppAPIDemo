namespace DentalAppAPIDemo.Entites
{
    public interface IDataBaseSettings
    {
        public string PatientsDatajs { get; set; }  
        public string ConnectionString { get; set; }  
        public string DatabaseName { get; set; }  
    }
}
