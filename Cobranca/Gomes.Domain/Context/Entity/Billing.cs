using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Gomes.Domain.Context.Entity
{
    public class Billing
    {

        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("cpf")]
        public string CPF { get; set; }
        [BsonElement("valor")]
        public decimal Valor { get; set; }
        [BsonElement("vencimento")]
        public DateTime Vencimento { get; set; }


    }
}