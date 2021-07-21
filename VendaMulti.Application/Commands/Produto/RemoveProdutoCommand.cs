using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using VendaMulti.Domain.Entities;
using VendaMulti.Infraestructure.Interfaces;

namespace VendaMulti.Application.Commands
{
    public class RemoveProdutoCommand : IRequest<String>
    {
        public String Id { get; set; }
    
    }

    public class RemoveProductCommandHandler : IRequestHandler<RemoveProdutoCommand, String>
    {
        private readonly IMediator Mediator;
        private readonly IProdutoRepository ProdutoRepository;

        public RemoveProductCommandHandler(IMediator mediator, IProdutoRepository produtoRepository)
        {
            Mediator = mediator;
            ProdutoRepository = produtoRepository;

        }
        public async Task<String> Handle(RemoveProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await ProdutoRepository.GetById(request.Id);
            await ProdutoRepository.Delete(request.Id, produto);

            return await Task.FromResult("Produto removido com sucesso");
        }
    }
}
