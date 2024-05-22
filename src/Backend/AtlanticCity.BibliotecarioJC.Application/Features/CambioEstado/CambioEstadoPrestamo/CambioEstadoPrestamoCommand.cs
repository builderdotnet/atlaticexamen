using AtlanticCity.BibliotecarioJC.Application.Features.Devolucion.DevolverLibro;
using AtlanticCity.BibliotecarioJC.Domain.Enums;
using AtlanticCity.BibliotecarioJC.Domain.Interfaces.UoWs;
using AtlanticCity.BibliotecarioJC.Domain.Primitives;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.CambioEstado.CambioEstadoPrestamo
{
    public record CambioEstadoPrestamoCommand : CambioEstadoPrestamoCommandRequest, IRequest<Result<CambioEstadoPrestamoCommandResponse>>
    {
        public CambioEstadoPrestamoCommand(int idPrestamo, int idEstado, string observacion) : base(idPrestamo, idEstado, observacion)
        {
        }
        public class CambioEstadoPrestamoCommandHandler : IRequestHandler<CambioEstadoPrestamoCommand, Result<CambioEstadoPrestamoCommandResponse>>
        {
            private readonly IBibliotecarioUoW uow;

            public CambioEstadoPrestamoCommandHandler(IBibliotecarioUoW uow)
            {
                this.uow = uow;
            }

            public async Task<Result<CambioEstadoPrestamoCommandResponse>> Handle(CambioEstadoPrestamoCommand request, CancellationToken cancellationToken)
            {
                var prestamo = await uow.Prestamos.Obtener(request.idPrestamo);
                if (prestamo is not null)
                {
                    prestamo.IdEstado = request.idEstado;

                    uow.Prestamos.Update(prestamo);
                    await uow.CommitAsync();
                    return new Result<CambioEstadoPrestamoCommandResponse>("Prestamo devuelvo modificado!", new CambioEstadoPrestamoCommandResponse(request.idPrestamo));
                }
                else
                {
                    return new Result<CambioEstadoPrestamoCommandResponse>(new List<string>() { "No existe el prestamo a modificar!" });
                }
            }
        }
    }
}