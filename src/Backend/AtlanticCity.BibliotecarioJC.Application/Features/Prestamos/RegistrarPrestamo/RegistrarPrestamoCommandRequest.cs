using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Prestamos.RegistrarPrestamo
{
    public record RegistrarPrestamoCommandRequest
    {
        public int idUsuario { get; init; }
        public string observacion { get; init; }
        public DateTime fechaPrestamo { get; init; }
        public RegistrarPrestamoDetalleCommandRequest[] detalles { get; set; }
    }
    public record RegistrarPrestamoDetalleCommandRequest
    {
        public int idLibro { get; init; }
        public decimal cobroPrestamo { get; init; }
        public int idEstado { get; init; }
        public string observacion { get; init; }
        public int idEstante { get; init; }
    }
}