using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Execution;
using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DAL.Repositorios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Model;

namespace LimaLectora.BLL.Servicios
{
    public class RecepcionesService : IRecepcionesService
    {
        private readonly IGenericRepository<Recepciones> _repository;
        private readonly IMapper _mapper;

        public RecepcionesService(IGenericRepository<Recepciones> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Actualizar(RecepcionesDTO cliente)
        {
            var recepcionMappeado = _mapper.Map<Recepciones>(cliente);
            try
            {
                var recepcionEncontrado = await _repository.Obtener(u => u.IdRecepcion == recepcionMappeado.IdRecepcion);
                if (recepcionEncontrado == null) throw new TaskCanceledException("La recepcion no exite");
                recepcionEncontrado.IdLibro = recepcionMappeado.IdLibro;
                recepcionEncontrado.IdEmpleado = recepcionMappeado.IdEmpleado;
                recepcionEncontrado.IdProveedor = recepcionMappeado.IdProveedor;
                recepcionEncontrado.Cantidad = recepcionMappeado.Cantidad;
                recepcionEncontrado.FechaIngreso = recepcionMappeado.FechaIngreso;
                var respuesta = await _repository.Editar(recepcionEncontrado);
                return respuesta == false ? throw new TaskCanceledException("No se pudo actualizar la recepcion") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RecepcionesDTO> Buscar(int id)
        {
            try
            {
                var recepcionEncontrado = await _repository.Obtener(u => u.IdRecepcion == id);
                if (recepcionEncontrado == null) throw new TaskCanceledException("Recepcion no encontrado o no existe");
                return _mapper.Map<RecepcionesDTO>(recepcionEncontrado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RecepcionesDTO>> BuscarFecha(string fechaInicio, string fechaFin)
        {
            try
            {
                DateTime fecha_Inicio = Convert.ToDateTime(fechaInicio, new CultureInfo("es_PE"));
                DateTime fecha_Fin = Convert.ToDateTime(fechaFin, new CultureInfo("es_PE"));
                var recepcionEncontrado = await _repository.Consultar(u => u.FechaIngreso >= fecha_Inicio && u.FechaIngreso <= fecha_Fin);
                if (recepcionEncontrado == null) throw new TaskCanceledException("Recepcion no encontrado o no existe");
                return _mapper.Map<List<RecepcionesDTO>>(recepcionEncontrado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var recepcion = await _repository.Obtener(u => u.IdRecepcion == id);
                if (recepcion == null) throw new TaskCanceledException("Recepcion no encontrado o no existe");
                var respuesta = await _repository.Delete(recepcion);
                return respuesta == false ? throw new TaskCanceledException("No se pudo eliminar la recepcion") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RecepcionesDTO>> Listar()
        {
            try
            {
                var listaRecepciones = await _repository.Consultar();
                if (listaRecepciones == null) throw new TaskCanceledException("Ningun registro encontrado");
                return _mapper.Map<List<RecepcionesDTO>>(listaRecepciones);
            }
            catch
            {
                throw;
            }
        }

        public async Task<RecepcionesDTO> Registrar(RecepcionesDTO cliente)
        {
            try
            {
                var recepcionRegistrado = await _repository.Crear(_mapper.Map<Recepciones>(cliente));
                if (recepcionRegistrado == null) throw new TaskCanceledException("No se pudo registrar la recepcion");
                return _mapper.Map<RecepcionesDTO>(recepcionRegistrado);
            }
            catch
            {
                throw;
            }
        }
    }
}
