using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using VendaMulti.Domain.Entities;
using VendaMulti.Infraestructure;
using VendaMulti.Infraestructure.Interfaces;

namespace VendaMulti.Application.Queries
{
    public class ListarPedidoQuery : IRequest<IEnumerable<Pedido>>
    {

    }
    public class ListarPedidoQueryHandler : IRequestHandler<ListarPedidoQuery, IEnumerable<Pedido>>
    {
        private readonly IMediator Mediator;
        private readonly IPedidoRepository PedidoRepository;

        public ListarPedidoQueryHandler(IMediator mediator, IPedidoRepository pedidoRepository)
        {
            Mediator = mediator;
            PedidoRepository = pedidoRepository;

        }
        public async Task<IEnumerable<Pedido>> Handle(ListarPedidoQuery request, CancellationToken cancellationToken)
        {
            var result = PedidoRepository.GetAll();

            return await await Task.FromResult(result);
        }
    }
}
