using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using VendaMulti.Domain.Entities;
using VendaMulti.Infraestructure.Interfaces;

namespace VendaMulti.Application.Commands
{
    public class AddPedidoCommand : IRequest<Pedido>
    {
        public Double valor {get; set;}

        public String id {get;set;}
        public List<Produto> produtos {get; set;}
    }

    public class AddPedidoCommandHandler : IRequestHandler<AddPedidoCommand, Pedido>
    {
        private readonly IPedidoRepository PedidoRepository;

        public AddPedidoCommandHandler(IPedidoRepository pedidoRepository){

            PedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> Handle(AddPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Pedido(request.valor, request.produtos);
            var retorno = PedidoRepository.Save(pedido);

            return await Task.FromResult(retorno);
        }
    }
}