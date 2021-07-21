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
    public class AddProdutoCommand : IRequest<String>
    {
        public String Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Double Preco { get; set; }
        public int Quantidade { get; set; }
        public String Categoria { get; set; }
        public String UrlImagem { get; set; }

    }

    public class AddProdutoCommandHandler : IRequestHandler<AddProdutoCommand, String>
    {
        private readonly IMediator Mediator;
        private readonly IProdutoRepository ProdutoRepository;

        public AddProdutoCommandHandler(IMediator mediator, IProdutoRepository produtoRepository)
        {
            Mediator = mediator;
            ProdutoRepository = produtoRepository;

        }
        public async Task<String> Handle(AddProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(request.Nome, request.Descricao, request.Preco, request.Quantidade, request.Categoria);
            await ProdutoRepository.Save(produto);

            return await Task.FromResult("Produto cadastrado com sucesso");
        }
    }
}
