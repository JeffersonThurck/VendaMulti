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
    public class Usuario
    {
        public Usuario(string nome, string senha){
            Nome = nome;
            Senha = senha;
        }

        [JsonConstructor]
        public Usuario() { }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }        
        public String Nome { get; set; }
        public String Senha { get; set; }
        public String Role { get; set; }

    }
}
