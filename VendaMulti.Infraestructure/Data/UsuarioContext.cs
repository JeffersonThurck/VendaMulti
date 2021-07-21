using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using VendaMulti.Domain.Entities;

namespace VendaMulti.Infraestructure.Data
{
    public class UsuarioContext
    {
        private readonly IMongoDatabase _database;

        public UsuarioContext(IOptions<DatabaseSettings> settings)
        {
            var usuario = new MongoClient(settings.Value.ConnectionString);
            if (usuario != null)
                _database = usuario.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Usuario> Usuarios
        {
            get
            {
                return _database.GetCollection<Usuario>("Usuarios");
            }
        }

    }
}
