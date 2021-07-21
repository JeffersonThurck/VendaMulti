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
    public class PedidoController : ControllerBase
    {
        private readonly IMediator Mediator;
        private readonly IPedidoRepository PedidoRepository;

        public PedidoController(IMediator mediator, IPedidoRepository pedidoRepository)
        {
            Mediator = mediator;
            PedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new ListarPedidoQuery());
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //Criar validações
            var result = await PedidoRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddPedidoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }        
    }
}
