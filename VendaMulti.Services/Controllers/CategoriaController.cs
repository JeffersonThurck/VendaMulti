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
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator Mediator;
        private readonly ICategoriaRepository CategoriaRepository;

        public CategoriaController(IMediator mediator, ICategoriaRepository categoriaRepository)
        {
            Mediator = mediator;
            CategoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new ListarCategoriaQuery());
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddCategoriaCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }        
    }
}
