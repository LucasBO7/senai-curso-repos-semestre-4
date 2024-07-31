using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MinimalApiMongoDB.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId? Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("userId"), BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonIgnore]
        public User? User { get; set; }

        [BsonElement("cpf")]
        public string? Cpf { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        public Dictionary<string, string>? AdditionalValues { get; set; }

        public Client()
        {
            AdditionalValues = [];
        }
    }
}