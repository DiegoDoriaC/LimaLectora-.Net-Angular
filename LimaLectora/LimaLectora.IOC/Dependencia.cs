using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimaLectora.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using LimaLectora.DAL.DBContext;
using LimaLectora.DAL.Repositorios.Contrato;
using LimaLectora.DAL.Repositorios;

using LimaLectora.Utility;
using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.BLL.Servicios;

namespace LimaLectora.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LimalectoraContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IComprobanteRepository, ComprobanteRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IAccesoService, AccesoService>();
            services.AddScoped<IAreasService, AreasService>();
            services.AddScoped<IClientesService, ClienteService>();
            services.AddScoped<IComprobantesService, ComprobanteService>();
            services.AddScoped<IEmpleadosService, EmpleadoService>();
            services.AddScoped<IGenerosService, GenerosService>();
            services.AddScoped<ILibrosService, LibrosService>();
            services.AddScoped<IMetodoPagoService, MetodoPagoService>();
            services.AddScoped<IProveedoresService, ProveedoresService>();
            services.AddScoped<IRecepcionesService, RecepcionesService>();
            services.AddScoped<IVentasService, VentaService>();

        }

    }
}
