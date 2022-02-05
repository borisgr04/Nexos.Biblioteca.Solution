using Biblioteca.Core.Application.Editoriales;
using Biblioteca.Core.Application.Libros;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EditorialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<LibroController>
        [ProducesResponseType(StatusCodes.Status201Created)]    /* 201 => Created */
        [ProducesResponseType(StatusCodes.Status400BadRequest)] /* 400 => BadRequest */
        [HttpPost]
        public async Task<ActionResult<RegistrarEditorialResponse>> Post(RegistrarEditorialRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
