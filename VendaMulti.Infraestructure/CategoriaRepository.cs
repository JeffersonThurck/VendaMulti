using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VendaMulti.Domain.Entities;
using VendaMulti.Infraestructure.Data;
using VendaMulti.Infraestructure.Interfaces;

namespace VendaMulti.Infraestructure
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly CategoriaContext _context = null;

        public DatabaseSettings DatabaseSettings { get; set; }

        public CategoriaRepository(IOptions<DatabaseSettings> settings)
        {
            _context = new CategoriaContext(settings);
        }

        public Task Delete(string id, Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Categoria>> GetAll()
        {
            var pedidos = _context.Categorias.Find(new BsonDocument()).ToListAsync().Result;

            return await Task.FromResult(pedidos);
        }

        public Task<Categoria> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Save(Categoria categoria)
        {
            try
            {
                await _context.Categorias.InsertOneAsync(categoria);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task Update(string id, Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
