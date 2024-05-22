using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DAL.Repositorios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Model;

namespace LimaLectora.BLL.Servicios
{
    public class EmpleadoService : IEmpleadosService
    {
        private readonly IGenericRepository<Empleados> _repository;
        private readonly IMapper _mapper;

        public EmpleadoService(IGenericRepository<Empleados> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Actualizar(EmpleadosDTO cliente)
        {
            var empleadoMappeado = _mapper.Map<Empleados>(cliente);
            try
            {
                var empleadoEncontrado = await _repository.Obtener(u => u.IdEmpleado == empleadoMappeado.IdEmpleado);
                if (empleadoEncontrado == null) throw new TaskCanceledException("El empleado no exite");
                empleadoEncontrado.IdArea = empleadoMappeado.IdArea;
                empleadoEncontrado.Dni = empleadoMappeado.Dni;
                empleadoEncontrado.Nombre = empleadoMappeado.Nombre;
                empleadoEncontrado.Apellido = empleadoMappeado.Apellido;
                empleadoEncontrado.Telefono = empleadoMappeado.Telefono;
                empleadoEncontrado.FechaIngreso = empleadoMappeado.FechaIngreso;
                empleadoEncontrado.Email = empleadoMappeado.Email;
                empleadoEncontrado.Direccion = empleadoMappeado.Direccion;
                empleadoEncontrado.EsActivo = empleadoMappeado.EsActivo;
                var respuesta = await _repository.Editar(empleadoEncontrado);
                return respuesta == false ? throw new TaskCanceledException("No se pudo actualizar el empleado") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmpleadosDTO> Buscar(int id)
        {
            try
            {
                var empleadoEncontrado = await _repository.Obtener(u => u.IdEmpleado == id);
                if (empleadoEncontrado == null) throw new TaskCanceledException("Empleado no encontrado o no existe");
                return _mapper.Map<EmpleadosDTO>(empleadoEncontrado);
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
                var empleado = await _repository.Obtener(u => u.IdEmpleado == id);
                if (empleado == null) throw new TaskCanceledException("Empleado no encontrado o no existe");
                var respuesta = await _repository.Delete(empleado);
                return respuesta == false ? throw new TaskCanceledException("No se pudo eliminar el empleado") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmpleadosDTO>> Listar()
        {
            try
            {
                var listaEmpleado = await _repository.Consultar();
                if (listaEmpleado == null) throw new TaskCanceledException("Ningun registro encontrado");
                return _mapper.Map<List<EmpleadosDTO>>(listaEmpleado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmpleadosDTO> Registrar(EmpleadosDTO cliente)
        {
            try
            {
                var EmpleadoRegistrado = await _repository.Crear(_mapper.Map<Empleados>(cliente));
                if (EmpleadoRegistrado == null) throw new TaskCanceledException("No se pudo registrar el empleado");
                return _mapper.Map<EmpleadosDTO>(EmpleadoRegistrado);
            }
            catch
            {
                throw;
            }
        }
    }
}
