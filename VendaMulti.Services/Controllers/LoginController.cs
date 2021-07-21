using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendaMulti.Domain.Entities;
using VendaMulti.Infraestructure;
using VendaMulti.Infraestructure.Interfaces;

namespace VendaMulti.Services.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMediator Mediator;
        private readonly IUsuarioRepository UsuarioRepository;

        public LoginController(IMediator mediator, IUsuarioRepository usuarioRepository)
        {
            Mediator = mediator;
            UsuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("auth")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
        {
            var user = UsuarioRepository.GetByName(model.Username, model.Senha);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            var token = TokenService.GenerateToken(user);
            user.Senha = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}

