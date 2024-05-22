using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Domain.Enums
{
    public enum EstadoPrestamoEnum
    {
        PendienteAprobacion = 1,
        Aprobado = 2,
        Rechazado = 3,
        Perdido = 4,
        Devuelto = 5,
    }
}