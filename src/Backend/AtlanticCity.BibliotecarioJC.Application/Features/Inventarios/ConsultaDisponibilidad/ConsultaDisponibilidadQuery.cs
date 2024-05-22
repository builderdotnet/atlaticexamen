using AtlanticCity.BibliotecarioJC.Domain.Interfaces.UoWs;
using AtlanticCity.BibliotecarioJC.Domain.Primitives;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Inventarios.ConsultaDisponibilidad
{
    public record ConsultaDisponibilidadQuery : ConsultaDisponibilidadQueryRequest, IRequest<Result<ConsultaDisponibilidadQueryResponse>>
    {
        public ConsultaDisponibilidadQuery(int idLibro, int idEstante) : base(idLibro, idEstante)
        {
        }

        public class ConsultaDisponibilidadQueryHandler : IRequestHandler<ConsultaDisponibilidadQuery, Result<ConsultaDisponibilidadQueryResponse>>
        {
            private readonly IBibliotecarioUoW uow;

            public ConsultaDisponibilidadQueryHandler(IBibliotecarioUoW uow)
            {
                this.uow = uow;
            }

            public async Task<Result<ConsultaDisponibilidadQueryResponse>> Handle(ConsultaDisponibilidadQuery request, CancellationToken cancellationToken)
            {
                var stocksLibro = await uow.Inventarios.GetAllAsync(x => x.IdLibro == request.idLibro &&
                                                                                        x.IdEstante == request.idEstante &&
                                                                                        x.EsActivo == true);
                int stockActual = stocksLibro.Sum(x => x.StockActual.Value);
                return new Result<ConsultaDisponibilidadQueryResponse>("Ok", new ConsultaDisponibilidadQueryResponse(stockActual > 0, stockActual));
            }
        }
    }
}