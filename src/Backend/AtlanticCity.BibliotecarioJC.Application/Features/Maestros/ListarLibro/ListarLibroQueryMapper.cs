using AtlanticCity.BibliotecarioJC.InfraStructure.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Maestros.ListarLibro
{
    public class ListarLibroQueryMapper : Profile
    {
        public ListarLibroQueryMapper()
        {
            AllowNullCollections = true;

            CreateMap<Libro, ListarLibroQueryResponse>()
             .ForCtorParam("data", m => m.MapFrom(x => x.CodigoBarra))
             .ForCtorParam("text", m => m.MapFrom(x => x.NombreLibro))
             .ForCtorParam("value", m => m.MapFrom(x => x.IdLibro));
        }
    }
}