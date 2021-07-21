using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VendaMulti.Domain.Entities;

namespace VendaMulti.Infraestructure.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido Save(Pedido pedido);
        Task Update(string id, Pedido pedido);
        Task Delete(string id, Pedido pedido);
        Task<Pedido> GetById(String id);
        Task<List<Pedido>> GetAll();
    }
}
