using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VendaMulti.Application.Queries;
using VendaMulti.Application.Commands;
using VendaMulti.Domain.Entities;
using VendaMulti.Infraestructure.Interfaces;

namespace VendaMulti.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator Mediator;
        private readonly IUsuarioRepository UsuarioRepository;

        public UsuarioController(IMediator mediator, IUsuarioRepository usuarioRepository)
        {
            Mediator = mediator;
            UsuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new ListarUsuarioQuery());
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUsuarioCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }        
    }
}
