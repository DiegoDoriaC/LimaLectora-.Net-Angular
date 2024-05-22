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
    public class GenerosService : IGenerosService
    {
        private readonly IGenericRepository<Generos> _repository;
        private readonly IMapper _mapper;

        public GenerosService(IGenericRepository<Generos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var generos = await _repository.Obtener(u => u.IdGenero == id);
                if (generos == null) throw new TaskCanceledException("Genero no encontrado o no existe");
                var respuesta = await _repository.Delete(generos);
                return respuesta == false ? throw new TaskCanceledException("No se pudo eliminar el genero") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<GenerosDTO>> Listar()
        {
            try
            {
                var listaGeneros = await _repository.Consultar();
                if (listaGeneros == null) throw new TaskCanceledException("Ningun registro encontrado");
                return _mapper.Map<List<GenerosDTO>>(listaGeneros);
            }
            catch
            {
                throw;
            }
        }

        public async Task<GenerosDTO> Registrar(GenerosDTO cliente)
        {
            try
            {
                var EmpleadoRegistrado = await _repository.Crear(_mapper.Map<Generos>(cliente));
                if (EmpleadoRegistrado == null) throw new TaskCanceledException("No se pudo registrar el genero");
                return _mapper.Map<GenerosDTO>(EmpleadoRegistrado);
            }
            catch
            {
                throw;
            }
        }
    }
}
