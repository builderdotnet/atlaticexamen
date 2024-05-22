using AtlanticCity.BibliotecarioJC.Domain.Enums;
using AtlanticCity.BibliotecarioJC.Domain.Interfaces.UoWs;
using AtlanticCity.BibliotecarioJC.Domain.Primitives;
using AtlanticCity.BibliotecarioJC.Domain.Settings;
using AtlanticCity.BibliotecarioJC.InfraStructure.Models;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Prestamos.RegistrarPrestamo
{
    public record RegistrarPrestamoCommand : RegistrarPrestamoCommandRequest, IRequest<Result<RegistrarPrestamoCommandResponse>>
    {
        public record RegistrarPrestamoCommandHandler : IRequestHandler<RegistrarPrestamoCommand, Result<RegistrarPrestamoCommandResponse>>
        {
            private readonly IBibliotecarioUoW uow;
            private readonly IMapper mapper;
            private readonly BibliotecarioSettings settings;

            public RegistrarPrestamoCommandHandler(IBibliotecarioUoW uow, IMapper mapper, IOptions<BibliotecarioSettings> options)
            {
                this.uow = uow;
                this.mapper = mapper;
                this.settings = options.Value;
            }

            public async Task<Result<RegistrarPrestamoCommandResponse>> Handle(RegistrarPrestamoCommand request, CancellationToken cancellationToken)
            {
                if (request.detalles.Count() > settings.MaximoLibros)
                    return new Result<RegistrarPrestamoCommandResponse>(new List<string> { "El prestamo excede la cantidad de libros permitidos (3 unidades)!" });

                var detalles = mapper.Map<List<PrestamoDetalle>>(request.detalles);
                Prestamo prestamo = mapper.Map<Prestamo>(request);

                foreach (var item in detalles)
                {
                    prestamo.PrestamoDetalles.Add(item);
                    var movimientoInventario = await uow.Inventarios.FirstOrDefaultAsync(x => x.IdLibro == item.IdLibro && x.IdEstante == item.IdEstante);
                    movimientoInventario.StockActual--;
                    uow.Inventarios.Update(movimientoInventario);
                }
                PrestamoBitacora bitacora = new PrestamoBitacora()
                {
                    FechaOperacion = DateTime.Today,
                    IdEstado = (int)EstadoPrestamoEnum.PendienteAprobacion,
                    IdUsuario = request.idUsuario,
                    Observacion = "Registro de Prestamo!"
                };
                prestamo.PrestamoBitacoras.Add(bitacora);
                var registroAfectados = await uow.Prestamos.AddAsync(prestamo);
                await uow.CommitAsync();
                int idPrestamo = registroAfectados.Entity.IdPrestamo;
                return new Result<RegistrarPrestamoCommandResponse>("Prestamo registrado correctamente!", new RegistrarPrestamoCommandResponse(idPrestamo));
            }
        }
    }
}