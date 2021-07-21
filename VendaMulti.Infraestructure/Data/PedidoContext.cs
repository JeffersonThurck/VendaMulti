using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using VendaMulti.Domain.Entities;

namespace VendaMulti.Infraestructure.Data
{
    public class PedidoContext
    {
        private readonly IMongoDatabase _database;

        public PedidoContext(IOptions<DatabaseSettings> settings)
        {
            var pedido = new MongoClient(settings.Value.ConnectionString);
            if (pedido != null)
                _database = pedido.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Pedido> Pedidos
        {
            get
            {
                return _database.GetCollection<Pedido>("Pedidos");
            }
        }

    }
}
