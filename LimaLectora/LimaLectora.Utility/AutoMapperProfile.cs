using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using LimaLectora.DTO;
using LimaLectora.Model;

namespace LimaLectora.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            #region AccesoDTO
            CreateMap<Acceso, AccesoDTO>()
                    .ForMember(destino => destino.nombreEmpleado, options => options.MapFrom(origen => origen.IdEmpleadoNavigation.Nombre));
            #endregion AccesoDTO

            #region Acceso
            CreateMap<AccesoDTO, Acceso>()
                .ForMember(destino => destino.IdEmpleadoNavigation, options => options.Ignore());
            #endregion Acceso

            #region AreasDTO
            CreateMap<Areas, AreasDTO>()
                .ForMember(destino => destino.Sueldo, options => options.MapFrom(origen => Convert.ToString(origen.Sueldo, new CultureInfo("es-PE"))));
            #endregion AreasDTO

            #region Areas
            CreateMap<AreasDTO, Areas>()
                .ForMember(destino => destino.Sueldo, options => options.MapFrom(origen => Convert.ToDecimal(origen.Sueldo, new CultureInfo("es-PE"))));
            #endregion Areas

            #region ClientesDTO
            CreateMap<Clientes, ClientesDTO>()
                .ForMember(d => d.EsActivo, op => op.MapFrom(or => or.EsActivo == true ? 1 : 0));
            #endregion ClientesDTO

            #region Clientes
            CreateMap<ClientesDTO, Clientes>()
                .ForMember(d => d.EsActivo, op => op.MapFrom(or => or.EsActivo == 1 ? true : false))
                .ForMember(d => d.Comprobantes, op => op.Ignore());
            #endregion Clientes

            #region ComprobantesDTO
            CreateMap<Comprobantes, ComprobantesDTO>()
                .ForMember(d => d.NombreCliente, op => op.MapFrom(or => or.IdClienteNavigation.Nombre))
                .ForMember(d => d.NombreEmpleado, op => op.MapFrom(or => or.IdEmpleadoNavigation.Nombre))
                .ForMember(d => d.DescripcionMetodoPago, op => op.MapFrom(or => or.IdMetodoPagoNavigation.Nombre))
                .ForMember(d => d.Total, op => op.MapFrom(or => Convert.ToString(or.Total, new CultureInfo("es-PE"))))
                .ForMember(d => d.FechaVenta, op => op.MapFrom(or => or.FechaVenta.Value.ToString("dd/MM/yyyy")));
            #endregion ComprobantesDTO

            #region Comprobantes
            CreateMap<ComprobantesDTO, Comprobantes>()
                .ForMember(d => d.IdClienteNavigation, op => op.Ignore())
                .ForMember(d => d.IdEmpleadoNavigation, op => op.Ignore())
                .ForMember(d => d.IdMetodoPagoNavigation, op => op.Ignore())
                .ForMember(d => d.Total, op => op.MapFrom(or => Convert.ToString(or.Total, new CultureInfo("es-PE"))));
            #endregion Comprobantes

            #region EmpleadosDTO
            CreateMap<Empleados, EmpleadosDTO>()
                .ForMember(d => d.DescripcionArea, op => op.MapFrom(or => or.IdAreaNavigation.Cargo))
                .ForMember(d => d.FechaIngreso, op => op.MapFrom(or => or.FechaIngreso.Value.ToString("dd/MM/yyyy")))
                .ForMember(d => d.EsActivo, op => op.MapFrom(or => or.EsActivo == true ? 1 : 0));
            #endregion EmpleadosDTO

            #region Empleados
            CreateMap<EmpleadosDTO, Empleados>()
                .ForMember(d => d.IdAreaNavigation, op => op.Ignore())
                .ForMember(d => d.EsActivo, op => op.MapFrom(or => or.EsActivo == 1 ? true : false));
            #endregion Empleados

            #region Generos
            CreateMap<Generos, GenerosDTO>().ReverseMap();
            #endregion Generos

            #region LibrosDTO
            CreateMap<Libros, LibrosDTO>()
                .ForMember(d => d.NombreGenero, op => op.MapFrom(or => or.IdGeneroNavigation.Nombre))
                .ForMember(d => d.Precio, op => op.MapFrom(or => Convert.ToString(or.Precio, new CultureInfo("es-PE"))))
                .ForMember(d => d.AnioPublicacion, op => op.MapFrom(or => Convert.ToString(or.AnioPublicacion, new CultureInfo("es-PE"))))
                .ForMember(d => d.EsActivo, op => op.MapFrom(or => or.EsActivo == true ? 1 : 0));
            #endregion LibrosDTO

            #region Libros
            CreateMap<LibrosDTO, Libros>()
                .ForMember(d => d.IdGeneroNavigation, op => op.Ignore())
                .ForMember(d => d.Precio, op => op.MapFrom(or => Convert.ToDecimal(or.Precio, new CultureInfo("es-PE"))))
                .ForMember(d => d.AnioPublicacion, op => op.MapFrom(or => Convert.ToInt32(or.AnioPublicacion, new CultureInfo("es-PE"))))
                .ForMember(d => d.EsActivo, op => op.MapFrom(or => or.EsActivo == 1 ? true : false));
            #endregion Libros

            #region MetodoPago
            CreateMap<MetodoPago, MetodoPagoDTO>().ReverseMap();
            #endregion MetodoPago

            #region ProveedoresDTO
            CreateMap<Proveedores, ProveedoresDTO>()
                .ForMember(d => d.EsActivo, op => op.MapFrom(or => or.EsActivo == true ? 1 : 0));
            #endregion ProveedoresDTO

            #region Proveedores
            CreateMap<ProveedoresDTO, Proveedores>()
                .ForMember(d => d.EsActivo, op => op.MapFrom(or => or.EsActivo == 1 ? true : false));
            #endregion Proveedores

            #region RecepcionesDTO
            CreateMap<Recepciones, RecepcionesDTO>()
                .ForMember(d => d.NombreLibro, op => op.MapFrom(or => or.IdLibroNavigation.Nombre))
                .ForMember(d => d.NombreEmpleado, op => op.MapFrom(or => or.IdEmpleadoNavigation.Nombre))
                .ForMember(d => d.NombreProveedor, op => op.MapFrom(or => or.IdProveedorNavigation.Nombre))
                .ForMember(d => d.FechaIngreso, op => op.MapFrom(or => or.FechaIngreso.Value.ToString("dd/MM/yyyy")));
            #endregion RecepcionesDTO

            #region Recepciones
            CreateMap<RecepcionesDTO, Recepciones>()
                .ForMember(d => d.IdLibroNavigation, op => op.Ignore())
                .ForMember(d => d.IdEmpleadoNavigation, op => op.Ignore())
                .ForMember(d => d.IdProveedorNavigation, op => op.Ignore());
            #endregion Recepciones

            #region VentasDTO
            CreateMap<Ventas, VentasDTO>()
                .ForMember(d => d.NombreLibro, op => op.MapFrom(or => or.IdlibroNavigation.Nombre))
                .ForMember(d => d.Precio, op => op.MapFrom(or => Convert.ToString(or.Precio, new CultureInfo("es-PE"))))
                .ForMember(d => d.Total, op => op.MapFrom(or => Convert.ToString(or.Total, new CultureInfo("es-PE"))));
            #endregion VentasDTO

            #region Ventas
            CreateMap<VentasDTO, Ventas>()
                .ForMember(d => d.IdlibroNavigation, op => op.Ignore())
                .ForMember(d => d.Precio, op => op.MapFrom(or => Convert.ToDecimal(or.Precio, new CultureInfo("es-PE"))))
                .ForMember(d => d.Total, op => op.MapFrom(or => Convert.ToDecimal(or.Total, new CultureInfo("es-PE"))));
            #endregion Ventas

        }
    }
}