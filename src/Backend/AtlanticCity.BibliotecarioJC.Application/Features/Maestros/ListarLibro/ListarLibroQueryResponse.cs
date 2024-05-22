using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.BibliotecarioJC.Application.Features.Maestros.ListarLibro
{
    public record ListarLibroQueryResponse(string value, string text, string data);
}