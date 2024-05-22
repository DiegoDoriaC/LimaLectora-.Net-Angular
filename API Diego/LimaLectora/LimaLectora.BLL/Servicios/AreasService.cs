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
    public class AreasService : IAreasService
    {
        private readonly IGenericRepository<Areas> _repository;
        private readonly IMapper _mapper;

        public AreasService(IGenericRepository<Areas> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Actualizar(AreasDTO areas)
        {
            var objMappeado = _mapper.Map<Areas>(areas);
            var AreaEncontrada = await _repository.Obtener(u => u.IdArea == objMappeado.IdArea);
            try
            {
                if(AreaEncontrada == null) throw new TaskCanceledException("El area no fue encontrada");
                AreaEncontrada.Cargo = objMappeado.Cargo;
                AreaEncontrada.Sueldo = objMappeado.Sueldo;
                bool respuesta = await _repository.Editar(AreaEncontrada);
                return respuesta == false ? throw new TaskCanceledException("El area no pudo ser actualizada") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AreasDTO> Buscar(int id)
        {
            try
            {
                Areas areaEncontraa = await _repository.Obtener(a => a.IdArea == id);
                if (areaEncontraa == null) throw new TaskCanceledException("El area no fue encontrada");
                return _mapper.Map<AreasDTO>(areaEncontraa);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<AreasDTO>> Listar()
        {
            try
            {
                var listaArea = await _repository.Consultar();
                if (listaArea == null) throw new TaskCanceledException("Ningun registro encontrado");
                return _mapper.Map<List<AreasDTO>>(listaArea);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AreasDTO> Registrar(AreasDTO areas)
        {
            var areaMappeado = _mapper.Map<Areas>(areas);
            try
            {
                var areaRegistrada = await _repository.Crear(areaMappeado);
                if (areaRegistrada == null) throw new TaskCanceledException("No se pudo registrar el area");
                return _mapper.Map<AreasDTO>(areaRegistrada);
            }
            catch
            {
                throw;
            }
        }
    }
}
