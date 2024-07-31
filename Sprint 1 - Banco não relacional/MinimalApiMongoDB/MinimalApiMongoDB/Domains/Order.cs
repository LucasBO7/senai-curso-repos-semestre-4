using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MinimalApiMongoDB.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId? Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("date")]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [BsonElement("statusNumber")]
        public int StatusNumber { get; set; }
        public OrderStatus? Status { get; set; }

        // Referências
        [BsonElement("idProduct")]
        public List<string>? ProductsIds { get; set; } = [];
        public List<Product>? Products { get; set; } = [];


        [BsonElement("idClient")]
        public string? ClientId { get; set; }
        public Client? Client { get; set; }

        //public List<User>? Users { get; set; } = [];
    }

    public enum OrderStatus
    {
        AguardandoPagamento,
        Pago,
        EntregaEmAndamento,
        Entregue
    }
}