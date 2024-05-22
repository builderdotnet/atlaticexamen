using AtlanticCity.BibliotecarioJC.Domain.Interfaces.Repositories;
using AtlanticCity.BibliotecarioJC.InfraStructure.Contexts;
using AtlanticCity.BibliotecarioJC.InfraStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.InfraStructure.Repositories
{
    public class LibroRepository : RepositoryCommon<Libro>, ILibroRepository
    {
        public LibroRepository(BibliotecarioContext context) : base(context)
        {
        }
    }
}