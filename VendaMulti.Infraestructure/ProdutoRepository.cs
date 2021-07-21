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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context = null;

        public DatabaseSettings DatabaseSettings { get; set; }

        public ProdutoRepository(IOptions<DatabaseSettings> settings)
        {
            _context = new ProdutoContext(settings);
        }

        public async Task Delete(string id, Produto produto)
        {
            try
            {
                _context.Produtos.DeleteOne(produto => produto.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            var produtos = await _context.Produtos.Find(_ => true).ToListAsync();
            return await Task.FromResult(produtos);
        }

        public async Task<Produto> GetById(String id)
        {
            try
            {
               var produtos = _context.Produtos.Find<Produto>(produto => produto.Id == id).FirstOrDefault();
               return await Task.FromResult(produtos);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task Save(Produto produto)
        {
            try
            {
                await _context.Produtos.InsertOneAsync(produto);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task Update(string id, Produto produto)
        {
            try
            {
               _context.Produtos.ReplaceOne(prd => prd.Id == id, produto);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }            
        }
    }
}
