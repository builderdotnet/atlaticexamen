using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Inventarios.ConsultaDisponibilidad
{
    public record ConsultaDisponibilidadQueryResponse(bool EsDisponible , int stockActual); 
}