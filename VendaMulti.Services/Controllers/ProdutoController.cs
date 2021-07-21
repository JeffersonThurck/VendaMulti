using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendaMulti.Application.Commands;
using VendaMulti.Domain.Entities;
using VendaMulti.Infraestructure.Interfaces;

namespace VendaMulti.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator Mediator;
        private readonly IProdutoRepository ProdutoRepository;
        
        public ProdutoController(IMediator mediator, IProdutoRepository produtoRepository)
        {
            Mediator = mediator;
            ProdutoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await ProdutoRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProdutoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await ProdutoRepository.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var dto = new RemoveProdutoCommand { Id = id };
            var result = await Mediator.Send(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateProdutoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
