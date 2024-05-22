using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Devolucion.DevolverLibro
{
    public record DevolverLibroCommandRequest(int idPrestamo, DateTime fechaEntrega, string observacion);
}