using MinimalApiMongoDB.Domains;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace MinimalApiMongoDB.ViewModels
{
    public class PostOrderViewModel
    {
        [BsonElement("statusNumber")]
        public int StatusNumber { get; set; }
        public OrderStatus? Status { get; set; }

        // Referências
        [BsonElement("idProducts")]
        public List<string>? ProductsIds { get; set; }
    }
}
