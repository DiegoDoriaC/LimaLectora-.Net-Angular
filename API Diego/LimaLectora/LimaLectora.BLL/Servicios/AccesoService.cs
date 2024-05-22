using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LimaLectora.BLL.Servicios.Contrato;
using LimaLectora.DAL.Repositorios.Contrato;
using LimaLectora.DTO;
using LimaLectora.Model;

namespace LimaLectora.BLL.Servicios
{
    public class AccesoService : IAccesoService
    {
        private readonly IGenericRepository<Acceso> _repository;
        private readonly IMapper _mapper;

        public AccesoService(IGenericRepository<Acceso> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Editar(AccesoDTO acceso)
        {
            var objMappeado = _mapper.Map<Acceso>(acceso);
            var AccesoEncontrado =  await _repository.Obtener(u => u.IdAcceso == objMappeado.IdAcceso);
            try
            {
                if(AccesoEncontrado != null)
                {
                    AccesoEncontrado.Clave = objMappeado.Clave;
                    bool respuesta = await _repository.Editar(AccesoEncontrado);
                    return respuesta != true ? throw new TaskCanceledException("No se ppudo actualizar el acceso") : respuesta;
                }
                throw new TaskCanceledException("Acceso no existe");
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<AccesoDTO>> Listar()
        {
            try
            {
                var listaServicios = await _repository.Consultar();
                if (listaServicios == null) throw new TaskCanceledException("No se encontraron Accesos");
                return _mapper.Map<List<AccesoDTO>>(listaServicios);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AccesoDTO> Registrar(AccesoDTO acceso)
        {
            try
            {
                var AccesoRegistrado = await _repository.Crear(_mapper.Map<Acceso>(acceso));
                if (AccesoRegistrado == null) throw new TaskCanceledException("No se pudo registrar el acceso");
                return _mapper.Map<AccesoDTO>(AccesoRegistrado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AccesoDTO> ValidarUsuario(string clave, string password)
        {
            try
            {
                Acceso usuarioLogueado = await _repository.Obtener(u => u.IdEmpleadoNavigation.Dni == clave && u.Clave == password);
                if (usuarioLogueado == null) throw new TaskCanceledException("Registro no encontrado");
                return _mapper.Map<AccesoDTO>(usuarioLogueado);
            }
            catch
            {
                throw;
            }
        }
    }
}
