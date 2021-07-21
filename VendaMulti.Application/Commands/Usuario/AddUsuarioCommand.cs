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
    public class AddUsuarioCommand : IRequest<String>
    {
        public String Nome { get; set; }
        public String Senha { get; set; }
    }

    public class AddUsuarioCommandHandler : IRequestHandler<AddUsuarioCommand, String>
    {
        private readonly IMediator Mediator;
        private readonly IUsuarioRepository UsuarioRepository;

        public AddUsuarioCommandHandler(IMediator mediator, IUsuarioRepository usuarioRepository)
        {
            Mediator = mediator;
            UsuarioRepository = usuarioRepository;

        }
        public async Task<String> Handle(AddUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nome, request.Senha);
            await UsuarioRepository.Save(usuario);

            return await Task.FromResult("Usuário cadastrado com sucesso");
        }
    }
}
