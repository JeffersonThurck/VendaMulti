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
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Double Preco { get; set; }
        public int Quantidade { get; set; }
        public String Categoria { get; set; }
        public String UrlImagem { get; set; }

        
        [JsonConstructor]
        public Produto() { }

        public Produto(String id, String nome, String descricao, double preco, int quantidade, String categoria, String urlImagem)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
            Categoria = categoria;
            UrlImagem = urlImagem;
        }

        public Produto(String nome, String descricao, double preco, int quantidade, string categoria)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
            Categoria = categoria;
        }
    }
}
