using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DAL.Repositorios;
using LimaLectora.DAL.Repositorios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Model;
using Microsoft.EntityFrameworkCore;

namespace LimaLectora.BLL.Servicios
{
    public class ComprobanteService : IComprobantesService
    {
        private readonly IComprobanteRepository _comprobanteRepository;
        private readonly IGenericRepository<Comprobantes> _repository;
        private readonly IMapper _mapper;

        public ComprobanteService(IComprobanteRepository comprobanteRepository, IGenericRepository<Comprobantes> repository, IMapper mapper)
        {
            _comprobanteRepository = comprobanteRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ComprobantesDTO>> BuscarDniCliente(int dni)
        {
            try
            {
                var listarComprobantesPorDni = await _repository.Consultar(u => u.IdClienteNavigation.Dni == Convert.ToString(dni));
                if (listarComprobantesPorDni == null) throw new TaskCanceledException("No se encontraron registros para el cliente");
                return _mapper.Map<List<ComprobantesDTO>>(listarComprobantesPorDni);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ComprobantesDTO>> BuscarFecha(string fechaInicio, string fechaFin)
        {
            var resultado = new List<Comprobantes>();
            try
            {
                var listarComprobantesPorDni = await _comprobanteRepository.Consultar();
                DateTime fecha_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
                DateTime fecha_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-PE"));
                resultado = await listarComprobantesPorDni.Where(u => u.FechaVenta.Value >= fecha_Inicio.Date && u.FechaVenta.Value <= fecha_Fin.Date).ToListAsync();
                if (listarComprobantesPorDni == null) throw new TaskCanceledException("No se encontraron registros para el cliente");
                return _mapper.Map<List<ComprobantesDTO>>(listarComprobantesPorDni);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ComprobantesDTO>> Listar()
        {
            try
            {
                var listarComprobantes = await _repository.Consultar();
                if (listarComprobantes == null) throw new TaskCanceledException("No se encontraron comprobantes");
                return _mapper.Map<List<ComprobantesDTO>>(listarComprobantes);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ComprobantesDTO> Registrar(ComprobantesDTO cliente)
        {
            try
            {
                var comprobantesMappeado = _mapper.Map<Comprobantes>(cliente);
                var comprobanteRegistrado = await _comprobanteRepository.Crear(comprobantesMappeado);
                if (comprobanteRegistrado == null) throw new TaskCanceledException("No se pudo registrar el comprobante");
                return _mapper.Map<ComprobantesDTO>(comprobanteRegistrado);
            }
            catch
            {
                throw;
            }
        }
    }
}
