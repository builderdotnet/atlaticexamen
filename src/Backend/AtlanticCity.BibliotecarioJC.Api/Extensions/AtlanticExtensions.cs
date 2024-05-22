using AtlanticCity.BibliotecarioJC.Application.Features.Maestros.ListarLibro;
using AtlanticCity.BibliotecarioJC.Domain.Interfaces.Repositories;
using AtlanticCity.BibliotecarioJC.Domain.Interfaces.UoWs;
using AtlanticCity.BibliotecarioJC.Domain.Settings;
using AtlanticCity.BibliotecarioJC.InfraStructure.Contexts;
using AtlanticCity.BibliotecarioJC.InfraStructure.Repositories;
using AtlanticCity.BibliotecarioJC.InfraStructure.UoWs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AtlanticCity.BibliotecarioJC.Api.Extensions
{
    public static class AtlanticExtensions
    {
        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void AddCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("FRONTEND_CORS", builder =>
            {
                builder.WithOrigins("*", "http://localhost:4200/", "https://localhost:4200/")
                                   .AllowCredentials()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader().SetIsOriginAllowed(origin => true)
                                   .WithExposedHeaders("Content-Disposition");
            }));
        }

        private static void AddPersistences(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<BibliotecarioContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("BibliotecarioDb"));
            });
        }

        public static void AddAtlantic(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwagger();
            builder.Services.AddCors();
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(ListarLibroQuery)));
            builder.Services.Configure<BibliotecarioSettings>(builder.Configuration.GetSection("Atlantic"));
            builder.Services.AddPersistences(builder);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(ListarLibroQueryMapper)));

            builder.Services.AddMediatR(config => { config.RegisterServicesFromAssembly(typeof(ListarLibroQuery).Assembly); });
            builder.Services.AddTransient<IEstadoRepository, EstadoRepository>();
            builder.Services.AddTransient<IPrestamoRepository, PrestamoRepository>();
            builder.Services.AddTransient<IPrestamoBitacoraRepository, PrestamoBitacoraRepository>();
            builder.Services.AddTransient<ILibroRepository, LibroRepository>();
            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddTransient<IInventarioRepository, InventarioRepository>();

            builder.Services.AddTransient<IBibliotecarioUoW, BibliotecarioUoW>();
        }
    }
}