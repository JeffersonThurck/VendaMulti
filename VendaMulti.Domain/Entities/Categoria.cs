using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text;

namespace VendaMulti.Domain.Entities
{
    public class Categoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public String Nome { get; set; }

        public Categoria(string id, string nome){
            Id = id;
            Nome = nome;
        }
    }
}
