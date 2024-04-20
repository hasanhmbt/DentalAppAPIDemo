using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;



namespace DentalAppAPIDemo.Entites
{
    [BsonIgnoreExtraElements]
    public class PatientsEntity
    {
        public enum GenderType
        {
            Male,
            Female,
            NonBinary,
            Other
        }
         

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("gender")]
        public GenderType Gender { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("patientproblem")]
        public string? PatientProblem { get; set; }

    }
}
