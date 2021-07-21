using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VendaMulti.Domain.Entities;

namespace VendaMulti.Infraestructure.Interfaces
{
    public interface IProdutoRepository
    {
        Task Save(Produto produto);
        Task Update(string id, Produto Produto);
        Task Delete(string id, Produto produto);
        Task<Produto> GetById(String id);
        Task<IEnumerable<Produto>> GetAll();
    }
}
