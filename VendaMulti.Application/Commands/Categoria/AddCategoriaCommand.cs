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
    public class AddCategoriaCommand : IRequest<String>
    {
        public String Id {get; set;}
        public String Nome {get; set;}

    }

    public class AddCategoriaCommandHandler : IRequestHandler<AddCategoriaCommand, String>
    {
        private readonly IMediator Mediator;
        private readonly ICategoriaRepository CategoriaRepository;

        public AddCategoriaCommandHandler(IMediator mediator, ICategoriaRepository categoriaRepository)
        {
            Mediator = mediator;
            CategoriaRepository = categoriaRepository;

        }
        public async Task<String> Handle(AddCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria(request.Id, request.Nome);
            await CategoriaRepository.Save(categoria);

            return await Task.FromResult("Categoria cadastrado com sucesso.");
        }
    }
}
