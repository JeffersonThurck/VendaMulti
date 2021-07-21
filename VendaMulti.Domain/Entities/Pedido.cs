using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VendaMulti.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Pedido
    {
        public Pedido(double valor, List<Produto> produtos){
            Valor = valor;
            Produtos = produtos;
        }

        [JsonConstructor]
        public Pedido() { }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        
        public List<Produto> Produtos { get; set; }
        public Double Valor { get; set; }
        
    }
}
