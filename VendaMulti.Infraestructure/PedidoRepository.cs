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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _context = null;

        public DatabaseSettings DatabaseSettings { get; set; }

        public PedidoRepository(IOptions<DatabaseSettings> settings)
        {
            _context = new PedidoContext(settings);
        }

        public Task Delete(string id, Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pedido>> GetAll()
        {
            var pedidos = _context.Pedidos.Find(new BsonDocument()).ToListAsync().Result;

            return await Task.FromResult(pedidos);
        }

        public async Task<Pedido> GetById(string id)
        {
             try
            {
               var pedidos = _context.Pedidos.Find<Pedido>(pedido => pedido.Id == id).FirstOrDefault();
               return await Task.FromResult(pedidos);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Pedido Save(Pedido pedido)
        {
            try
            {
                 _context.Pedidos.InsertOneAsync(pedido);
                return pedido;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task Update(string id, Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
