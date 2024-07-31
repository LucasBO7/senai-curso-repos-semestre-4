using MinimalApiMongoDB.Domains;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MinimalApiMongoDB.ViewModels
{
    public class GetOrderViewModel
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [BsonElement("statusNumber")]
        public int StatusNumber { get; set; }
        public string? Status { get; set; }


        // Referências
        // Product
        //[BsonElement("idProduct")]
        //public List<string>? ProductsIds { get; set; } = [];
        public List<Product>? Products { get; set; } = [];


        // Client
        [BsonElement("idClient")]
        public string? ClientId { get; set; }

        [BsonElement("userId"), BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonElement("cpf")]
        public string? Cpf { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        public Dictionary<string, string>? ClientAdditionalValues { get; set; }
    }
}
