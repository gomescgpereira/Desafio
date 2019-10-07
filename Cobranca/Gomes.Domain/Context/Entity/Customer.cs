using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gomes.Domain.Context.Entity
{
    public class Customer
    {
        [BsonId]
        public ObjectId _id {get; set;}
        [BsonElement("nome")]
        public string Nome { get; set; }
        [BsonElement("cpf")]
        public string CPF { get; set; }
        [BsonElement("estado")]
        public string Estado { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }

    }
}