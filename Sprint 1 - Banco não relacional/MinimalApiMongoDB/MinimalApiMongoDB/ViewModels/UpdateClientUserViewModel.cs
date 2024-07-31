using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MinimalApiMongoDB.ViewModels
{
    public class UpdateClientUserViewModel
    {
        // User properties
        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        // Client properties
        [BsonElement("cpf")]
        public string? Cpf { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        public Dictionary<string, string>? UserAdditionalValues { get; set; } = null;
        public Dictionary<string, string>? ClientAdditionalValues { get; set; } = null;
    }
}
