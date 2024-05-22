using AtlanticCity.BibliotecarioJC.InfraStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Domain.Interfaces.Repositories
{
    public interface IPrestamoRepository : IRepositoryCommon<Prestamo>
    {
        ValueTask<Prestamo> Obtener(int idPrestamo);

        ValueTask<int> Prestar(Prestamo prestamo);

        ValueTask<int> Devolver(int idPrestamo, int idUsuario);

        ValueTask<int> CambioEstado(int idPrestamo, string observacion, int idUsuario);
    }
}