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
    public class MetodoPagoService : IMetodoPagoService
    {
        private readonly IGenericRepository<MetodoPago> _repository;
        private readonly IMapper _mapper;

        public MetodoPagoService(IGenericRepository<MetodoPago> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var metodoPago = await _repository.Obtener(u => u.IdMetodoPago == id);
                if (metodoPago == null) throw new TaskCanceledException("Metodo de pago no encontrado o no existe");
                var respuesta = await _repository.Delete(metodoPago);
                return respuesta == false ? throw new TaskCanceledException("No se pudo eliminar el metodo de pago") : respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<MetodoPagoDTO>> Listar()
        {
            try
            {
                var listaMetodosPago = await _repository.Consultar();
                if (listaMetodosPago == null) throw new TaskCanceledException("Ningun registro encontrado");
                return _mapper.Map<List<MetodoPagoDTO>>(listaMetodosPago);
            }
            catch
            {
                throw;
            }
        }

        public async Task<MetodoPagoDTO> Registrar(MetodoPagoDTO cliente)
        {
            try
            {
                var metodoPagoRegistrado = await _repository.Crear(_mapper.Map<MetodoPago>(cliente));
                if (metodoPagoRegistrado == null) throw new TaskCanceledException("No se pudo registrar el metodo de pago");
                return _mapper.Map<MetodoPagoDTO>(metodoPagoRegistrado);
            }
            catch
            {
                throw;
            }
        }
    }
}
