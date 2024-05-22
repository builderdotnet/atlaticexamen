using AtlanticCity.BibliotecarioJC.Domain.Enums;
using AtlanticCity.BibliotecarioJC.Domain.Interfaces.UoWs;
using AtlanticCity.BibliotecarioJC.Domain.Primitives;
using AtlanticCity.BibliotecarioJC.Domain.Settings;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Devolucion.DevolverLibro
{
    public record DevolverLibroCommand : DevolverLibroCommandRequest, IRequest<Result<DevolverLibroCommandResponse>>
    {
        public DevolverLibroCommand(int idPrestamo, DateTime fechaEntrega, string observacion) : base(idPrestamo, fechaEntrega, observacion)
        {
        }
        public class DevolverLibroCommandHandler : IRequestHandler<DevolverLibroCommand, Result<DevolverLibroCommandResponse>>
        {
            private readonly IBibliotecarioUoW uow;

            public DevolverLibroCommandHandler(IBibliotecarioUoW uow)
            {
                this.uow = uow;
            }

            public async Task<Result<DevolverLibroCommandResponse>> Handle(DevolverLibroCommand request, CancellationToken cancellationToken)
            {
                var prestamoDevuelto = await uow.Prestamos.Obtener(request.idPrestamo);
                if (prestamoDevuelto is not null)
                {
                    prestamoDevuelto.IdEstado = (int)EstadoPrestamoEnum.Devuelto;

                    foreach (var item in prestamoDevuelto.PrestamoDetalles)
                    {
                        var movimientoInventario = await uow.Inventarios.FirstOrDefaultAsync(x => x.IdLibro == item.IdLibro && x.IdEstante == item.IdEstante);
                        movimientoInventario.StockActual++;
                        uow.Inventarios.Update(movimientoInventario);
                        item.FechaEntrega = DateTime.Today;
                    }
                    uow.Prestamos.Update(prestamoDevuelto);
                    await uow.CommitAsync();
                    return new Result<DevolverLibroCommandResponse>("Prestamo devuelvo correctamente!", new DevolverLibroCommandResponse(request.idPrestamo));
                }
                else
                {
                    return new Result<DevolverLibroCommandResponse>(new List<string>() { "No existe el prestamo a devolver!" });
                }
            }
        }
    }
}