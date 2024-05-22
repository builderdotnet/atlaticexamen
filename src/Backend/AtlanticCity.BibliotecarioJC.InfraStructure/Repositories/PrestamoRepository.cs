using AtlanticCity.BibliotecarioJC.Domain.Interfaces.Repositories;
using AtlanticCity.BibliotecarioJC.InfraStructure.Contexts;
using AtlanticCity.BibliotecarioJC.InfraStructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.InfraStructure.Repositories
{
    public class PrestamoRepository : RepositoryCommon<Prestamo>, IPrestamoRepository
    {
        public PrestamoRepository(BibliotecarioContext context) : base(context)
        {
        }

        public ValueTask<int> CambioEstado(int idPrestamo, string observacion, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public ValueTask<int> Devolver(int idPrestamo, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Prestamo> Obtener(int idPrestamo)
        {
            var prestamo = await _context.Prestamos
                .Where(x => x.IdPrestamo == idPrestamo)
                .Include(x => x.PrestamoBitacoras)
                .Include(x => x.PrestamoDetalles)
                .FirstOrDefaultAsync();
            return prestamo;
        }

        public async ValueTask<int> Prestar(Prestamo prestamo)
        {
            var idLibrosPrestados = prestamo.PrestamoDetalles.Select(x => x.IdLibro).Distinct().ToList();
            var stockLibrosPrestados = _context.Libros.Where(x => idLibrosPrestados.Contains(x.IdLibro));

            _context.Prestamos.Add(prestamo);
            return prestamo.IdPrestamo;
        }
    }
}