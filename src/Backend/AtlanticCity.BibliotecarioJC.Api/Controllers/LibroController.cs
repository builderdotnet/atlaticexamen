using AtlanticCity.BibliotecarioJC.Application.Features.Inventarios.ConsultaDisponibilidad;
using AtlanticCity.BibliotecarioJC.Domain.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AtlanticCity.BibliotecarioJC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMediator mediator;
        private ILogger<LibroController> logger;
        private IHttpContextAccessor httpContextAccessor;

        public LibroController(IMediator mediator, ILogger<LibroController> logger, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("disponibilidad")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<ConsultaDisponibilidadQueryResponse>))]
        public async Task<IActionResult> RegistrarPrestamo(ConsultaDisponibilidadQuery request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}