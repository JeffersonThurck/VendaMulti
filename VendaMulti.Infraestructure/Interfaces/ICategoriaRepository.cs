using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VendaMulti.Domain.Entities;

namespace VendaMulti.Infraestructure.Interfaces
{
    public interface ICategoriaRepository
    {
        Task Save(Categoria categoria);
        Task Update(string id, Categoria categoria);
        Task Delete(string id, Categoria categoria);
        Task<Categoria> GetById(String id);
        Task<List<Categoria>> GetAll();
    }
}
