using AtlanticCity.BibliotecarioJC.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Domain.Interfaces.UoWs
{
    public interface IBibliotecarioUoW
    {
        IPrestamoBitacoraRepository PrestamosBitacora { get; }
        IPrestamoRepository Prestamos { get; }
        IUsuarioRepository Usuarios { get; }
        IEstadoRepository Estados { get; }
        ILibroRepository Libros { get; }
        IInventarioRepository Inventarios { get; }

        Task<int> CommitAsync();
    }
}