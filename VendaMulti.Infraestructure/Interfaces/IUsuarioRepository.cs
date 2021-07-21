using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VendaMulti.Domain.Entities;

namespace VendaMulti.Infraestructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Save(Usuario usuario);
        Task Update(string id, Usuario usuario);
        Task Delete(string id, Usuario usuario);
        Task<Usuario> GetById(String id);
        Usuario GetByName(String nome, String senha);
        Task<List<Usuario>> GetAll();
    }
}
