using AtlanticCity.BibliotecarioJC.Domain.Interfaces.UoWs;
using AtlanticCity.BibliotecarioJC.Domain.Primitives;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Maestros.ListarLibro
{
    public class ListarLibroQuery : IRequest<Result<List<ListarLibroQueryResponse>>>
    {
        public class ListarLibroQueryHandler : IRequestHandler<ListarLibroQuery, Result<List<ListarLibroQueryResponse>>>
        {
            private readonly IBibliotecarioUoW uow;
            private readonly IMapper mapper;

            public ListarLibroQueryHandler(IBibliotecarioUoW uow, IMapper mapper)
            {
                this.uow = uow;
                this.mapper = mapper;
            }

            public async Task<Result<List<ListarLibroQueryResponse>>> Handle(ListarLibroQuery request, CancellationToken cancellationToken)
            {
                var data = await uow.Libros.GetAllAsync(x => x.EsActivo == true);
                var librosResult = mapper.Map<List<ListarLibroQueryResponse>>(data);
                return new Result<List<ListarLibroQueryResponse>>("Ok", librosResult);
            }
        }
    }
}