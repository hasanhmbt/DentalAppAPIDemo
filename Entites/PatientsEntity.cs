using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace DentalAppAPIDemo.Entites
{
    [BsonIgnoreExtraElements]
    public class PatientsEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("gender")]
        public bool Gender { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("patientproblem")]
        public string? PatientProblem { get; set; }

    }
}
