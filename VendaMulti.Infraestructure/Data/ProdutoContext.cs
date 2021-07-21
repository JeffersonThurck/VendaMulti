using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using VendaMulti.Domain.Entities;

namespace VendaMulti.Infraestructure.Data
{
    public class ProdutoContext
    {
        private readonly IMongoDatabase _database;

        public ProdutoContext(IOptions<DatabaseSettings> settings)
        {
            var produto = new MongoClient(settings.Value.ConnectionString);
            if (produto != null)
                _database = produto.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Produto> Produtos
        {
            get
            {
                return _database.GetCollection<Produto>("Produtos");
            }
        }
    }
}
