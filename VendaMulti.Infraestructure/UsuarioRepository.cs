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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context = null;

        public DatabaseSettings DatabaseSettings { get; set; }

        public UsuarioRepository(IOptions<DatabaseSettings> settings)
        {
            _context = new UsuarioContext(settings);
        }

        public Task Delete(string id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> GetAll()
        {
            var usuarios = _context.Usuarios.Find(new BsonDocument()).ToListAsync().Result;

            return await Task.FromResult(usuarios);
        }

        public Task<Usuario> GetById(string id)
        {
            try
            {
                var usuarios = _context.Usuarios.Find<Usuario>(usuario => usuario.Id == id).FirstOrDefault();
                return Task.FromResult(usuarios);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Usuario GetByName(string username, string senha)
        {
            try
            {
                var usuarios = _context.Usuarios.Find<Usuario>(x => x.Username.ToLower() == username.ToLower() && x.Senha == senha).FirstOrDefault();

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task Save(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.InsertOneAsync(usuario);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task Update(string id, Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
