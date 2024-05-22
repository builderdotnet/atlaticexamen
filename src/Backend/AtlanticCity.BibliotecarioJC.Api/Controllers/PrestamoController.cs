using AtlanticCity.BibliotecarioJC.Application.Features.CambioEstado.CambioEstadoPrestamo;
using AtlanticCity.BibliotecarioJC.Application.Features.Devolucion.DevolverLibro;
using AtlanticCity.BibliotecarioJC.Application.Features.Prestamos.ConsultarPrestamo;
using AtlanticCity.BibliotecarioJC.Application.Features.Prestamos.RegistrarPrestamo;
using AtlanticCity.BibliotecarioJC.Domain.Primitives;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtlanticCity.BibliotecarioJC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IMediator mediator;
        private ILogger<PrestamoController> logger;
        private IHttpContextAccessor httpContextAccessor;

        public PrestamoController(IMediator mediator, ILogger<PrestamoController> logger, IHttpContextAccessor httpContextAccessor)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("prestar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<RegistrarPrestamoCommandResponse>))]
        public async Task<IActionResult> RegistrarPrestamo(RegistrarPrestamoCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("cambioestado")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<CambioEstadoPrestamoCommandResponse>))]
        public async Task<IActionResult> CambioEstadoPrestamo(CambioEstadoPrestamoCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("devolver")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<DevolverLibroCommandResponse>))]
        public async Task<IActionResult> DevolverPrestamo(DevolverLibroCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("consultar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<List<ConsultarPrestamoQueryResponse>>))]
        public async Task<IActionResult> ConsultarPrestamos(ConsultarPrestamoQuery request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}