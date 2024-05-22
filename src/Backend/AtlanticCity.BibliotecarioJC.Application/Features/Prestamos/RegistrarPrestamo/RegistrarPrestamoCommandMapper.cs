using AtlanticCity.BibliotecarioJC.Application.Features.Maestros.ListarLibro;
using AtlanticCity.BibliotecarioJC.Domain.Enums;
using AtlanticCity.BibliotecarioJC.InfraStructure.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Prestamos.RegistrarPrestamo
{
    public class RegistrarPrestamoCommandMapper : Profile
    {
        public RegistrarPrestamoCommandMapper()
        {
            AllowNullCollections = true;
            CreateMap<RegistrarPrestamoCommandRequest, Prestamo>()
             .ForCtorParam("FechaPrestamo", m => m.MapFrom(x => x.fechaPrestamo))
             .ForCtorParam("IdUsuario", m => m.MapFrom(x => x.idUsuario))
             .ForCtorParam("Observacion", m => m.MapFrom(x => x.observacion))
             .ForCtorParam("IdEstado", m => m.MapFrom(x => EstadoPrestamoEnum.PendienteAprobacion));

            CreateMap<RegistrarPrestamoDetalleCommandRequest, PrestamoDetalle>()
            .ForCtorParam("CobroPerdida", m => m.MapFrom(x => 0))
            .ForCtorParam("CobroPrestamo", m => m.MapFrom(x => 0))
            .ForCtorParam("IdLibro", m => m.MapFrom(x => x.idLibro))
            .ForCtorParam("IdEstante", m => m.MapFrom(x => x.idEstante))
            .ForCtorParam("IdEstado", m => m.MapFrom(x => x.idEstado))
            .ForCtorParam("Observacion", m => m.MapFrom(x => x.observacion));
        }
    }
}