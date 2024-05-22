using AtlanticCity.BibliotecarioJC.Domain.Interfaces.Repositories;
using AtlanticCity.BibliotecarioJC.Domain.Interfaces.UoWs;
using AtlanticCity.BibliotecarioJC.InfraStructure.Contexts;
using AtlanticCity.BibliotecarioJC.InfraStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.InfraStructure.UoWs
{
    public class BibliotecarioUoW : IBibliotecarioUoW
    {
        private BibliotecarioContext context;

        public BibliotecarioUoW(BibliotecarioContext context)
        {
            this.context = context;
        }

        public IPrestamoBitacoraRepository PrestamosBitacora => new PrestamoBitacoraRepository(context);

        public IPrestamoRepository Prestamos => new PrestamoRepository(context);

        public IUsuarioRepository Usuarios => new UsuarioRepository(context);

        public IEstadoRepository Estados => new EstadoRepository(context);

        public ILibroRepository Libros => new LibroRepository(context);

        public IInventarioRepository Inventarios => new InventarioRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}