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
    public class ListarUsuarioQuery : IRequest<IEnumerable<Usuario>>
    {

    }
    public class ListarUsuarioQueryHandler : IRequestHandler<ListarUsuarioQuery, IEnumerable<Usuario>>
    {
        private readonly IMediator Mediator;
        private readonly IUsuarioRepository UsuarioRepository;

        public ListarUsuarioQueryHandler(IMediator mediator, IUsuarioRepository usuarioRepository)
        {
            Mediator = mediator;
            UsuarioRepository = usuarioRepository;

        }
        public async Task<IEnumerable<Usuario>> Handle(ListarUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = UsuarioRepository.GetAll();

            return await await Task.FromResult(result);
        }
    }
}