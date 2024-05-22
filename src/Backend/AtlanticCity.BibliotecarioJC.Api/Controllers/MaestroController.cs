using AtlanticCity.BibliotecarioJC.Application.Features.Maestros.ListarEstado;
using AtlanticCity.BibliotecarioJC.Application.Features.Maestros.ListarLibro;
using AtlanticCity.BibliotecarioJC.Domain.Primitives;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtlanticCity.BibliotecarioJC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        private readonly IMediator mediator;
        private ILogger<MaestroController> logger;
        private IHttpContextAccessor httpContextAccessor;

        public MaestroController(IMediator mediator, ILogger<MaestroController> logger, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("libros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<List<ListarLibroQueryResponse>>))]
        public async Task<IActionResult> ListarLibros()
        {
            var result = await mediator.Send(new ListarLibroQuery());

            return Ok(result);
        }

        [HttpGet("estados")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<List<ListarEstadoQueryResponse>>))]
        public async Task<IActionResult> ListarEstados()
        {
            var result = await mediator.Send(new ListarEstadoQuery());

            return Ok(result);
        }
    }
}