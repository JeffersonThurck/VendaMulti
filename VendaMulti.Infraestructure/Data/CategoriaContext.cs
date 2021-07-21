using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using VendaMulti.Domain.Entities;

namespace VendaMulti.Infraestructure.Data
{
    public class CategoriaContext
    {
        private readonly IMongoDatabase _database;

        public CategoriaContext(IOptions<DatabaseSettings> settings)
        {
            var categoria = new MongoClient(settings.Value.ConnectionString);
            if (categoria != null)
                _database = categoria.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Categoria> Categorias
        {
            get
            {
                return _database.GetCollection<Categoria>("Categorias");
            }
        }

    }
}
