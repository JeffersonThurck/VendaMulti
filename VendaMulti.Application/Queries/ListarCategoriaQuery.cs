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
    public class ListarCategoriaQuery : IRequest<IEnumerable<Categoria>>
    {

    }
    public class ListarCategoriaQueryHandler : IRequestHandler<ListarCategoriaQuery, IEnumerable<Categoria>>
    {
        private readonly IMediator Mediator;
        private readonly ICategoriaRepository CategoriaRepository;

        public ListarCategoriaQueryHandler(IMediator mediator, ICategoriaRepository categoriaRepository)
        {
            Mediator = mediator;
            CategoriaRepository = categoriaRepository;

        }
        public async Task<IEnumerable<Categoria>> Handle(ListarCategoriaQuery request, CancellationToken cancellationToken)
        {
            var result = CategoriaRepository.GetAll();

            return await await Task.FromResult(result);
        }
    }
}
