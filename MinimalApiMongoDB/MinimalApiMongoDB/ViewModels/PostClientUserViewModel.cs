using MinimalApiMongoDB.Domains;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MinimalApiMongoDB.ViewModels
{
    public class PostClientUserViewModel
    {
        //[BsonId]
        //[BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        //public ObjectId? ClientId { get; set; } = ObjectId.GenerateNewId();

        //[BsonElement("userId"), BsonRepresentation(BsonType.ObjectId)]
        //public string? UserId { get; set; }

        //[BsonId]
        //[BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        //public ObjectId? UserId { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("cpf")]
        public string? Cpf { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        public Dictionary<string, string>? ClientAdditionalValues { get; set; }
        public Dictionary<string, string>? UserAdditionalValues { get; set; }
    }
}
