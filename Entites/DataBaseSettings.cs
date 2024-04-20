namespace DentalAppAPIDemo.Entites
{
    public class DataBaseSettings : IDataBaseSettings
    {
        public string PatientsDatajs { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
